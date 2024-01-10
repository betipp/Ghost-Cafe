using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toast : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            string jellyType = checkJellyType(other.gameObject);
            if (jellyType != null)
            {
                this.GetComponentInParent<SpawnObjectManager>().spawnNewObject();
                EnableChildWithName(this.gameObject, jellyType);
                this.tag = "Prepered";
                this.name = "Toast" + jellyType;
                DisableAllJelly(other.gameObject);
                AudioManager.Play("JellySplat");
            }

        }
    }

    void EnableChildWithName(GameObject obj, string name)
    {
        //Loop thru the childeren and disable all but the knife itself and our searched child object.
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.name == name)
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    void DisableAllJelly(GameObject obj)
    {
        //Loop thru the childeren and disable all but the knife itself and our searched child object.
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.name != "Knife")
            {
                eachChild.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }


    string checkJellyType(GameObject obj)
    {
        foreach (Transform eachChild in obj.transform)
        {
            if (eachChild.gameObject.GetComponent<MeshRenderer>().enabled && eachChild.name != "Knife")
            {
                return eachChild.gameObject.name;
            }
        }
        return null;
    }


}
