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

    <add key="ccminerArgs" value="-a neoscrypt -i 15 -o stratum+tcp://coinotron.com:3337 -u user.worker -p pass"/>
    <add key="CoinotronAPI" value="Put your API Key here or leave blanc for ignore" />
    <add key="CoinotronWorker" value="the Worker to observe leave blanc for ignore" />
    <add key="Currency" value="eur" />
    <add key="FeathercoinWalletAddress" value="if you want to display it leave blanc for ignore" />
