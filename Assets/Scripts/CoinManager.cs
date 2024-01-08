using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField]
    public TMPro.TextMeshProUGUI coinsUIText;

    private int coinsValue = 0;

    public void increaseCoins(int value)
    {
        coinsValue = coinsValue + value;
        //Update UI
        coinsUIText.text = coinsValue.ToString();
    }

    public void decreaseCoins(int value)
    {
        coinsValue = coinsValue - value;
        //Update UI
        coinsUIText.text = coinsValue.ToString();
    }
}
