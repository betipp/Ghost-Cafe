using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyContainer : MonoBehaviour
{
    [SerializeField]
    string jellyType;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            //You should spawn a new knife before this one gets jelly on it
            other.gameObject.GetComponent<SpawnObjectManager>().spawnNewObject();
            EnableChildWithName(other.gameObject, jellyType);
            AudioManager.Play("JellySplat");
        }


    }

    void EnableChildWithName(GameObject obj, string name)
    {
        //Loop thru the childeren and disable all but the knife itself and our searched child object.
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.name == name || eachChild.name == "Knife")
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }



}
