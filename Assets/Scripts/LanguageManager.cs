using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{

    [SerializeField]
    private GameObject SLOInstructions;

    [SerializeField]
    private GameObject ENGInstructions;

    public static bool translation = false;


    void Start()
    {

        translation = PlayerPrefs.GetString("translation") == "True";
        print(PlayerPrefs.GetString("translation"));
        if (translation)
        {
            SLOInstructions.SetActive(true);
            ENGInstructions.SetActive(false);
        }
        else
        {
            SLOInstructions.SetActive(false);
            ENGInstructions.SetActive(true);
        }
    }

}
