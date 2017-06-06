# ccminerGUI
A GUI for the CCMiner for People mining on Coinotron

Required:<br />
<li>
<ul>
  Windows Machine
  </ul>
<ul>
  .net Framework 4.5.2
  </ul>
<ul>
  ccminer
  </ul>
</li>
  
Optional:<br />
<li>
<ul>
  Feathercoin Wallet (For Balance and total Value of your Coins)
  </ul>
<ul>
  coinotron as your Pool (For Netto Hashrate)
  </ul>
<ul>
  or p2pool
  </ul>
</li>

Config File (ccminerGUI.exe.config)

    <add key="ccminerArgs" value="-a neoscrypt -i 15 -o stratum+tcp://coinotron.com:3337 -u user.worker -p pass"/>
    <add key="CoinotronAPI" value="Put your API Key here or leave blanc for ignore" />
    <add key="CoinotronWorker" value="the Worker to observe leave blanc for ignore" />
    <add key="Currency" value="eur" />
    <add key="FeathercoinWalletAddress" value="if you want to display it leave blanc for ignore" />
    <add key="p2poolAddress" value="your p2pool address like http://poolip:port" />
