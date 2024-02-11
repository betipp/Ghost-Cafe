using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CookableFood : MonoBehaviour
{
    private bool cooking;
    private bool isCooked = false;
    private bool isBurnt = false;
    private float cookingTime = 0;
    private float timeToCook = 2;
    private float timeToBurn = 4;
    public string cookingStation;
    public Mesh cookedMesh;
    public Mesh burntMesh;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == cookingStation)
        {
            gameObject.GetComponent<SpawnObjectManager>().spawnNewObject();
            cooking = true;

        }
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == cookingStation)
        {
            cooking = false;
        }

    }
    void Update()
    {
        if (cooking && !isBurnt)
        {

            cookingTime += Time.deltaTime;
            if (cookingTime >= timeToCook)
            {
                if (cookingTime >= timeToBurn)
                {
                    isCooked = false;
                    isBurnt = true;
                    burnItem();
                }
                else if (cookingTime >= timeToCook && !isCooked)
                {
                    isCooked = true;
                    cookItem();
                }

            }
        }
    }

    void cookItem()
    {
        MeshFilter currentMesh = this.gameObject.GetComponent<MeshFilter>();
        currentMesh.sharedMesh = cookedMesh;
        this.tag = "Prepered";
        AudioManager.Play("FoodDone");
    }
    void burnItem()
    {
        MeshFilter currentMesh = this.gameObject.GetComponent<MeshFilter>();
        currentMesh.sharedMesh = burntMesh;
        this.tag = "Item";
        AudioManager.Play("FoodDone");
    }
}
