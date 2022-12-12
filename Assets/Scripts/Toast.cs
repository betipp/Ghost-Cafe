using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toast : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            EnableChildWithName(this.gameObject, checkJellyType(other.gameObject));
            AudioManager.Play("JellySplat");
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
