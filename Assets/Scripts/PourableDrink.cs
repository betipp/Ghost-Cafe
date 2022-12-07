using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PourableDrink : MonoBehaviour
{
    private bool cooking;
    private bool isCooked;
    private float cookingTime = 0;
    private float timeToCook = 5;
    public string prepStation;
    public GameObject liquid;

    public GameObject coffeeMachine;


    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == prepStation)
        {
            cooking = true;

        }
    }
    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == prepStation)
        {
            cooking = false;
        }

    }
    void Update()
    {

        if (cooking && !isCooked && coffeeMachine.GetComponent<CoffeeMachine>().pouring)
        {


            cookingTime += Time.deltaTime;
            if (cookingTime >= timeToCook)
            {
                isCooked = true;
                showLiquid();
            }
        }
    }

    void showLiquid()
    {
        liquid.GetComponent<MeshRenderer>().enabled = true;

    }
}