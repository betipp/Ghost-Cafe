using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CookableFood : MonoBehaviour
{
    private bool cooking;
    private bool isCooked;
    private float cookingTime = 0;
    private float timeToCook = 5;
    public string cookingStation;
    public Mesh cookedMesh;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == cookingStation)
        {
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
        if (cooking && !isCooked)
        {

            cookingTime += Time.deltaTime;
            if (cookingTime >= timeToCook)
            {
                isCooked = true;
                cookItem();
            }
        }
    }

    void cookItem()
    {
        MeshFilter currentMesh = this.gameObject.GetComponent<MeshFilter>();
        currentMesh.sharedMesh = cookedMesh;



    }
}
