using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
public class AllErc721Example : MonoBehaviour
{

    public Text NFT_BALANCE_CHECK_TXT;
    private class NFTs
    {
        public string contract { get; set; }
        public string tokenId { get; set; }
        public string uri { get; set; }
        public string balance { get; set; }
    }
    public void NFT_ERC_721_CHECK_BUTTON()
    {
        NFT_ERC_721_CHECK();
    }
    async void NFT_ERC_721_CHECK()
    {
        string chain = "ethereum";
        string network = "mainnet"; // mainnet ropsten kovan rinkeby goerli
        string account = PlayerPrefs.GetString("Account");
        string contract = "0xAE16529eD90FAfc927D774Ea7bE1b95D826664E3";
        string response = await EVM.AllErc721(chain, network, account, contract);

        Debug.Log($"Account {account}");
        Debug.Log($"Response {response}");

        string balance = "";

        try
        {
            NFTs[] erc721s = JsonConvert.DeserializeObject<NFTs[]>(response);
            print(erc721s[0].contract);
            print(erc721s[0].tokenId);
            print(erc721s[0].uri);
            print(erc721s[0].balance);

            balance = erc721s[0].balance.ToString();
        }
        catch
        {
           print("Error: " + response);
        }

        if( NFT_BALANCE_CHECK_TXT ) NFT_BALANCE_CHECK_TXT.text = balance;
    }
}
