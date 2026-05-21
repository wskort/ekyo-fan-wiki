---
tags: Techniek
---
# Task 1: Create a Linux virtual machine and install Nginx
Use the following Azure CLI commands to create a Linux VM and install Nginx. After your VM is created, you'll use the Custom Script Extension to install Nginx. The Custom Script Extension is an easy way to download and run scripts on your Azure VMs. It's just one of the many ways you can configure the system after your VM is up and running.

1. From Cloud Shell, run the following `az vm create` command to create a Linux VM:
```bash
az vm create \
  --resource-group learn-e6c62ae4-1ce2-413f-a2fa-88ca31802dcb \
  --name my-vm \
  --image UbuntuLTS \
  --admin-username azureuser \
  --generate-ssh-keys
```
Your VM will take a few moments to come up. You name the VM **my-vm**. You use this name to refer to the VM in later steps.

2. Run the following `az vm extension set` command to configure Nginx on your VM:
```bash
az vm extension set \
  --resource-group learn-e6c62ae4-1ce2-413f-a2fa-88ca31802dcb \
  --vm-name my-vm \
  --name customScript \
  --publisher Microsoft.Azure.Extensions \
  --version 2.1 \
  --settings '{"fileUris":["https://raw.githubusercontent.com/MicrosoftDocs/mslearn-welcome-to-azure/master/configure-nginx.sh"]}' \
  --protected-settings '{"commandToExecute": "./configure-nginx.sh"}'
```
This command uses the Custom Script Extension to run a Bash script on your VM. The script is stored on GitHub. While the command runs, you can choose to [examine the Bash script](https://raw.githubusercontent.com/MicrosoftDocs/mslearn-welcome-to-azure/master/configure-nginx.sh) from a separate browser tab. To summarize, the script:
a. Runs `apt-get update` to download the latest package information from the internet. This step helps ensure that the next command can locate the latest version of the Nginx package.
b. Installs Nginx.
c. Sets the home page, _/var/www/html/index.html_, to print a welcome message that includes your VM's host name.