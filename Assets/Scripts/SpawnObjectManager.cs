using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnObjectManager : MonoBehaviour
{


    [SerializeField] bool isRespawnableObject = true;
    [SerializeField] bool unTouched = true;
    [SerializeField] GameObject spawnLocation;


    void OnTriggerEnter(Collider other)
    {
        /*
        if (isRespawnableObject && unTouched && other.tag == "Hand")
        {

            IEnumerator coroutine = checkDistance();
            StartCoroutine(coroutine);
            //unTouched = false;

        }*/

    }
    public void Update()
    {
        if (isRespawnableObject && unTouched)
        {

            checkDistance();
            //unTouched = false;

        }
    }

    public void spawnNewObject()
    {
        if (isRespawnableObject && unTouched)
        {
            GameObject newObject = Instantiate(this.gameObject, spawnLocation.transform.position, Quaternion.identity);
            newObject.GetComponent<Rigidbody>().isKinematic = false;
            newObject.GetComponent<Rigidbody>().useGravity = true;
            newObject.GetComponent<SpawnObjectManager>().unTouched = true;
            newObject.GetComponent<AudioSource>().Play();
            unTouched = false;
        }

    }

    private void checkDistance()
    {
        //Distance between spawn point and current object position

        /*
        while (dist < 1)
        {
            dist = Vector3.Distance(this.gameObject.transform.position, spawnLocation.transform.position);
            //yield return null;
        }*/
        if (unTouched)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, spawnLocation.transform.position);
            if (dist > 1)
            {

                GameObject newObject = Instantiate(this.gameObject, spawnLocation.transform.position, Quaternion.identity);
                newObject.GetComponent<Rigidbody>().isKinematic = false;
                newObject.GetComponent<Rigidbody>().useGravity = true;
                newObject.GetComponent<SpawnObjectManager>().unTouched = true;
                newObject.GetComponent<AudioSource>().Play();
                unTouched = false;
            }



        }
        //yield return null;
    }



}
