# Power-App-Kiosk
This console application can be utilized to launch a Power App in a Kiosk style mode.  It uses [Selenium](https://www.selenium.dev/) to open a new Edge browser.  After opening the browser it will navigate to the Power App and then authenticate using the browser (this will not work if two-factor auth is enabled).


## Config
The Power App Url, username, and password are stored in a config file.  On the first run of the app the config file will be encrypted.  To set the values of the config file follow these directions.

DO NOT put your credentials in the primary App.Config!!! 

Instead create local config files that will not be tracked in Git.  To create App.config specific to your release types you can utilize the SlowCheetah extension for Visual Studio. [SlowCheetah Extension Download](https://marketplace.visualstudio.com/items?itemName=vscps.SlowCheetah-XMLTransforms).  

After it is installed right click on the main App.Config file and select **Add Transform**.  Rename the new file based upon your release configuration, eg. App.Debug.config.  The .gitignore file within this project has been updated to not track these files.


