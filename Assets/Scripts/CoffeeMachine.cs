using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoffeeMachine : MonoBehaviour
{
    public ParticleSystem coffee;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with object");
        coffee.Play();
    }
}
