---
aliases: [AZ-900 1: Introduction to Azure fundamentals, Introduction to Azure fundamentals]
tags: Techniek
---
# Azure
Microsoft Azure is a private and public cloud platform that helps developers to build, deploy and manage their applications. It uses virtualization, which separates hardware and [[1. Werk/2. Technische kennis/Algemene concepten/OS|OS (Operating system)]] with a [[Hypervisor]] as an abstraction layer. The hypervisor simulates a physical computer and its [[CPU]] in a [[VM|VM (Virtual machine)]]. It can run multiple [[VM]]s at the same time and each VM can run any compatible [[1. Werk/2. Technische kennis/Algemene concepten/OS|OS (Operating system)]]. The virtualization layer is then spread across data centers across the world with mini racks filled with servers. Each server includes a [[Hypervisor]] to run multiple [[VM]]s. A network switch provides connectivity to all those servers. One server in each rack runs a [[Fabric Controller]], which is in turn connected to the [[Orchestrator]]. The [[Orchestrator]] delegates web API requests and data packages to various [[Fabric Controller]]s across the world depending on availability. The [[Fabric Controller]] then creates the [[VM|Virtual machine]] for the user to connect with.

## Portal
### Azure Portal
Web-based console to manage your Azure subscription, services, resources, etc. 
- Build, manage, and monitor everything from simple web apps to complex cloud deployments
- Create custom dashboards for an organized view of resources
- Configure accessibility for an optimal experience. 

#### Azure Cloud Shell
Browser-based shell tool that lets you create, configure, and manage your Azure resources in a shell. It supports both [[PowerShell]] and Azure [[CLI]], which is a [[Bash]] shell. You can find the Cloud Shell in the Azure Portal right here: 
![[Azure fundamentals 19.png]]
It requires no local installation or configuration, and inherits your Azure authorization and permissions. 

#### Azure [[PowerShell]]
In this shell you can run commands called commandlets ([[cmdlets]]). These call the Azure [[REST|REST API]] to perform management tasks in Azure. Cmdlets can be run independently to handle one-off changes, or they may be combined to orchestrate complex actions such as routine setup, teardown and resource maintenance, or the deployment of an entire infrasctructure from imperative code. Scripting these commands makes the process repeatable and automatable. 

Azure PowerShell is available via Azure Cloud Shell, and you can also install and configure Azure PowerShell on Windows, Linux, and Mac platforms. 

#### Azure [[CLI]]
This is functionally equivalent to Azure PowerShell, but it uses [[Bash]] syntax for the commands. Again, you can access it in the Cloud Shell or install and configure it on Windows, Linux and Mac platforms. 

#### Azure Arc
Azure Arc lets you extend your Azure compliance and monitoring to your hybrid and multi-cloud configurations by utilizing Azure Resource Manager (ARM). 

Azure Arc provides a centralized, unified way to:
- Manage your entire environment together by projecting your existing non-Azure resources into ARM.
- Manage multi-cloud and hybrid virtual machines, Kubernetes clusters, and databases as if they are running in Azure.
- Use familiar Azure services and management capabilities, regardless of where they live.
- Continue using traditional ITOps while introducing DevOps practices to support new cloud and native patterns in your environment.
- Configure custom locations as an abstraction layer on top of Azure Arc-enabled Kubernetes clusters and cluster extensions.

Currently, Azure Arc allows you to manage the following resource types outside of Azure: 
- Servers
- Kubernetes clusters
- Azure data services
- SQL Server
- Virtual machines

##### Azure Resource Manager (ARM)
This is the deployment and management service for Azure. This management layer enables you to create, update and delete resources in your Azure account. When a user sends a request from any of the Azure tools, [[API]]s, or [[SDK]]s, ARM authenticates and authorizes the request and sends the request to the Azure service. All requests are handled through the same API so results are consistent throughout. 

With Azure Resource Manager, you can:
-   Manage your infrastructure through declarative templates rather than scripts. A Resource Manager template is a JSON file that defines what you want to deploy to Azure.
-   Deploy, manage, and monitor all the resources for your solution as a group, rather than handling these resources individually.
-   Re-deploy your solution throughout the development life-cycle and have confidence your resources are deployed in a consistent state.
-   Define the dependencies between resources, so they're deployed in the correct order.
-   Apply access control to all services because RBAC is natively integrated into the management platform.
-   Apply tags to resources to logically organize all the resources in your subscription.
-   Clarify your organization's billing by viewing costs for a group of resources that share the same tag.

In addition to Azure Cloud Shell, Azure PowerShell and Azure CLI, you can also use ARM templates to describe the resources you want to use in a declarative [[JSON]] format. The deployment code is verified before any code is run, to ensure that resources are created and connected correctly. The template then orchestrates the creation of those resources in parallel. You only need to define the desired state and configuration of each resource in the ARM template, an the template does the rest. Templates can even execute PowerShell and Bash scripts before or after the resource has been set up. 

Some benefits: 
- **Declarative syntax**: ARM templates allow you to create and deploy an entire Azure infrastructure declaratively. Declarative syntax means you declare what you want to deploy but don’t need to write the actual programming commands and sequence to deploy the resources.
- **Repeatable results**: Repeatedly deploy your infrastructure throughout the development lifecycle and have confidence your resources are deployed in a consistent manner. You can use the same ARM template to deploy multiple dev/test environments, knowing that all the environments are the same.
- **Orchestration**: You don't have to worry about the complexities of ordering operations. Azure Resource Manager orchestrates the deployment of interdependent resources, so they're created in the correct order. When possible, Azure Resource Manager deploys resources in parallel, so your deployments finish faster than serial deployments. You deploy the template through one command, rather than through multiple imperative commands.
- **Modular files**: You can break your templates into smaller, reusable components and link them together at deployment time. You can also nest one template inside another template. For example, you could create a template for a VM stack, and then nest that template inside of templates that deploy entire environments, and that VM stack will consistently be deployed in each of the environment templates.
- **Extensibility**: With deployment scripts, you can add PowerShell or Bash scripts to your templates. The deployment scripts extend your ability to set up resources during deployment. A script can be included in the template or stored in an external source and referenced in the template. Deployment scripts give you the ability to complete your end-to-end environment setup in a single ARM template.

### Services
![[Azure fundamentals 1.png]]

#### Compute
| Service name                      | Service function                                                         |
| --------------------------------- | ------------------------------------------------------------------------ |
| Azure virtual Machines            | Windows or Linux virtual machines hosted in Azure                        |
| Azure Virtual  Machine Scale Sets | Scaling for Windows or Linux VMs hosted in Azure                         |
| Azure Kubernetes Service          | Cluster management for VMs that run containerized services               |
| Azure Service Fabric              | Distributed systems platform that runs in Azure or on-premises           |
| Azure Batch                       | Managed service for parallel and high-performance computing applications |
| Azure Container Instances         | Containerized apps run on Azure without provisioning servers or VMs      |
| Azure Functions                   | An event-driven, serverless compute service                              |

#### Networking
| Service name                   | Service function                                                                     |
| ------------------------------ | ------------------------------------------------------------------------------------ |
| Azure Virtual Network          | Connects VMs to incoming virtual private network (VPN) connections                   |
| Azure Load Balancer            | Balances inbound and outbound connections to applications or service endpoints       |
| Azure Application Gateway      | Optimizes app server farm delivery while increasing application security             |
| Azure VPN Gateway              | Accesses Azure Virtual Networks through high-performance VPN gateways                |
| Azure DNS                      | Provides ultra-fast DNS responses and ultra-high domain availability                 |
| Azure Content Delivery Network | Delivers high-bandwidth content to customers globally                                |
| Azure DDoS Protection          | Protects Azure-hosted applications from distributed denial of service (DDOS) attacks |
| Azure Traffic Manager          | Distributes network traffic across Azure regions worldwide                           |
| Azure ExpressRoute             | Connects to Azure over high-bandwidth dedicated secure connections                   |
| Azure Network Watcher          | Monitors and diagnoses network issues by using scenario-based analysis               |
| Azure Firewall                 | Implements high-security, high-availability firewall with unlimited scalability      |
| Azure Virtual WAN              | Creates a unified wide area network (WAN) that connects local and remote sites       |

#### Storage
| Service name        | Service function                                                                                                                                                                   |
| ------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Azure Blob storage  | Storage service for very large objects, such as video files or bitmaps                                                                                                             |
| Azure File storage  | File shares that can be accessed and managed like a file server                                                                                                                    |
| Azure Queue storage | A data store for queuing and reliably delivering messages between applications                                                                                                     |
| Azure Table storage | Table storage is a service that stores non-relational structured data (also known as structured NoSQL data) in the cloud, providing a key/attribute store with a schemaless design |

The above services share several common characteristics:
* Durable and highly available with redundancy and replication
* Secure through automatic encryption and role-based access control
* Scalable with virtually unlimited storage
* Managed, handling maintenance and any critical problems for you
* Accessible from anywhere in the world over HTTP or HTTPS

#### Mobile
With Azure, developers can create mobile back-end services for iOS, Android, and Windows apps quickly and easily. Features that used to take time and increase project risks, such as adding corporate sign-in and then connecting to on-premises resources such as SAP, Oracle, SQL Server, and SharePoint, are now simple to include.

Other features of this service include:
-   Offline data synchronization.
-   Connectivity to on-premises data.
-   Broadcasting push notifications.
-   Autoscaling to match business needs.

#### Databases
| Service name                         | Service function                                                                                    |
| ------------------------------------ | --------------------------------------------------------------------------------------------------- |
| Azure Cosmos DB                      | Globally distributed database that supports NoSQL options                                           |
| Azure SQL Database                   | Fully managed relational database with auto-scale, integral intelligence, and robust security       |
| Azure Database for MySQL             | Fully managed and scalable MySQL relational database with high availability and security            |
| Azure Database for PostgreSQL        | Fully managed and scalable PostgreSQL relational database with high availability and security       |
| SQL Server on Azure Virtual Machines | Service that hosts enterprise SQL Server apps in the cloud                                          |
| Azure Synapse Analytics              | Fully managed data warehouse with integral security at every level of scale at no extra cost        |
| Azure Database Migration Service     | Service that migrates databases to the cloud with no application code changes                       |
| Azure Cache for Redis                | Fully managed service caches frequently used and static data to reduce data and application latency |
| Azure Database for MariaDB           | Fully managed and scalable MariaDB relational database with high availability and security          |

#### Web
| Service name                          | Description                                                               |
| ------------------------------------- | ------------------------------------------------------------------------- |
| Azure App Service                     | Quickly create powerful cloud web-based apps                              |
| Azure Notification Hubs               | Send push notifications to any platform from any back end                 |
| Azure API Management                  | Publish APIs to developers, partners, and employees securely and at scale |
| Azure Cognitive Search                | Deploy this fully managed search as a service                             |
| Web Apps feature of Azure App Service | Create and deploy mission-critical web apps at scale                      |
| Azure SignalR Service                 | Add real-time web functionalities easily                                  |

#### Internet of Things (IoT)
| Service name  | Description                                                                                                                                                                                         |
| ------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IoT Central   | Fully managed global IoT software as a service (SaaS) solution that makes it easy to connect, monitor, and manage IoT assets at scale                                                               |
| Azure IoT Hub | Messaging hub that provides secure communications between and monitoring of millions of IoT devices                                                                                                 |
| IoT Edge      | Fully managed service that allows data analysis models to be pushed directly onto IoT devices, which allows them to react quickly to state changes without needing to consult cloud-based AI models |

#### Big data
| Service name            | Description                                                                                                                                                                                     |
| ----------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Azure Synapse Analytics | Run analytics at a massive scale by using a cloud-based enterprise data warehouse that takes advantage of massively parallel processing to run complex queries quickly across petabytes of data |
| Azure HDInsight         | Process massive amounts of data with managed clusters of Hadoop clusters in the cloud                                                                                                           |
| Azure Databricks        | Integrate this collaborative Apache Spark-based analytics service with other big data services in Azure                                                                                         |

#### AI
Here are some of the most common AI and machine learning service types in Azure:

| Service name| Description   |
| ------------------------------ | --- |
| Azure Machine Learning Service | Cloud-based environment you can use to develop, train, test, deploy, manage, and track machine learning models. It can auto-generate a model and auto-tune it for you. It will let you start training on your local machine, and then scale out to the cloud |
| Azure ML Studio                | Collaborative visual workspace where you can build, test, and deploy machine learning solutions by using prebuilt machine learning algorithms and data-handling modules.                                                                                     |

A closely related set of products are the *cognitive services*. You can use these prebuilt APIs in your application to solve complex problems:

| Service name                | Description                                                                                                                             |
| --------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- |
| Vision                      | Use image-processing algorithms to smartly identify, caption, index, and moderate your pictures and videos                              |
| Speech                      | Convert spoken audio into text, use voice for verification, or add speaker recognition to your app                                      |
| Knowledge mapping           | Map complex information and data to solve tasks such as intelligent recommendations and semantic search                                 |
| Bing Search                 | Add Bing Search APIs to your apps and harness the ability to comb billions of webpages, images, videos, and news with a single API call |
| Natural Language processing | Allow your apps to process natural language with prebuilt scripts, evaluate sentiment, and learn how to recognize what users want       |

#### DevOps
With Azure DevOps you can create *build* and *release* pipelines that provide continuous integration, delivery and deployment for your applications. You can integrate repositories and application tests, perform application monitoring, and work with build artifacts. You can also work with and backlog items for tracking, automate infrastructure deployment, and integrate a range of third-party tools such as Jenkins and Chef. All of these functions and many more are closely integrated with Azure to allow for consistent, repeatable deployments for your applications to provide streamlined build and release processes. 

| Service name       | Description                                                                                                                                                                                                                            |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Azure DevOps       | Use development collaboration tools such as high-performance pipelines, free private Git repositories, configurable Kanban boards, and extensive automated and cloud-based load testing. Formerly known as Visual Studio Team Services |
| Azure DevTest Labs | Quickly create on-demand Windows and Linux environments to test or demo applications directly from deployment pipelines                                                                                                                |

## Azure accounts
![[Azure fundamentals 2.png]]
To create and use Azure services, you need a subscription. A company might use a single Azure account for their business and separate subscriptions for development, marketing and sales departments. You can create Azure resources within each subscription.

![[Azure fundamentals 3.png]]
The top-level may also be a group of accounts. 

-   **Management groups**: These groups help you manage access, policy, and compliance for multiple subscriptions. All subscriptions in a management group automatically inherit the conditions applied to the management group.
-   **Subscriptions**: A subscription groups together user accounts and the resources that have been created by those user accounts. For each subscription, there are limits or quotas on the amount of resources that you can create and use. Organizations can use subscriptions to manage costs and the resources that are created by users, teams, or projects.
-   **Resource groups**: Resources are combined into resource groups, which act as a logical container into which Azure resources like web apps, databases, and storage accounts are deployed and managed.
-   **Resources**: Resources are instances of services that you create, like virtual machines, storage, or SQL databases.

### Free options
#### Free account
* Free access to popular Azure products for 12 months
* A credit to spend for the first 30 days
* Access to more than 40 products that are always free
To start, you need a phone number, a credit card, and a Microsoft or GitHub account. The credit card information is for identity verification only. You won't be charged for any services unless you upgrade to a paid subscription.

#### Free student account
* Free access to certain Azure services for 12 months
* A credit to use in the first 12 months
* Free access to certain software developer tools
This offer gives $100 credit and free developer tools, and you can sign up without a credit card.

### Azure subscriptions
An account can have one subscription or multiple subscriptions that have different billing models and to which you apply different accessmanagement policies. 
* **Billing boundary**: This subscription type determines how an Azure account is billed. Azure generatese separate billing reports and invoices for each subscription so that you can organize and manage costs.
* **Access control boundary**: Azure applies accessmanagement policies at the subscription level, and you can create separate subscriptions to reflect different organizational structures. 

![[Azure fundamentals 5.png]]

Some ideas for how to define different subscriptions under your Azure account:
* **Environments**: When managing your resources, you can choose to create subscriptions to set up separate environments for development and testing, security, or to isolate data for compliance reasons. 
* **Organizational structures**: You can create subscriptions to reflect different organizational structures. For example, you could limit a team to lower-cost resources, while allowing the IT department a full range. 
* **Billing**: Because costs are first aggregated at the subscription level, you might want to manage and track costs based on your needs. For example, you might want to create one subscription for your production workloads and another subscription for your development and testing workloads.
* **Subscription limits**: Subscriptions are bound to some hard limitations. For example, the maximum number of Azure ExpressRoute circuits per subscription is 10. 

#### Customized billing
Subscriptions can be organized into invoice sections, which can be organized further into billing profiles. Each billing profile has its own invoice and payment method.
![[Azure fundamentals 6.png]]

### Azure management groups
Azure mangement are scoped above subscriptions, so you can use them to manage access, policies and compliance efficiently. All subscriptions within a management group inheret the conditions applied to the management group. Specific management groups can be collected in more generic management groups that control the more generic conditions. 
![[Azure fundamentals 7.png]]
A management group tree can support up to six levels of depth. This limit doesn't include the root level or the subscription level. Each management group and subscription can support only one parent. All subscriptions and management groups are within a single hierarchy in each directory.

### Regions, availability zones, and region pairs
Azure is made up of datacenters around the globe. When you use a service or create a resource such as a SQL database or a VM, you're using physical equipment in one or more of these locations. Azure organizes them into regions. 

#### Azure regions
A *region* is a geographical area on the planet that contains at least one but potentially multiple datacenters that are nearby and networked together with a low-latency network. Azure intelligently assigns and controls the resources within each region to ensure the workloads are appropirately balanced. You'll often need to choose in which region you want your resource to be deployed.

Here's a view of all the available regions as of June 2020:
![[Azure fundamentals 4.png]]

Azure has specialized regions that you might want to use when you build out your applications for compliance or legal purposes. A few examples include:

-   **US DoD Central, US Gov Virginia, US Gov Iowa and more:** These regions are physical and logical network-isolated instances of Azure for U.S. government agencies and partners. These datacenters are operated by screened U.S. personnel and include additional compliance certifications.
-   **China East, China North, and more:** These regions are available through a unique partnership between Microsoft and 21Vianet, whereby Microsoft doesn't directly maintain the datacenters.

Regions are what you use to identify the location for your resources. There are two other terms you should also be aware of: _geographies_ and _availability zones_.

#### Availability zones
These are physically separate datacenters within a region. Each availability zone is made up of one or more datacenters with independent power, cooling, and networking. It is set up to be an *isolation boundary*. If one zone goes down, the other continues working. They are connected through high-speed, private fiber-optic networks.

Availability zones are primarily for VMs, managed disks, load balancers, and SQL databases. The following categories of Azure services support availability zones:
* **Zonal services**: You pin the resource to a specific zone (for example, VMs, managed disks, IP addresses)
* **Zone-redundant services**: The platform replicates automatically across zones (for example, zone-redundant storage, SQL database)
* **Non-regional services**: Services are always available from Azure geographies and are resilient to zone-wide outages as well as region-wide outages

#### Region pairs
Availability zones are created by using one or more datacenters. There's a minimum of three zones within each region. In addition, each Azure region is always paired with another region within the same geography (such as US, Europe, or Asia) at least 300 miles away. This approach allows for the replication of resources (such as VM storage) across a geography that helps reduce the likelihood of interruptions because of events such as natural disasters, civil unrest, power outages, or physical network outages that affect both regions at once. If a region in a pair was affected by a natural disaster, for instance, services would automatically failover to the other region in its pair. 

Additional advantages:
* If an extensive Azure outage occurs, one region out of every pair is prioritized to make sure at least one is restored as quickly as possible for applications hosted in that region pair
* Planned Azure updates are rolled out to paired regions one region at a time to minimize downtime and risk of application outage
* Data continues to reside within the same geography as its pair for tax- and law-enforcement jurisdiction purposes

### Resource groups
![[Azure fundamentals 8.png]]
Anything you create, provision, deploy, etc. is a resource. Virtual machines ([[VM]]), virtual networks, databases, cognitive services, etc. are all considered resources. When you create a resource, you're required to place it in a resource group. A single resource can only be in a one resource group. Some resources may be moved between groups, but when you move a resource to a new group, it will no longer be associated with the former group. Resource groups cannot be nested. 

When you apply an action to a resource group, that will apply to all the resources within the group. 

### Tags
- **Resource management** Tags enable you to locate and act on resources that are associated with specific workloads, environments, business units, and owners.
- **Cost management and optimization** Tags enable you to group resources so that you can report on costs, allocate internal cost centers, track budgets, and forecast estimated cost.
- **Operations management** Tags enable you to group resources according to how critical their availability is to your business. This grouping helps you formulate service-level agreements (SLAs). An SLA is an uptime or performance guarantee between you and your users.
- **Security** Tags enable you to classify data by its security level, such as public or confidential.
- **Governance and regulatory compliance** Tags enable you to identify resources that align with governance or regulatory compliance requirements, such as ISO 27001. Tags can also be part of your standards enforcement efforts. For example, you might require that all resources be tagged with an owner or department name.
- **Workload optimization and automation** Tags can help you visualize all of the resources that participate in complex deployments. For example, you might tag a resource with its associated workload or application name and use software such as Azure DevOps to perform automated tasks on those resources.

### Pricing
Azure shifts development costs from the capital expense ([[CapEx]]) of building out and maintaining infrastructure and facilities to an operational expense ([[OpEx]]) of renting infrastructure as you need it, whether it’s compute, storage, networking, and so on.

Some price impacting factors:
- **Resource type**: When you provision an Azure resource, Azure creates metered instances for that resource. The meters track the resources' usage and generate a usage record that is used to calculate your bill.
- **Consumption**: You pay for resources used during a billing cycle. You can also commit to a set (minimum) amount of resources and get a discount for those "reserved" resources. This discount can go up to 72%.
- **Maintenance**: You can rapidly adjust resources based on demand. Resource groups help with that. Dilligent cloud maintenance to clear out unused resources can help you control cloud costs. 
- **Geography**: There are global pricing differences between deployment regions and for network traffic over larger distances. 
- **Subscription type**: Some Azure subscription types i nclude usage allowances, which affect costs.
- **Azure Marketplace**: You can purchase Azure-based solutions and services from third-party vendors. Billing structures are set by the vendor. 

#### Pricing calculator
The Pricing calculator gives you an estimated cost for provisioning resources in Azure. You can estimate the cost of any provisioned resources, including compute, storage, and associated network costs. You can even account for different storage options like storage type, access tier, and redundancy. Nothing is provisioned when you add resources to the pricing calculator, and you won't be charged for any services you select. 

#### Total Cost of Ownership (TCO) calculator
The TCO calculator is designed to help you compare the costs for running an on-premises infrastructure compared to an Azure Cloud infrastructure. With the TCO calculator, you enter your current infrastructure configuration, including servers, databases, storage, and outbound network traffic. The TCO calculator then compares the anticipated costs for your current environment with an Azure environment supporting the same infrastructure requirements.

With the TCO calculator, you enter your configuration, add in assumptions like power and IT labor costs, and are presented with an estimation of the cost difference to run the same environment in your current datacenter or in Azure.

#### Azure Cost Management tool
Cost Management lets you quickly check Azure resource costs, create alerts based on resource spend, and create budgets that can be used to automate resource management. Cost analysis is a subset of Cost Management that provides a quick visual for your Azure costs. 
![[Azure fundamentals 18.png]]

##### Cost alerts
You can set up three types of alerts: 
- **Budget alerts**: Notify you when spending, based on usage or cost, exceeds the alert condition of the budget. These budgets are created using the Azure portal or the Azure Consumption API. 
- **Credit alerts**: Notify you when your Azure credit monetary commitments are consumed. This is for Enterprise Agreements (EAs). These alerts are automatically generated at 90% and 100%. 
- **Department spending quota alerts**: Notify you when department spending reaches a fixed threshold of the quota. Configured in the EA portal. It generates an email to department owners. 

##### Budgets
You can set budgets based on a subscription, resource group, service type, or other criteria. When setting a budget, you also set a budget alert. If configured, budget alerts also send an email notification to budget alert recipients (set per budget). 

A more advanced use of budgets enables budget conditions to trigger automation that suspends or otherwise modifies resources once the trigger condition has occurred.

## Governance and Compliance
### Azure Blueprints
Azure Blueprints lets you standardize cloud subscriptions or environment deployments over multiple subscriptions. Instead of having to configure features like Azure Policy for each new subscription, with Azure Blueprints you can define repeatable settings and policies that are applied as new subscriptions are created.

Each component in the blueprint definition is known as an artifact. Artifacts can contain zero-to-many configurable parameters. You can specify a parameter's value when you create the blueprint definition or when you assign the blueprint definition to a scope. Artifacts can include such things as:
- Role assignments
- Policy assignments
- Azure Resource Manager templates
- Resource groups

Azure Blueprints are version-able, so you can iterate on your configuration sets and keep track of which deployments used which configuration set. The relationship between the blueprint definition and the blueprint assignment is preserved in a record that associates a resource with the blueprint that defines it. This helps you track and audit your deployments. 

### Azure Policy
This service enables you to create, assign, and manage policies that control or audit your resources. These policies enforce different rules across your resource configurations so that those configurations stay compliant with corporate standards. 

You can define both individual policies and groups of related policies, known as initiatives. Azure Policy evaluates your resources and highlights resources that aren't compliant with your policies. It can also prevent noncompliant resources from being created. 

Azure Policies can be set at each level, and they are inherited. 

There are built-in policy and initiative definitions for Storage, Networking, Compute, Security Center, and Monitoring so these can be automatically invoked. In some cases, Azure Policy can automatically remediate noncompliant resources and configurations to ensure the integrity of the state of the resources. It also integrates with Azure DevOPs by applying any continuous integration and delivery pipeline policies that pertain to the pre-deployment and post-deployment phases of your applications. 

### Resource locks
You can prevent resources from being accidentally deleted or changed with a resource lock. There are two types:
- Delete means authorized users can still read and modify a resource, but they can't delete the resource.
- ReadOnly means authorized users can read a resource, but they can't delete or update the resource. Applying this lock is similar to restricting all authorized users to the Reader role. 

You can manage resource locks from the Azure Portal, PowerShell, the Azure [[CLI]], or from an Azure Resource Manager template. To view, add, or delete locks in the Azure Portal, go to the Settings section of any resource. 

You can still make changes by first removing the lock, then performing your changes, and then optionally putting the lock back in place.

### Service Trust Portal
This portal provides access to content, tools and other resources about Microsoft security, privacy, and compliance practices. It contains details about Microsoft's implementation of controls and processes that protect your cloud services and the customer data therein. Some of these resources can only be accessed after you sign in as an authenticated user with your Azure [[AD|AD (Active Directory)]] account. You'll need to review and accept the [[NDA]] for compliance materials. 

[Service Trust Portal](https://servicetrust.microsoft.com)
-   **Service Trust Portal** provides a quick access hyperlink to return to the Service Trust Portal home page.
-   **My Library** lets you save (or pin) documents to quickly access them on your My Library page. You can also set up to receive notifications when documents in your My Library are updated.
-   **All Documents** is a single landing place for documents on the service trust portal. From **All Documents**, you can pin documents to have them show up in your **My Library**.

## Monitoring tools
### Azure Advisor
This tool evaluates your Azure resources and makes recommendations. It is designed to help you save time on cloud optimization. The recommendation service includes suggested actions you can take right away, postpone, or dismiss. They are available through the Azure Portal and the [[API]], and you can set up notifications to alert you to new recommendations. 

Categories of recommendations: 
- **Reliability** is used to ensure and improve the continuity of your business-critical applications.
- **Security** is used to detect threats and vulnerabilities that might lead to security breaches.
- **Performance** is used to improve the speed of your applications.
- **Operational Excellence** is used to help you achieve process and workflow efficiency, resource manageability, and deployment best practices.
- **Cost** is used to optimize and reduce your overall Azure spending.

### Azure Service Health
This global cloud solution helps you keep track of Azure resources, both specifically deployed resources and the overall status of Azure. 

- **Azure Status** is a broad picture of the status of Azure globally. Azure status informs you of service outages in Azure on the Azure Status page. The page is a global view of the health of all Azure services across all Azure regions. It’s a good reference for incidents with widespread impact.
- **Service Health** provides a narrower view of Azure services and regions. It focuses on the Azure services and regions you're using. This is the best place to look for service impacting communications about outages, planned maintenance activities, and other health advisories because the authenticated Service Health experience knows which services and resources you currently use. You can even set up Service Health alerts to notify you when service issues, planned maintenance, or other changes may affect the Azure services and regions you use.
- **Resource Health** is a tailored view of your actual Azure resources. It provides information about the health of your individual cloud resources, such as a specific virtual machine instance. Using Azure Monitor, you can also configure alerts to notify you of availability changes to your cloud resources.

Alert history can be reviewed later, so you can investigate trends and do thorough analysis. If a workload you're running is impacted by an event, Azure Service Health provides links to support. 

### Azure Monitor
This is a platform to monitor Azure resources, on-premises resources, and even multi-cloud resources like [[VM]]s hosted with a different cloud provider. 
![[Azure fundamentals 20.png]]
On the left is a list of the sources of logging and metric data that can be collected at every layer in your application architecture, from application to operating system and network.
In the center, the logging and metric data are stored in central repositories.
On the right, the data is used in several ways. You can view real-time and historical performance across each layer of your architecture or aggregated and detailed information. The data is displayed at different levels for different audiences. You can view high-level reports on the Azure Monitor Dashboard or create custom views by using Power BI and Kusto queries.

Additionally, you can use the data to help you react to critical events in real time, through alerts delivered to teams via SMS, email, and so on. Or you can use thresholds to trigger autoscaling functionality to scale to meet the demand.

#### Azure Log Analytics
This is the tool in the Azure portal where you can write and run log queries on the data gathered by Azure Monitor. It supports simple and complex queries and data analysis. 

#### Azure Monitor Alerts
This is an automated way to stay informed of custom thresholds. You can set the alert condition as well as notification actions, so you could even automate corrective actions. 

Alerts can be set up to monitor the logs and trigger on certain log events, or to monitor metrics and trigger when certain metrics are crossed. Action groups can be used to configure who to notify and what action to take. 

#### Application Insights
This feature of Azure Monitor monitors your web applications, whether they rune in Azure, on-premises, or in a different cloud invironment. 

You can either install an [[SDK]] in your application or use the Application Insights agent to configure App Insights. The agent is supported in [[1. Werk/2. Technische kennis/Languages/CS|C#]][[dotNET|.NET]], VB[[dotNET|.NET]], [[Java]], [[JavaScript]], [[Node.js]], and [[Python]].

Once Application Insights is up and running, you can use it to monitor a broad array of information, such as:
- Request rates, response times, and failure rates
- Dependency rates, response times, and failure rates, to show whether external services are slowing down performance
- Page views and load performance reported by users' browsers
- AJAX calls from web pages, including rates, response times, and failure rates
- User and session counts
- Performance counters from Windows or Linux server machines, such as CPU, memory, and network usage

Not only does Application Insights help you monitor the performance of your application, but you can also configure it to periodically send synthetic requests to your application, allowing you to check the status and monitor your application even during periods of low activity.

# Cloud concepts
## Cloud computing
Delivery of computing services over the internet with pay-as-you-go pricing model. 

* Lower your operating costs
* Run your infrastructure more efficiently
* Scale as your business needs to change

You rent CPUs and storage for the time that you need them, and the cloud provider takes care of the datacenters, infrastructure, etc. 

* Teams deliver new features to their users at record speeds
* Users expect an increasingly rich and immersive experience with their devices and with software

Software releases occur in smaller batches and at higher frequencies. You can even move to CI/CD. 

The cloud provides on-demand access to: 

* A nearly limitless pool of raw compute, storage, and networking components
* Speech recognition and other cognitive services that help make your application stand out from the crowd
* Analytics services that deliver telemetry data from your software and devices. 

## What is Azure?
Microsoft's cloud computing platform with:
- [[IAAS]]
- [[PAAS]]
- [[SAAS]]

![[Azure fundamentals.png]]

* **Be ready for the future:** Continuous innovation from Microsoft supports your development today and your product visions for tomorrow. 
* **Build on your terms:** You have choices. With a commitment to open source, and support for all languages and frameworks, you can build how you want and deploy where you want to.
* **Operate hybrid seamlessly:** On-premises, in the cloud, and at the edge--we'll meet you where you are. Integrate and manage your environments with tools and services designed for a hybrid cloud solution.
* **Trust your cloud:** Get security from the ground up, backed by a team of experts, and a proactive compliance trusted by enterprises, governments, and startups. 

Azure operates on an abstraction level by using [[Hypervisor]]s.

| Public cloud                                                          | Private cloud                                                      | Hybrid cloud                                                      | Multi-cloud                    |
| --------------------------------------------------------------------- | ------------------------------------------------------------------ | ----------------------------------------------------------------- | ------------------------------ |
| No capital expenditures to scale up                                   | Organizations have complete control over resources and security    | Provides the most flexibility                                     | Combination of multiple clouds |
| Applications can be quickly provisioned and deprovisioned             | Data is not collocated with other organizations’ data              | Organizations determine where to run their applications           |                                |
| Organizations pay only for what they use                              | Hardware must be purchased for startup and maintenance             | Organizations control security, compliance, or legal requirements |                                |
| Organizations don’t have complete control over resources and security | Organizations are responsible for hardware maintenance and updates |                                                                   |                                |

[[Azure Arc]] is a set of technologies that helps manage your cloud environment. Azure Arc can help manage your cloud environment, whether it's a public cloud solely on Azure, a private cloud in your datacenter, a hybrid configuration, or even a multi-cloud environment running on multiple cloud providers at once. 

[[Azure VMware Solution]] lets you run your [[Azure VMware Solution|VMware]] workloads in Azure while you are migrating to a public or hybrid cloud. 

## Payment structures
1. [[CapEx|Capital expenditure (CapEx)]] is a one-time, up-front expenditure to purchase or secure tangible resources, such as hardware or infrastructure. 
2. [[OpEx|Operational expenditure (OpEx)]] is spending money on services or products over time, such as rent or maintenance. 

Cloud computing falls under [[OpEx]] because cloud computing operates on a consumption-based model. You don't pay for the datacenter, but for the IT resources you use. 

## Metrics
### High availability
This metric describes the uptime [[SLA|Service Level Agreement (SLA)]]s, which is measured in percentage of uptime (100% is permanent up). Compare that with a full month to see the 'acceptable' downtime per month in hours, minutes, etc.

### Scalability
This metric describes the ability to adjust resources to meet demands, which means you can meet sudden demand upticks while not paying for resources you don't use.

#### Vertical scaling
Scaling focused on increasing or decreasing the capabilities of resources. For example, scaling up or down the CPU or RAM for your [[VM|VM (Virtual machine)]]. 

#### Horizontal scaling
Scaling by adding or subtracting the number of resources. For example, adding extra virtual machines or containers for peak log-in times. 

### Reliability
The ability of a system to recover from failures and continue to function. One of the pillars of the [[Microsoft Azure Well-Architected Framework]]. The decentralized nature of cloud services lets you shift from failing resources to available resources around the globe. In some cases, this will even happen automatically. 

### Predictability
There are two key facets of predictability that can be measured. 

#### Performance
Performance predictability focuses on predicting the resources needed. Autoscaling, load balancing and high availability are some cloud concepts that support performance predictability. 

#### Cost
Cost predictability is focused on predicting or forecasting the cost of the cloud spending. With the cloud, you can track your resource use in real time, monitor resources to ensure efficiency, and apply data analyitics to find patterns and trends that help plan resource deployments. You can even use tools like the [[Total Cost of Ownership (TCO)]] or Pricing Calculator to get an estimate of potential cloud spending. 

### Manageability
#### Management of the cloud
-   Automatically scale resource deployment based on need.
-   Deploy resources based on a preconfigured template, removing the need for manual configuration.
-   Monitor the health of resources and automatically replace failing resources.
-   Receive automatic alerts based on configured metrics, so you’re aware of performance in real time.

#### Management in the cloud
-   Through a web portal.
-   Using a command line interface.
-   Using APIs.
-   Using PowerShell.

## Levels of responsibility
### [[IAAS|IAAS (Infrastructure As A Service)]]
The cloud provider is responsible for maintaining the hardware, network connectivity, and physical security. You are responsible for everything else: [[1. Werk/2. Technische kennis/Algemene concepten/OS|OS (Operating system)]], installation, configuration, maintenance, databases, etc. You are effectively renting hardware in a datacenter to do with as you please.

Some common scenarios where IaaS might make sense include:
-   Lift-and-shift migration: You’re standing up cloud resources similar to your on-prem datacenter, and then simply moving the things running on-prem to running on the IaaS infrastructure.
-   Testing and development: You have established configurations for development and test environments that you need to rapidly replicate. You can stand up or shut down the different environments rapidly with an IaaS structure, while maintaining complete control.

### [[PAAS|PAAS (Platform As A Service)]]
The cloud provider maintains the physical infrastructure, physical security and connection to the internet. They also maintain the operating systems, middleware, development tools, and business intelligence that make up a cloud solution. You don't have to worry about licensing or patching for operating systems and databases. Think of it like using a domain joined machine: IT maintains the device with regular updates, patches, and refreshes. 

Depending on the configuration, you or the cloud provider may be responsible for networking settings and connectivity within your cloud environment, network and application security, and the directory infrastructure.

Some common scenarios where PaaS might make sense include:
-   Development framework: PaaS provides a framework that developers can build upon to develop or customize cloud-based applications. Similar to the way you create an Excel macro, PaaS lets developers create applications using built-in software components. Cloud features such as scalability, high-availability, and multi-tenant capability are included, reducing the amount of coding that developers must do.
-   Analytics or business intelligence: Tools provided as a service with PaaS allow organizations to analyze and mine their data, finding insights and patterns and predicting outcomes to improve forecasting, product design decisions, investment returns, and other business decisions.

### [[SAAS|SAAS (Software As A Service)]]
You are essentially renting or using a fully developed application. Email, financial software, messaging applications, and connectivity software are all common examples. It is the least flexible, but also the easiest to get up and running. It requires the least amount of technical knowledge or expertise to fully employ. You are responsible for the data that you put into the system, the devices that you allow to connect, and the users that have access. Nearly everything else falls to the cloud provider. 

Some common scenarios for SaaS are:
-   Email and messaging.
-   Business productivity applications.
-   Finance and expense tracking.

# Compute and networking services
## Compute services
### Virtual machines
With Azure [[VM|VM (Virtual machine)]]s, you can create and use VMs in the cloud. VMs provide [[IAAS|IAAS (Infrastructure As A Service)]] as a virtualized server. You can run single VMs or group VMs together to provide high availability, scalability, and redundancy. Azure can also manage the grouping of VMs for you with features such as scale sets and availability sets. 

Some common examples or use cases for virtual machines include:
-   **During testing and development**. VMs provide a quick and easy way to create different OS and application configurations. Test and development personnel can then easily delete the VMs when they no longer need them.
-   **When running applications in the cloud**. The ability to run certain applications in the public cloud as opposed to creating a traditional infrastructure to run them can provide substantial economic benefits. For example, an application might need to handle fluctuations in demand. Shutting down VMs when you don't need them or quickly starting them up to meet a sudden increase in demand means you pay only for the resources you use.
-   **When extending your datacenter to the cloud**: An organization can extend the capabilities of its own on-premises network by creating a virtual network in Azure and adding VMs to that virtual network. Applications like SharePoint can then run on an Azure VM instead of running locally. This arrangement makes it easier or less expensive to deploy than in an on-premises environment.
-   **During disaster recovery**: As with running certain types of applications in the cloud and extending an on-premises network to the cloud, you can get significant cost savings by using an IaaS-based approach to disaster recovery. If a primary datacenter fails, you can create VMs running on Azure to run your critical applications and then shut them down when the primary datacenter becomes operational again.

When you provision a VM, you’ll also have the chance to pick the resources that are associated with that VM, including:
-   Size (purpose, number of processor cores, and amount of RAM)
-   Storage disks (hard disk drives, solid state drives, etc.)
-   Networking (virtual network, public IP address, and port configuration)

#### VM Scale sets
Virtual machine scale sets let you create and manage a group of identical, load-balanced VMs. Scale sets allow you to centrally manage, configure, and update a large number of VMs in minutes. The number of VM instances can automatically increase or decrease in response to demand, or you can set it to scale based on a defined schedule. Virtual machine scale sets also automatically deploy a load balancer to make sure that your resources are being used efficiently. With virtual machine scale sets, you can build large-scale services for areas such as compute, big data, and container workloads.

#### VM Availability sets
Availability sets are designed to ensure that VMs stagger updates and have varied power and network connectivity, preventing you from losing all your VMs with a single network or power failure. Availability sets do this by grouping VMs in two ways: update domain and fault domain.
-   **Update domain**: The update domain groups VMs that can be rebooted at the same time. This allows you to apply updates while knowing that only one update domain grouping will be offline at a time. All of the machines in one update domain will be updated. An update group going through the update process is given a 30-minute time to recover before maintenance on the next update domain starts.
-   **Fault domain**: The fault domain groups your VMs by common power source and network switch. By default, an availability set will split your VMs across up to three fault domains. This helps protect against a physical power or networking failure by having VMs in different fault domains (thus being connected to different power and networking resources).

#### Virtual desktop
A virtual desktop is another type of VM. See [[VDI|VDI (Virtual Desktop Infrastructure)]]. 

### Containers
### Azure functions
This is an event-driven, serverless compute option that doesn't require VMs or containers. An event wakes the function, alleviating the need to keep resources provisioned when there are no events. Functions are commonly used when you need to respond to an event (often via a REST request), timer, or message from another Azure service, and when that work can be completed quickly, within seconds or less. They scale automatically based on demand. You're only charged for the CPU time used while your function runs. 

Functions can be stateless or stateful. When they're stateless (the default), they behave as if they're restarted every time they respond to an event. When they're stateful (called Durable Functions), a context is passed through the function to track prior activity.

Functions are a key component of serverless computing. They're also a general compute platform for running any type of code. If the needs of the developer's app change, you can deploy the project in an environment that isn't serverless. This flexibility allows you to manage scaling, run on virtual networks, and even completely isolate the functions.

## App Services
App Services provide an alternative hosting solution for your applications that don't require maintaining your own [[VM|VM (Virtual machine)]] or containers. It enables you to build and host web apps, background jobs, mobile back-ends, and RESTful APIs in the programming language of your choice without managing infrastructure. It offers automatic scaling and high availability, and supports Windows and Linux. It enables automated deployments from GitHub, Azure DevOps, or any Git repo. 

Benefits:
* Deployment and management are integrated into the platform
* Endpoints can be secured
* Sites can be scaled quickly to handle high traffic loads
* The built-in load balancing and traffic manager provide high availability

### Web apps
App Service includes full support for hosting web apps by using ASP[[dotNET|.NET]], ASP[[dotNET|.NET]] Core, [[Java]], [[Ruby]], [[Node.js]], [[PHP]], or [[Python]]. You can choose either [[Windows]] or [[Linux]] as the host operating system.

### API apps
Much like hosting a website, you can build [[REST]]-based web [[API]]s by using your choice of language and framework. You get full Swagger support and the ability to package and publish your [[API]] in Azure Marketplace. The produced apps can be consumed from any HTTP- or HTTPS-based client.

### WebJobs
You can use the WebJobs feature to run a program (.exe, [[Java]], [[PHP]], [[Python]], or [[Node.js]]) or script (.cmd, .bat, [[PowerShell]], or [[Bash]]) in the same context as a web app, API app, or mobile app. They can be scheduled or run by a trigger. WebJobs are often used to run background tasks as part of your application logic.

### Mobile apps
Use the Mobile Apps feature of App Service to quickly build a back end for [[iOS]] and [[Android]] apps. With just a few actions in the Azure portal, you can:
-   Store mobile app data in a cloud-based [[SQL]] database.
-   Authenticate customers against common social providers, such as MSA, Google, Twitter, and Facebook.
-   Send push notifications.
-   Execute custom back-end logic in [[1. Werk/2. Technische kennis/Languages/CS|C#]] or [[Node.js]].
On the mobile app side, there's [[SDK]] support for native [[iOS]] and [[Android]], [[Xamarin]], and [[React native]] apps.

## Networking features
### Azure virtual networks
Azure virtual networks and virtual subnets enable Azure resources to communicate with each other, with users on the internet, and with on-premises client computers. It is an extention of your on-premises network with resources that link other resources. 

Azure virtual networking supports both public and private endpoints to enable communication between external or internal resources with other internal resources. 
* Public endpoints have a public IP address and can be accessed from anywhere in the worlds
* Private endpoints exist within a virtual network and have a private IP address from within the address space of that virtual network


#### Virtual network features
##### Isolation and segmentation
You can create multiple isolated virtual networks. You can define a private IP address space by using either public or private IP address ranges. The IP range only exists within the virutal network and isn't internet routable. You can divide that IP address space into subnets and allocate part of the defined address space to each subnet. For name resolution, you can use the name resolution service that's built into Azure. You can also configure the virtual netowrk to use either an internal or external DNS server. 

##### Internet communications
You can enable incoming connections from the internet by assigning a public IP address to an Azure resource, or putting the resource behind a public load balancer.

##### Communicate between Azure resources
You'll want to enable Azure resources to communicate securely with each other. You can do that in one of two ways:
- Virtual networks can connect not only VMs but other Azure resources, such as the App Service Environment for Power Apps, Azure Kubernetes Service, and Azure virtual machine scale sets.
- Service endpoints can connect to other Azure resource types, such as Azure SQL databases and storage accounts. This approach enables you to link multiple Azure resources to virtual networks to improve security and provide optimal routing between resources.

##### Communicate with on-premises resources
Azure virtual networks enable you to link resources together in your on-premises environment and within your Azure subscription. In effect, you can create a network that spans both your local and cloud environments. There are three mechanisms for you to achieve this connectivity:

- Point-to-site virtual private network connections are from a computer outside your organization back into your corporate network. In this case, the client computer initiates an encrypted VPN connection to connect to the Azure virtual network.
- Site-to-site virtual private networks link your on-premises VPN device or gateway to the Azure VPN gateway in a virtual network. In effect, the devices in Azure can appear as being on the local network. The connection is encrypted and works over the internet.
- Azure ExpressRoute provides a dedicated private connectivity to Azure that doesn't travel over the internet. ExpressRoute is useful for environments where you need greater bandwidth and even higher levels of security.

##### Route network traffic
By default, Azure routes traffic between subnets on any connected virtual networks, on-premises networks, and the internet. You also can control routing and override those settings, as follows:
- Route tables allow you to define rules about how traffic should be directed with custom route tables that control how packets are routed between subnets.
- Border Gateway Protocol (BGP) works with Azure VPN gateways, Azure Route Server, or Azure ExpressRoute to propagate on-premises BGP routes to Azure virtual networks.

##### Filter network traffic
Azure virtual networks enable you to filter traffic between subnets by using the following approaches:
- Network security groups are Azure resources that can contain multiple inbound and outbound security rules. You can define these rules to allow or block traffic, based on factors such as source and destination IP address, port, and protocol.
- Network virtual appliances are specialized VMs that can be compared to a hardened network appliance. A network virtual appliance carries out a particular network function, such as running a firewall or performing [[WAN|Wide-area network (WAN)]] optimization.

##### Connect virtual networks
You can link virtual networks together by using virtual network peering. Peering allows two virtual networks to connect directly to each other. Network traffic between peered networks is private, and travels on the Microsoft backbone network, never entering the public internet. Peering enables resources in each virtual network to communicate with each other. These virtual networks can be in separate regions, which allows you to create a global interconnected network through Azure.

[[UDR|User-defined routes (UDR)]] allow you to control the routing tables between subnets within a virtual network or between virtual networks. This allows for greater control over network traffic flow.

#### [[VPN|Virtual Private Network (VPN)]]
##### VPN Gateway
This is a type of virtual network gateway. Azure VPN Gateway instances are deployed in a dedicated subnet of the virtual network and enable the following connectivity: 
* Connect on-premises datacenters to virtual networks through a site-to-site connection
* Connect individual devices to virtual networks through a point-to-site connection
* Connect virtual networks to other virtual networks through a network-to-network connection

All data stransfer is encrypted inside a private tunnel as it crosses the internet. You can deploy only one VPN gateway in each virtual network. However, you can use one gateway to connect to multiple locations, including other virtual networks and on-premises datacenters. 

VPN gateways are either policy-based or route-based. The main difference is how traffic to be encrypted is specified. In Azure, both types of VPN gateways use a pre-shared key as the only method of authentication.

* Policy-based VPN gateways specify statically the IP address of packets that should be encrypted through each tunnel. This type of device evaluates every data packet against those sets of IP addresses to choose the tunnel where that packet is going to be sent through.
* In Route-based gateways, IPSec tunnels are modeled as a network interface or virtual tunnel interface. IP routing (either static routes or dynamic routing protocols) decides which one of these tunnel interfaces to use when sending each packet. Route-based VPNs are the preferred connection method for on-premises devices. They're more resilient to topology changes such as the creation of new subnets. 

Use a route-based VPN gateway if you need any of the following types of connectivity:
* Connections between virtual networks
* Point-to-site connections
* Multisite connections
* Coexistence with an Azure ExpressRoute gateway

If you're configuring a VPN to keep your information safe, you also want to be sure that it's a highly available and fault tolerant VPN configuration. There are a few ways to maximize the resiliency of your VPN gateway.

###### Active/standby
By default, VPN gateways are deployed as two instances in an active/standby configuration, even if you only see one VPN gateway resource in Azure. When planned maintenance or unplanned disruption affects the active instance, the standby instance automatically assumes responsibility for connections without any user intervention. Connections are interrupted during this failover, but they're typically restored within a few seconds for planned maintenance and within 90 seconds for unplanned disruptions.

###### Active/active
With the introduction of support for the [[BGP]] routing protocol, you can also deploy VPN gateways in an active/active configuration. In this configuration, you assign a unique public IP address to each instance. You then create separate tunnels from the on-premises device to each IP address. You can extend the high availability by deploying an additional VPN device on-premises.

###### ExpressRoute failover
Another high-availability option is to configure a VPN gateway as a secure failover path for ExpressRoute connections. ExpressRoute circuits have resiliency built in. However, they aren't immune to physical problems that affect the cables delivering connectivity or outages that affect the complete ExpressRoute location. In high-availability scenarios, where there's risk associated with an outage of an ExpressRoute circuit, you can also provision a VPN gateway that uses the internet as an alternative method of connectivity. In this way, you can ensure there's always a connection to the virtual networks.

###### Zone-redundant gateways
In regions that support availability zones, VPN gateways and ExpressRoute gateways can be deployed in a zone-redundant configuration. This configuration brings resiliency, scalability, and higher availability to virtual network gateways. Deploying gateways in Azure availability zones physically and logically separates gateways within a region while protecting your on-premises network connectivity to Azure from zone-level failures. These gateways require different gateway stock keeping units (SKUs) and use Standard public IP addresses instead of Basic public IP addresses.

### Azure DNS
Azure DNS is a hosting service for [[DNS|Domain Name System (DNS)]] domains that provides name resolution by using Microsoft Azure infrastructure. By hosting your domains in Azure, you can manage your DNS records using the same credentials, APIs, tools and billing as your other Azure services.

#### Reliability and performance
DNS domains in Azure DNS are hosted on Azure's global network of DNS name servers. It uses anycast networking, so each DNS query is answered by the closest available DNS server to provide fast performance and high availability for your domain. 

#### Security
Azure DNS is based on Azure Resource Manager, which provides features such as:
- Azure [[RBAC|Role-based access control (RBAC)]] to control who has access to specific actions for your organization
- Activity logs to monitor how a user in your organization modified a resource or to find an error when troubleshooting
- Resource locking to lock a subscription, resource group, or resource. Locking prevents other users in your organization from accidentally deleting or modifying critical resources

#### Ease of use
Azure DNS can manage DNS records for your Azure services and provide DNS for your external resources as well. Azure DNS is integrated in the Azure portal and uses the same credentials, support contract, and billing as your other Azure services. 

Because Azure DNS is running on Azure, it means you can manage your domains and records with the Azure portal, Azure [[PowerShell]] cmdlets, and the cross-platform Azure [[CLI]]. Application that require automated DNS management can integrate with the service by using the [[REST|REST API]] and [[SDK]]s. 

#### Customizable virtual networks with private domains
Azure DNS also supports private DNS domains. This feature allows you to use your own custom domain names in your private virtual networks, rather than being stuck with the Azure-provided names.

#### Alias records
Azure DNS also supports alias record sets. You can use an alias record set to refer to an Azure resource, such as an Azure public IP address, an Azure Traffic Manager profile, or an Azure [[CDN|Content Delivery Network (CDN)]] endpoint. If the IP address of the underlying resource changes, the alias record set seamlessly updates itself during DNS resolution. The alias record set points to the service instance, and the service instance is associated with an IP address. 

Note: Azure DNS cannot be used to purchase a domain name. 

### Azure ExpressRoute
Azure ExpressRoute lets you extend your on-premises networks into the Microsoft cloud over a private connection, with the help of a connectivity provider. This connection is an ExpressRoute Circuit. With ExpressRoute, you can establish connections to Microsoft cloud services, such as Microsoft Azure and Microsoft 365. This lets you connect offices, datacenters, or other facilities to the Microsoft cloud. Each location would have its own ExpressRoute circuit. 

Connectivity can be from an any-to-any (IP VPN) network, a point-to-point Ethernet network, or a virtual cross-connection through a connectivity provider at a colocation facility. ExpressRoute connections don't go over the public Internet. This allows ExpressRoute connections to offer more reliability, faster speeds, consistent latencies, and higher security than typical connections over the Internet. 

Some benefits: 
* Connectivity to Microsoft cloud services across all regions in the geopolitical region
* Global connectivity to Microsoft services across all regions with the ExpressRoute Global Reach
* Dynamic routing between your network and Microsoft via [[BGP|Border Gateway Protocol (BGP)]]
* Built-in redundancy in every peering location for higher reliability

ExpressRoute enables direct access to the following services in all regions: 
* Microsoft Office 365
* Microsoft Dynamics 365
* Azure compute services, such as Azure Virtual Machines
* Azure cloud servies, such as Azure Cosmos DB and Azure Storage

ExpressRoute supports four models that you can use to connect your on-premises network to the Microsoft cloud:
* CloudExchange colocation
* Point-to-point Ethernet connection
* Any-to-any connection
* Directly from ExpressRoute Sites

With ExpressRoute, your data doesn't travel over the public internet, so it's not exposed to the potential risks associated with internet communications. ExpressRoute is a private connection from your on-premises infrastructure to your Azure infrastructure. Even if you have an ExpressRoute connection, DNS queries, certificate revocation list checking, and Azure [[CDN|Content Delivery Network (CDN)]] requests are still sent over the public internet.

# Storage accounts
A storage account provides a unique namespace for your Azure Storage data that's accessible from anywhere in the world over HTTP or HTTPS. Data in this account is secure, highly available, durable, and massively scalable. 

When you create your storage account, you'll start by picking the storage account type. The type of account determines the storage services and redundancy options and has an impact on the use cases. Below is a list of redundancy options: 
* [[LRS|LRS (Locally redundant storage)]]
* [[GRS|Geo-redundant storage (GRS)]]
* [[RA-GRS|Read-access geo-redundant storage (RA-GRS)]] 
* [[ZRS|Zone-redundant storage (ZRS)]]
* [[GZRS|Geo-zone-redundant storage (GZRS)]]
* [[RA-GZRS|Read-access geo-zone-redundant storage (RA-GZRS)]] 

| Type                        | Supported services                                                                        | Redundancy options                                           | Usage                                                                                                                                                                                                                                        |
| --------------------------- | ----------------------------------------------------------------------------------------- | ------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Standard general-purpose v2 | Blob Storage (including Data Lake Storage), Queue Storage, Table Storage, and Azure Files | [[LRS]], [[GRS]], [[RA-GRS]], [[ZRS]], [[GZRS]], [[RA-GZRS]] | Standard storage account type for blobs, file shares, queues, and tables. Recommended for most scenarios using Azure Storage. If you want support for network file system (NFS) in Azure Files, use the premium file shares account type.    |
| Premium block blobs         | Blob Storage (including Data Lake Storage)                                                | [[LRS]], [[ZRS]]                                             | Premium storage account type for block blobs and append blobs. Recommended for scenarios with high transaction rates or that use smaller objects or require consistently low storage latency.                                                |
| Premium file shares         | Azure Files                                                                               | [[LRS]], [[ZRS]]                                             | Premium storage account type for file shares only. Recommended for enterprise or high-performance scale applications. Use this account type if you want a storage account that supports both Server Message Block (SMB) and NFS file shares. |
| Premium page blobs          | Page blobs only                                                                           | [[LRS]]                                                      | Premium storage account type for page blobs only.                                                                                                                                                                                            |

One of the benefits of using an Azure Storage Account is having a unique namespace in Azure for your data. In order to do this, every storage account in Azure must have a unique-in-Azure account name. The combination of the account name and the Azure Storage service endpoint forms the endpoints for your storage account. 

- Storage account names must be between 3 and 24 characters in length and may contain numbers and lowercase letters only.
- Your storage account name must me unique within Azure. No two storage accounts can have the same name. This supports the ability to have a unique, accessible namespace in Azure.

| Storage services       | Endpoint                                                |
| ---------------------- | ------------------------------------------------------- |
| Blob Storage           | `https://<storage-account-name>.blob.core.windows.net`  |
| Data Lake Storage Gen2 | `https://<storage-account-name>.dfs.core.windows.net`   |
| Azure Files            | `https://<storage-account-name>.file.core.windows.net`  |
| Queue Storage          | `https://<storage-account-name>.queue.core.windows.net` |
| Table Storage          | `https://<storage-account-name>.table.core.windows.net` |

Some benefits of Azure Storage services:
- **Durable and highly available**. Redundancy ensures that your data is safe if transient hardware failures occur. You can also opt to replicate data across data centers or geographical regions for additional protection from local catastrophes or natural disasters. Data replicated in this way remains highly available if an unexpected outage occurs.
- **Secure**. All data written to an Azure storage account is encrypted by the service. Azure Storage provides you with fine-grained control over who has access to your data.
- **Scalable**. Azure Storage is designed to be massively scalable to meet the data storage and performance needs of today's applications.
- **Managed**. Azure handles hardware maintenance, updates, and critical issues for you.
- **Accessible**. Data in Azure Storage is accessible from anywhere in the world over HTTP or HTTPS. Microsoft provides client libraries for Azure Storage in a variety of languages, including [[dotNET|.NET]], [[Java]], [[Node.js]], [[Python]], [[PHP]], [[Ruby]], [[Go]], and others, as well as a mature [[REST|REST API]]. Azure Storage supports scripting in Azure [[PowerShell]] or Azure [[CLI]]. And the Azure portal and Azure Storage Explorer offer easy visual solutions for working with your data.

## Azure blobs
This is an object storage solution for the cloud. It can store massive amounts of data, such as text or binary data. It is unstructured, meaning there are no restrictions on data types. It can manage thousands of simultaneous uploads, massive amounts of video data, constantly growing log files, and can be reached from anywhere with an internet connection. 

Ideal for:
- Serving images or documents directly to a browser
- Storing files for distributed access
- Streaming video and audio
- Storing data for backup and restore, disaster recovery, and archiving
- Storing data for analysis by an on-premises or Azure-hosted service

Objects in Blob storage can be accessed from anywhere in the world via URLs, the Azure Storage [[REST|REST API]], Azure [[PowerShell]], Azure [[CLI]], or an Azure Storage client library, which is available for multiple languages including [[dotNET|.NET]], [[Java]], [[Node.js]], [[Python]], [[PHP]], and [[Ruby]]. 

### Blob storage tiers
- **Hot access tier**: Optimized for storing data that is accessed frequently (for example, images for your website).
- **Cool access tier**: Optimized for data that is infrequently accessed and stored for at least 30 days (for example, invoices for your customers).
- **Archive access tier**: Appropriate for data that is rarely accessed and stored for at least 180 days, with flexible latency requirements (for example, long-term backups).

Some considerations:
- Only the hot and cool access tiers can be set at the account level. The archive access tier isn't available at the account level.
- Hot, cool and archive tiers can be set at the blob level, during or after upload.
- Data in the cool access tier can tolerate slightly lower availability, but still requires high durability, retrieval latency, and throughput characteristics similar to hot data. For cool data, a slightly lower availability [[SLA|Service Level Agreement (SLA)]] and higher access costs compared to hot data are acceptable trade-offs for lower storage costs. 
- Archive storage stores data offline and offers the lowest storage costs, but also the highest costs to rehydrate and access data.

## Azure files
Azure Files offers fully managed file shares in the cloud that are accessible via the industry standard [[1. Werk/2. Technische kennis/Algemene concepten/SMB|Server Message Block (SMB)]] or [[NFS|Network File System (NFS)]] protocols. Azure Files file shares can be mounted concurrently by cloud or on-premises deployments. SMB Azure file shares are accessible from Windows, Linux, and macOS clients. NFS Azure Files shares are accessible from Linux or macOS clients. Additionally, SMB Azure file shares can be cached on Windows Servers with Azure File Sync for fast access near where the data is being used.

Key benefits: 
- **Shared access**: Azure file shares support the industry standard [[1. Werk/2. Technische kennis/Algemene concepten/SMB|Server Message Block (SMB)]] and [[NFS|Network File System (NFS)]] protocols, meaning you can seamlessly replace your on-premises file shares with Azure file shares without worrying about application compatibility.
- **Fully managed**: Azure file shares can be created without the need to manage hardware or an [[1. Werk/2. Technische kennis/Algemene concepten/OS]]. This means you don't have to deal with patching the server OS with critical security upgrades or replacing faulty hard disks.
- **Scripting and tooling**: [[PowerShell]] cmdlets and Azure [[CLI]] can be used to create, mount, and manage Azure file shares as part of the administration of Azure applications. You can create and manage Azure file shares using Azure portal and Azure Storage Explorer.
- **Resiliency**: Azure Files has been built from the ground up to always be available. Replacing on-premises file shares with Azure Files means you don't have to wake up in the middle of the night to deal with local power outages or network issues.
- **Familiar programmability**: Applications running in Azure can access data in the share via file system I/O APIs. Developers can therefore leverage their existing code and skills to migrate existing applications. In addition to System IO APIs, you can use Azure Storage Client Libraries or the Azure Storage [[REST|REST API]].

## Azure queues
Azure Queue Storage is a service for storing large numbers of messages. Once stored, you can access the messages from anywhere in the world via authenticated calls using HTTP or HTTPS. A queue can contain as many messages as your storage account has room for (potentially millions). Each individual message can be up to 64 KB in size. Queues are commonly used to create a backlog of work to process asynchronously.

Queue storage can be combined with compute functions like Azure Functions to take an action when a message is received. For example, you want to perform an action after a customer uploads a form to your website. You could have the submit button on the website trigger a message to the Queue storage. Then, you could use Azure Functions to trigger an action once the message was received.

## Azure disks
Disk storage, or Azure managed disks, are block-level storage volumes managed by Azure for use with Azure [[VM]]s. Conceptually, they’re the same as a physical disk, but they’re virtualized – offering greater resiliency and availability than a physical disk. With managed disks, all you have to do is provision the disk, and Azure will take care of the rest.

# Data migration options
## Azure Migrate
This service helps you migrate from an on-premises environment to the cloud. It provides:
- **Unified migration platform**: A single portal to start, run, and track your migration to Azure.
- **Range of tools**: A range of tools for assessment and migration. Azure Migrate tools include Azure Migrate: Discovery and assessment and Azure Migrate: Server Migration. Azure Migrate also integrates with other Azure services and tools, and with [[ISV|Independent Software Vendor (ISV)]] offerings.
- **Assessment and migration**: In the Azure Migrate hub, you can assess and migrate your on-premises infrastructure to Azure.

In addition to working with tools from [[ISV]]s, the Azure Migrate hub includes the following tools to help with migration:
- **Azure Migrate: Discovery and assessment**. Discover and assess on-premises servers running on VMware, Hyper-V, and physical servers in preparation for migration to Azure.
- **Azure Migrate: Server Migration**. Migrate VMware VMs, Hyper-V VMs, physical servers, other virtualized servers, and public cloud VMs to Azure.
- **Data Migration Assistant**. Data Migration Assistant is a stand-alone tool to assess SQL Servers. It helps pinpoint potential problems blocking migration. It identifies unsupported features, new features that can benefit you after migration, and the right path for database migration.
- **Azure Database Migration Service**. Migrate on-premises databases to Azure VMs running SQL Server, Azure SQL Database, or SQL Managed Instances.
- **Web app migration assistant**. Azure App Service Migration Assistant is a standalone tool to assess on-premises websites for migration to Azure App Service. Use Migration Assistant to migrate [[dotNET|.NET]] and [[PHP]] web apps to Azure.
- **Azure Data Box**. Use Azure Data Box products to move large amounts of offline data to Azure.

### Azure Data Box
Azure Data Box is a physical migration service that helps transfer large amounts of data in a quick, inexpensive, and reliable way. The secure data transfer is accelerated by shipping you a proprietary Data Box storage device that has a maximum usable storage capacity of 80 terabytes. The Data Box is transported to and from your datacenter via a regional carrier. A rugged case protects and secures the Data Box from damage during transit.

You can order the Data Box device via the Azure portal to import or export data from Azure. Once the device is received, you can quickly set it up using the local web UI and connect it to your network. Once you’re finished transferring the data (either into or out of Azure), simply return the Data Box. If you’re transferring data into Azure, the data is automatically uploaded once Microsoft receives the Data Box back. The entire process is tracked end-to-end by the Data Box service in the Azure portal.

Data Box is ideally suited to transfer data sizes larger than 40 TBs in scenarios with no to limited network connectivity. The data movement can be one-time, periodic, or an initial bulk data transfer followed by periodic transfers.

Here are the various scenarios where Data Box can be used to import data to Azure.
- Onetime migration - when a large amount of on-premises data is moved to Azure.
- Moving a media library from offline tapes into Azure to create an online media library.
- Migrating your VM farm, SQL server, and applications to Azure.
- Moving historical data to Azure for in-depth analysis and reporting using HDInsight.
- Initial bulk transfer - when an initial bulk transfer is done using Data Box (seed) followed by incremental transfers over the network.
- Periodic uploads - when large amount of data is generated periodically and needs to be moved to Azure.

Here are the various scenarios where Data Box can be used to export data from Azure.
- Disaster recovery - when a copy of the data from Azure is restored to an on-premises network. In a typical disaster recovery scenario, a large amount of Azure data is exported to a Data Box. Microsoft then ships this Data Box, and the data is restored on your premises in a short time.
- Security requirements - when you need to be able to export data out of Azure due to government or security requirements.
- Migrate back to on-premises or to another cloud service provider - when you want to move all the data back to on-premises, or to another cloud service provider, export data via Data Box to migrate the workloads.

Once the data from your import order is uploaded to Azure, the disks on the device are wiped clean in accordance with NIST 800-88r1 standards. For an export order, the disks are erased once the device reaches the Azure datacenter.

## AzCopy
AzCopy is a command-line utility that you can use to copy blobs or files to or from your storage account. With AzCopy, you can upload files, download files, copy files between storage accounts, and even synchronize files. AzCopy can even be configured to work with other cloud providers to help move files back and forth between clouds.

Synchronizing blobs or files with AzCopy is one-direction synchronization. When you synchronize, you designated the source and destination, and AzCopy will copy files or blobs in that direction. It doesn't synchronize bi-directionally based on timestamps or other metadata.

## Azure Storage Explorer
Azure Storage Explorer is a standalone app that provides a graphical interface to manage files and blobs in your Azure Storage Account. It works on Windows, macOS, and Linux operating systems and uses AzCopy on the backend to perform all of the file and blob management tasks. With Storage Explorer, you can upload to Azure, download from Azure, or move between storage accounts.

## Azure File Sync
Azure File Sync is a tool that lets you centralize your file shares in Azure Files and keep the flexibility, performance, and compatibility of a Windows file server. It’s almost like turning your Windows file server into a miniature content delivery network. Once you install Azure File Sync on your local Windows server, it will automatically stay bi-directionally synced with your files in Azure.

With Azure File Sync, you can:
- Use any protocol that's available on Windows Server to access your data locally, including SMB, NFS, and FTPS.
- Have as many caches as you need across the world.
- Replace a failed local server by installing Azure File Sync on a new server in the same datacenter.
- Configure cloud tiering so the most frequently accessed files are replicated locally, while infrequently accessed files are kept in the cloud until requested.

# Azure [[AD|Active Directory (AD)]]
Azure Active Directory (Azure AD) is a directory service that enables you to sign in and access both Microsoft cloud applications and cloud applications that you develop. Azure AD can also help you maintain your on-premises Active Directory deployment.

For on-premises environments, Active Directory running on Windows Server provides an identity and access management service that's managed by your organization. Azure AD is Microsoft's cloud-based identity and access management service. When you connect Active Directory with Azure AD, Microsoft can help protect you by detecting suspicious sign-in attempts at no extra cost. For example, Azure AD can detect sign-in attempts from unexpected locations or unknown devices.

Target audience:
- **IT administrators**. Administrators can use Azure AD to control access to applications and resources based on their business requirements.
- **App developers**. Developers can use Azure AD to provide a standards-based approach for adding functionality to applications that they build, such as adding SSO functionality to an app or enabling an app to work with a user's existing credentials.
- **Users**. Users can manage their identities and take maintenance actions like self-service password reset.
- **Online service subscribers**. Microsoft 365, Microsoft Office 365, Azure, and Microsoft Dynamics CRM Online subscribers are already using Azure AD to authenticate into their account.

Available services:
- **Authentication**: This includes verifying identity to access applications and resources. It also includes providing functionality such as self-service password reset, multifactor authentication, a custom list of banned passwords, and smart lockout services.
- **Single sign-on**: Single sign-on (SSO) enables you to remember only one username and one password to access multiple applications. A single identity is tied to a user, which simplifies the security model. As users change roles or leave an organization, access modifications are tied to that identity, which greatly reduces the effort needed to change or disable accounts.
- **Application management**: You can manage your cloud and on-premises apps by using Azure AD. Features like Application Proxy, SaaS apps, the My Apps portal, and single sign-on provide a better user experience.
- **Device management**: Along with accounts for individual people, Azure AD supports the registration of devices. Registration enables devices to be managed through tools like Microsoft Intune. It also allows for device-based Conditional Access policies to restrict access attempts to only those coming from known devices, regardless of the requesting user account.

If you connect your on-premises [[AD|Active Directory (AD)]] with Azure AD, you can synchronise the identity sets with Azure AD Connect for a consistent experience. 

Azure [[AD]] [[DS|Domain Services (DS)]] provices managed domain services such as domain join, group policy, [[LDAP]], and [[Kerberos]]/[[NTLM]] authentication. You get the benefit of domain services without the need to deploy, manage, and patch [[Domain Controller]]s in the cloud. It also lets you run legacy applications in the cloud that cannot use moder authentication methods, or as an obfuscation layer to your on-premises directories. You can lift these applications into a (fenced off) managed domain. Azure [[AD]] [[DS]] integrates with your existing Azure [[AD]] tenant, so sign in is shared. 

When you create a managed domain, you define a unique namespace. This is the domain name. Two Windows Server [[Domain Controller]]s are deployed, known as a replica set. You don't need to manage these. 

Azure [[AD]] works with one-way synchronisation from your on-premises configuration to the cloud. Anything created in the cloud is cloud-only, whereas anything created on-premises is synched to the cloud. 

![[Azure fundamentals 9.png]]

## Authentication methods
![[Azure fundamentals 10.png]]

### [[SSO|SSO (Single Sign-On)]]
Azure supports single sign-on, which allows the user to sign in one time and use that credential to access multiple resources and applications form different providers. Single sign-on is only as secure as the initial authenticator because the subsequent connections are all based on the security of the initial authenticator. Think for instance of using your Windows login credentials for all apps opened on the virtual desktop. 

### [[MFA|Multifactor Authentication (MFA)]]
You know what this is.

### Passwordless authentication
Using an authentication method or combination of authentication methods that isn't, you know, passwords. Like an [[RFID]] token or an authenticator app. 

## External Identities
![[Azure fundamentals 11.png]]

With external identities, users can authenticate with external credentials that are linked to their user within the Azure AD. Think for instance of logging in with Google or Facebook. 

- **Business to business (B2B) collaboration** - Collaborate with external users by letting them use their preferred identity to sign-in to your Microsoft applications or other enterprise applications (SaaS apps, custom-developed apps, etc.). B2B collaboration users are represented in your directory, typically as guest users.
- **B2B direct connect** - Establish a mutual, two-way trust with another Azure AD organization for seamless collaboration. B2B direct connect currently supports Teams shared channels, enabling external users to access your resources from within their home instances of Teams. B2B direct connect users aren't represented in your directory, but they're visible from within the Teams shared channel and can be monitored in Teams admin center reports.
- **Azure AD business to customer (B2C)** - Publish modern SaaS apps or custom-developed apps (excluding Microsoft apps) to consumers and customers, while using Azure AD B2C for identity and access management.

Depending on how you want to interact with external organizations and the types of resources you need to share, you can use a combination of these capabilities. Guest users from other tenants can be invited by administrators or by other users. 

You also can easily ensure that guest users have appropriate access. You can ask the guests themselves or a decision maker to participate in an access review and recertify (or attest) to the guests' access. The reviewers can give their input on each user's need for continued access, based on suggestions from Azure AD. When an access review is finished, you can then make changes and remove access for guests who no longer need it.

## Conditional access
Azure [[AD]] uses this tool to allow (or deny) access to resources based on identity signals. These signals include who the user is, where the user is, and what device the user is requesting access from.  This lets IT admins enable [[BYOD]] while protecting the organization's assets. It also provides a more granular [[MFA]] experience. For example, a user might need only 1 authentication method while at a known location on a familiar device. 

![[Azure fundamentals 12.png]]

The signal might be the user's location, the user's device, or the application that the user is trying to access.

Conditional Access is useful when you need to:
- Require multifactor authentication (MFA) to access an application depending on the requester’s role, location, or network. For example, you could require MFA for administrators but not regular users or for people connecting from outside your corporate network.
- Require access to services only through approved client applications. For example, you could limit which email applications are able to connect to your email service.
- Require users to access your application only from managed devices. A managed device is a device that meets your standards for security and compliance.
- Block access from untrusted sources, such as access from unknown or unexpected locations.

## Role-based access control
Managing least-privilege access to a growing ecosystem of resources can get very tedious very fast, so Azure enables you to control access through Azure role-based access control (Azure [[RBAC]]). Azure provides built-in roles that describe common access rules for cloud resources. You can also define your own roles.

Here is an overview of different roles and their access rights.
![[Azure fundamentals 13.png]]

Azure [[RBAC]] is hierarchical, in that when you grant access at a parent scope, those permissions are inherited by all child scopes. Azure [[RBAC]] is enforced on any action that's initiated against an Azure resource that passes through Azure Resource Manager. Resource Manager is a management service that provides a way to organize and secure your cloud resources.

## Zero trust
The Zero Trust security model is based on these guiding principles:
- **Verify explicitly** - Always authenticate and authorize based on all available data points.
- **Use least privilege access** - Limit user access with Just-In-Time and Just-Enough-Access (JIT/JEA), risk-based adaptive policies, and data protection.
- **Assume breach** - Minimize blast radius and segment access. Verify end-to-end encryption. Use analytics to get visibility, drive threat detection, and improve defenses.

![[Azure fundamentals 14.png]]

## Defense-in-depth
![[Azure fundamentals 15.png]]
You're only as safe as your weakest access route, so layer that shit. 

### Physical security
The fence. The building. The lock. 

### Identity & Access
The identity and access layer is all about ensuring that identities are secure, that access is granted only to what's needed, and that sign-in events and changes are logged.

At this layer, it's important to:
- Control access to infrastructure and change control.
- Use single sign-on (SSO) and multifactor authentication.
- Audit events and changes.

### Perimeter
The network perimiter protects from network-based attacks. At this layer, it's important to:
- Use [[DDoS]] protection to filter large-scale attacks before they can affect the availability of a system for users
- Use perimeter firewalls to identify and alert on malicious attacks against your network

### Network
At this layer, it's important to:
- Limit communication between resources.
- Deny by default.
- Restrict inbound internet access and limit outbound access where appropriate.
- Implement secure connectivity to on-premises networks.

### Compute
This layer is about the compute services such as virtual machines and containers. At this layer, it's important to:
- Secure access to virtual machines.
- Implement endpoint protection on devices and keep systems patched and current

### Application
At this layer, it's important to:
- Ensure that applications are secure and free of vulnerabilities.
- Store sensitive application secrets in a secure storage medium.
- Make security a design requirement for all application development.

### Data
In almost all cases, attackers are after data:
-   Stored in a database.
-   Stored on disk inside virtual machines.
-   Stored in software as a service ([[SAAS]]) applications, such as Office 365.
-   Managed through cloud storage.

## Microsoft Defender for Cloud
Defender for Cloud is a monitoring tool for security posture management and threat protection. It monitors your cloud, on-premises, hybrid, and multicloud environments to provide guidance and notifications aimed at strengthening your security posture.

Defender for Cloud provides the tools needed to harden your resources, track your security posture, protect against cyber attacks, and streamline security management. Deployment of Defender for Cloud is easy, it’s already natively integrated to Azure.

Many Azure services are monitored and protected without needing any deployment. However, if you also have an on-premises datacenter or are also operating in another cloud environment, monitoring of Azure services may not give you a complete picture of your security situation.

When necessary, Defender for Cloud can automatically deploy a Log Analytics agent to gather security-related data. For Azure machines, deployment is handled directly. For hybrid and multicloud environments, Microsoft Defender plans are extended to non Azure machines with the help of Azure Arc. Cloud security posture management (CSPM) features are extended to multicloud machines without the need for any agents.

Defender for Cloud helps you detect threats across:
- Azure [[PAAS]] services – Detect threats targeting Azure services including Azure App Service, Azure SQL, Azure Storage Account, and more data services. You can also perform anomaly detection on your Azure activity logs using the native integration with Microsoft Defender for Cloud Apps (formerly known as Microsoft Cloud App Security).
- Azure data services – Defender for Cloud includes capabilities that help you automatically classify your data in Azure SQL. You can also get assessments for potential vulnerabilities across Azure SQL and Storage services, and recommendations for how to mitigate them.
- Networks – Defender for Cloud helps you limit exposure to brute force attacks. By reducing access to virtual machine ports, using the just-in-time VM access, you can harden your network by preventing unnecessary access. You can set secure access policies on selected ports, for only authorized users, allowed source IP address ranges or IP addresses, and for a limited amount of time.

In addition to defending your Azure environment, you can add Defender for Cloud capabilities to your hybrid cloud environment to protect your non-Azure servers. To help you focus on what matters the most, you'll get customized threat intelligence and prioritized alerts according to your specific environment. To extend protection to on-premises machines, deploy Azure Arc and enable Defender for Cloud's enhanced security features.

Defender for Cloud fills three vital needs as you manage the security of your resources and workloads in the cloud and on-premises:
- Continuously assess – Know your security posture. Identify and track vulnerabilities.
- Secure – Harden resources and services with Azure Security Benchmark.
- Defend – Detect and resolve threats to resources, workloads, and services.
![[Azure fundamentals 16.png]]

To help you understand how important each recommendation is to your overall security posture, Defender for Cloud groups the recommendations into security controls and adds a secure score value to each control. The secure score gives you an at-a-glance indicator of the health of your security posture, while the controls give you a working list of things to consider to improve your security score and your overall security posture.

![[Azure fundamentals 17.png]]

When Defender for Cloud detects a threat in any area of your environment, it generates a security alert. Security alerts:
- Describe details of the affected resources
- Suggest remediation steps
- Provide, in some cases, an option to trigger a logic app in response