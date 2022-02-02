# Power App Kiosk
This app was build to demonstrate how [Selenium](https://www.selenium.dev/) can be used to interact with the edge browser in Kiosk mode.

This console application can be used to launch a Power App in a Kiosk style mode.  After opening the browser it will navigate to the Power App and then authenticate using the browser (this will not work if two-factor auth is enabled).

## Config
The Power App Url, username, and password are stored in a config file.  On the first run of the app the config file will be encrypted.  To set the values of the config file follow these directions.

DO NOT put your credentials in the primary App.Config!!! 

Instead create local config files that will not be tracked in Git.  To create App.config specific to your release types you can utilize the SlowCheetah extension for Visual Studio. [SlowCheetah Extension Download](https://marketplace.visualstudio.com/items?itemName=vscps.SlowCheetah-XMLTransforms).  

After it is installed right click on the main App.Config file and select **Add Transform**.  Rename the new file based upon your release configuration, eg. App.Debug.config.  The .gitignore file within this project has been updated to not track these files.

![Add App.Config Transformation](https://user-images.githubusercontent.com/7444929/152234439-1aa19037-573c-44c5-8efd-9ff7ce84016e.png)

After you have created your release specific config files you can now update them with the Power App url and username/password.

![Update Config File](https://user-images.githubusercontent.com/7444929/152234796-395c6d7a-8ccd-4581-9f96-339679cbb03d.png)

## Run
After you have updated the configuration file just run the PowerAppKiosk.exe file to launch.


