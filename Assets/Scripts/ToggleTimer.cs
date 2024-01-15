using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTimer : MonoBehaviour
{

    private bool isFreePlayEnabled;
    public void setFreePlay(bool status)
    {
        isFreePlayEnabled = status;
    }


    void OnDisable()
    {
        PlayerPrefs.SetString("isFreePlayEnabled", isFreePlayEnabled.ToString());
    }


}
