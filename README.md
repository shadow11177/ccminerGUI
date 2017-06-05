# ccminerGUI
A GUI for the CCMiner for People mining on Coinotron

Initial Upload done.

Required:
  Windows Machine
  .net Framework 4.5.2
  ccminer
  
Optional:
  Feathercoin Wallet (For Balance and total Value of your Coins)
  coinotron as your Pool (For Netto Hashrate)
  

Config File (ccminerGUI.exe.config)
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
    </startup>
  <appSettings>
    <add key="ccminerArgs" value="-a neoscrypt -i 15 -o stratum+tcp://coinotron.com:3337 -u user.worker -p pass"/>
    <add key="CoinotronAPI" value="Put your API Key here or leave blanc for ignore" />
    <add key="CoinotronWorker" value="the Worker to observe leave blanc for ignore" />
    <add key="Currency" value="eur" />
    <add key="FeathercoinWalletAddress" value="if you want to display it leave blanc for ignore" />
  </appSettings>
</configuration>
