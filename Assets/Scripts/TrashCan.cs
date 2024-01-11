using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem trashParticles;

    [SerializeField]
    private GameObject gameManager;

    List<String> removableItems = new List<String>()
        {
            "Prepered",
            "Respawn",
            "Fruit",
            "Knife",
            "Item",
            "Moldy",
    };

    void OnTriggerEnter(Collider other)
    {
        if (removableItems.Contains(other.tag))
        {
            other.gameObject.GetComponent<SpawnObjectManager>().spawnNewObject();
            if (other.tag == "Moldy")
            {
                gameManager.GetComponent<CoinManager>().increaseCoins(5);
                AudioManager.Play("Coins");
            }
            Destroy(other.gameObject);
            AudioManager.Play("Trash");
            trashParticles.Play();
        }
    }
}
