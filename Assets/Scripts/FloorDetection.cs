using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{

    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private Material moldyMat;

    List<String> moldyItems = new List<String>()
    {
            "Prepered",
            "Respawn",
            "Fruit",
            "Item",
            "Knife"
    };


    void OnTriggerEnter(Collider other)
    {
        if (moldyItems.Contains(other.tag))
        {
            if (other.tag == "Item" || other.tag == "Knife")
            {
                ChangeMaterial(moldyMat, other.gameObject);
            }
            else
            {
                other.GetComponent<MeshRenderer>().material = moldyMat;

            }
            other.tag = "Moldy";
            gameManager.GetComponent<CoinManager>().decreaseCoins(5);
            AudioManager.Play("Down");
        }

    }


    void ChangeMaterial(Material newMat, GameObject parent)
    {
        Renderer[] children;
        children = parent.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }
}
