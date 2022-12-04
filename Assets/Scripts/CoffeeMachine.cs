using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoffeeMachine : MonoBehaviour
{

    public ParticleSystem coffee;
    public bool pouring;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with object");
        pouring = true;
        StartCoroutine(SetFalse(5));
        coffee.Play();
    }
    IEnumerator SetFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds); //wait 10 seconds
        pouring = false;
    }

}



