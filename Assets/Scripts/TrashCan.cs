using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem trashParticles;

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
            Destroy(other.gameObject);
            AudioManager.Play("Trash");
            trashParticles.Play();
        }
    }
}
