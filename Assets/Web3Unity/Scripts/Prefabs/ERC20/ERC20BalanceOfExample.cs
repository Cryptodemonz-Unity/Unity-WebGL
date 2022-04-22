using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ERC20BalanceOfExample : MonoBehaviour
{

    public Text BALANCETXT;
    public void BalanceCheck_button()
    {

        Balance_Check();
    }
    async void Balance_Check()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = "0x8ab893e33B2CFfF425fF9C67B958036C938A2649";
        string account = PlayerPrefs.GetString("Account");

        BigInteger balanceOf = await ERC20.BalanceOf(chain, network, contract, account);
        print(balanceOf);
        BALANCETXT.text = balanceOf.ToString();
    }
}
