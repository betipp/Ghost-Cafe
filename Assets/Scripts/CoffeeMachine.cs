using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoffeeMachine : MonoBehaviour
{

    public ParticleSystem coffee;
    public bool pouring;

    void OnTriggerEnter(Collider other)
    {
        pouring = true;
        StartCoroutine(SetFalse(5));
        coffee.Play();
        AudioManager.Play("Pouring");
    }
    IEnumerator SetFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds); //wait 10 seconds
        AudioManager.Play("Beep");
        pouring = false;
    }

}



