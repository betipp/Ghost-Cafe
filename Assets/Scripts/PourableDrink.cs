using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                this.tag = "Prepered";
                this.name = drinkStream.GetComponent<DrinkStream>().liquid + "Shake";
                showLiquid();
            }
        }
    }

    bool isLiquidPouringOnStream()
    {
        if (drinkStream != null)
        {
            return drinkStream.GetComponent<DrinkStream>().getIsPouring();
        }
        return false;
    }

    void showLiquid()
    {
        EnableChildWithName(this.gameObject, drinkStream.GetComponent<DrinkStream>().liquid);
    }

    void EnableChildWithName(GameObject obj, string name)
    {
        //Loop thru the childeren and disable all but the chosen child
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.name == name)
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = true;
                GameManager.GetComponent<TutorialManager>().hideTutorialImage(name);
            }
            else
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            if (lid != null)
            {
                lid.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
