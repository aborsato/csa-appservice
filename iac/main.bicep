// ░▄▀▀░▄▀▀▒▄▀▄
// ░▀▄▄▒▄██░█▀█
// Microsoft

// Location will be taken from Resource Group

param appPrefix string = ''
param skuName string = 'S1'
param skuCapacity int = 1
param location string = resourceGroup().location
param appName string = uniqueString(resourceGroup().id)

var appServicePlanName = toLower('${appPrefix}${appName}-asp')
var webSiteName = toLower('${appPrefix}${appName}-wapp')

@description('The name for the Mongo DB database')
param databaseName string = 'main'
param cosmosLocation string = 'westus3'

var accountName = toLower('${appPrefix}${appName}-cosmosdb')
var locations = [
  {
    locationName: cosmosLocation
    failoverPriority: 0
    isZoneRedundant: false
  }
]

// Creates a Cosmos DB Account
resource cosmosAccount 'Microsoft.DocumentDB/databaseAccounts@2021-10-15' = {
  name: accountName
  location: cosmosLocation
  kind: 'GlobalDocumentDB'
  properties: {
    locations: locations
    databaseAccountOfferType: 'Standard'
    capabilities: [
      {
        name: 'DisableRateLimitingResponses'
      }
      {
        name: 'EnableServerless'
      }
    ]
  }
}

// Creates a Cosmos DB Database
resource cosmosAccountDatabase 'Microsoft.DocumentDB/databaseAccounts/mongodbDatabases@2021-10-15' = {
  name: databaseName
  parent: cosmosAccount
  properties: {
    resource: {
      id: databaseName
    }
  }
}

// Creates an App Service Plan to host the web app with default (Windows) stack
resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: skuName
    capacity: skuCapacity
  }
}

// Creates the App Service web app
resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: webSiteName
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      minTlsVersion: '1.2'
    }
  }

  resource staticSiteSettings 'config@2021-03-01' = {
    name: 'appsettings'
    properties: {
      'CosmosDb:ConnectionString': first(cosmosAccount.listConnectionStrings().connectionStrings).connectionString
      'CosmosDb:DatabaseName': databaseName
      'CosmosDb:ContainerName': 'WeatherForecast'
    }
  }
}
