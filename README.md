# Azure App Service
Azure App Service quickly and easily creates enterprise-ready web and mobile apps for any platform or device, and deploy them on a scalable and reliable cloud infrastructure.

This is a sample deployment to get started with Web API in Azure, featuring:
- App Service
- API Management


# Landing Zone

Azure landing zones are the output of a multisubscription Azure environment that accounts for scale, security governance, networking, and identity. Azure landing zones enable application migration, modernization, and innovation at enterprise-scale in Azure. These zones consider all platform resources that are required to support the customer's application portfolio and don't differentiate between infrastructure as a service or platform as a service.


## Target Audience

- Cloud Solution Architect
- Cloud Infrastructure Architect
- Application Developer/DevOps Engineer

## Architecture


## Deploy

Use the link below to deploy the entire solution to the subscription you want.
[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Faborsato%2Fcsa-appservice%2Fmaster%2Fazuredeploy.json)

You can also build from the Bicep file to import/deploy the resulting ARM template:
```bash
az bicep build --file main.bicep --outfile azuredeploy.json
```

Or deploy it directly from the .bicep file:
```bash
RESOURCE_GROUP="my-rg-name"
az group create --name $RESOURCE_GROUP --location eastus
az deployment group create -f ./main.bicep -g $RESOURCE_GROUP
```

## Azure services and related products

- [Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/)
- [Azure API Management](https://docs.microsoft.com/en-us/azure/api-management/)

## Related references

- TBD
