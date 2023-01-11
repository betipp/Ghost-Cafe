using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DrinkMachineButton : MonoBehaviour
{
    [SerializeField]
    private GameObject liquidStream;


    [SerializeField]
    private ParticleSystem liquidParticles;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            liquidStream.GetComponent<DrinkStream>().setIsPouring(true);
            StartCoroutine(SetFalse(5));
            liquidParticles.Play();
            AudioManager.Play("Pouring");
        }

    }
    IEnumerator SetFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds); //wait n seconds
        AudioManager.Play("Beep");
        liquidStream.GetComponent<DrinkStream>().setIsPouring(false);
    }

}



