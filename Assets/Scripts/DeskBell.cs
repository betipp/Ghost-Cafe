using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    public ParticleSystem coins;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            bool taskComplete = gameManager.GetComponent<ListManager>().areAllTrue();
            if (taskComplete)
            {
                gameManager.GetComponent<ListManager>().removeOrderItems();
                gameManager.GetComponent<ListManager>().fillListWithTasks();
                AudioManager.Play("Coins");
                coins.Play();
            }
        }
    }
}
