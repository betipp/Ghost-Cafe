using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;


public class PourableDrink : MonoBehaviour
{
    private bool onPrepStation;
    private bool isFilled;
    private float fillTime = 0;
    private float timeToCook = 5;
    public List<string> prepStation = new List<string>();

    GameObject drinkMachine;

    GameObject GameManager;

    GameObject drinkStream = null;

    [SerializeField]
    private GameObject lid;




    void Start()
    {
        //drinkMachine = GameObject.Find(prepStation);
        GameManager = GameObject.Find("GameManager");
    }


    void OnTriggerEnter(Collider collisionInfo)
    {
        if (prepStation.Contains(collisionInfo.gameObject.tag))
        {
            onPrepStation = true;
            drinkStream = collisionInfo.gameObject;
            this.gameObject.transform.position = drinkStream.GetComponent<DrinkStream>().stationCupPosition.gameObject.transform.position;
            this.gameObject.transform.rotation = drinkStream.GetComponent<DrinkStream>().stationCupPosition.gameObject.transform.rotation;
            this.GetComponent<SpawnObjectManager>().spawnNewObject();
        }
    }
    void OnTriggerExit(Collider collisionInfo)
    {
        if (prepStation.Contains(collisionInfo.gameObject.tag))
        {
            onPrepStation = false;
            drinkStream = null;
        }

    }
    void Update()
    {
        if (onPrepStation && !isFilled && isLiquidPouringOnStream())
        {
            fillTime += Time.deltaTime;

            if (fillTime >= timeToCook)
            {
                isFilled = true;
                if (this.tag != "Moldy")
                {
                    this.tag = "Prepered";
                }
                this.name = drinkStream.GetComponent<DrinkStream>().liquid + "Shake";
                showLiquid("high", true);
            }
            else if (fillTime >= timeToCook / 3 * 2)
            {
                showLiquid("medium", false);
            }
            else if (fillTime >= timeToCook / 3)
            {
                showLiquid("low", false);
            }
        }
    }

    void setLiquidLevels(String level, GameObject liquid, string liquidName)
    {
        Vector3 pos = liquid.transform.localPosition;


        if (liquidName == "Coffee")
        {
            switch (level)
            {
                case "low":
                    pos.y = -0.413f;
                    break;
                case "medium":
                    pos.y = 0.097f;
                    break;
                case "high":
                    pos.y = 0.4458094f;
                    break;
            }
        }
        else
        {
            switch (level)
            {
                case "low":
                    pos.y = -0.839f;
                    liquid.transform.localScale = new Vector3(0.87626f, 0.2485486f, 0.87626f);
                    break;
                case "medium":
                    pos.y = -0.55f;
                    liquid.transform.localScale = new Vector3(0.87626f, 0.5180995f, 0.87626f);
                    break;
                case "high":
                    pos.y = 0;
                    liquid.transform.localScale = new Vector3(1, 1, 1);
                    break;
            }
        }
        liquid.transform.localPosition = pos;

    }

    bool isLiquidPouringOnStream()
    {
        if (drinkStream != null)
        {
            return drinkStream.GetComponent<DrinkStream>().getIsPouring();
        }
        return false;
    }

    void showLiquid(string liquidLevel, bool showLid)
    {
        EnableChildWithName(this.gameObject, drinkStream.GetComponent<DrinkStream>().liquid, liquidLevel, showLid);
    }

    void EnableChildWithName(GameObject obj, string name, string liquidLevel, bool showLid)
    {
        //Loop thru the childeren and disable all but the chosen child
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.name == name)
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = true;
                GameManager.GetComponent<TutorialManager>().hideTutorialImage(name);
                setLiquidLevels(liquidLevel, eachChild.gameObject, name);
            }
            else
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if (lid != null && showLid)
            {
                lid.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
