using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class OrangeMachine : MonoBehaviour
{
    public enum Operation
    {
        Button,
        Blender
    }
    public List<GameObject> fruit = new List<GameObject>();
    public bool isFull = false;
    public Operation operation;

    [SerializeField]
    private GameObject liquidStream;


    [SerializeField]
    private ParticleSystem liquidParticles;

    [SerializeField]
    private GameObject drinkMachine;

    [SerializeField]
    private GameObject fruitText;

    void OnTriggerEnter(Collider other)
    {
        if (operation == Operation.Blender)
        {
            if (other.tag == "Fruit" && !isFull)
            {
                if (!isAlreadyInside(other.gameObject))
                {
                    fruit.Add(other.gameObject);
                    fruitText.GetComponent<TMPro.TextMeshProUGUI>().text = fruit.Count + "/3";

                }
                if (fruit.Count == 3)
                {
                    isFull = true;
                }

            }
        }
        else if (operation == Operation.Button)
        {
            if (drinkMachine.GetComponent<OrangeMachine>().isFull)
            {

                if (other.tag == "Hand")
                {
                    liquidStream.GetComponent<DrinkStream>().setIsPouring(true);
                    drinkMachine.GetComponent<OrangeMachine>().mixFruit();
                    StartCoroutine(SetFalse(5));
                    liquidParticles.Play();
                    AudioManager.Play("Pouring");
                }

            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        fruit.Remove(other.gameObject);
        isFull = false;
    }

    bool isAlreadyInside(GameObject item)
    {
        foreach (GameObject eachChild in fruit)
        {
            if (eachChild == item)
            {
                return true;
            }
        }
        return false;
    }

    void mixFruit()
    {
        foreach (GameObject eachChild in fruit)
        {
            print("Destrying " + eachChild.name);
            Destroy(eachChild);
        }
        fruit = new List<GameObject>();
        isFull = false;
    }

    IEnumerator SetFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds); //wait n seconds
        AudioManager.Play("Beep");
        liquidStream.GetComponent<DrinkStream>().setIsPouring(false);
    }


}