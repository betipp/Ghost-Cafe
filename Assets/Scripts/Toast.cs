using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toast : MonoBehaviour
{

    private bool grabbed = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            print(checkJellyType(other.gameObject));
            EnableChildWithName(this.gameObject, checkJellyType(other.gameObject));
        }
        if (other.gameObject.tag == "Hand" && !grabbed)
        {
            GameObject parent = this.transform.parent.gameObject;
            GameObject newObject = Instantiate(parent, parent.gameObject.transform.position, Quaternion.identity);
            newObject.transform.localScale = parent.gameObject.transform.localScale;
            newObject.transform.position = new Vector3(6.924f, 2.344f, 1.735f);
            newObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            newObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
            grabbed = true;

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
