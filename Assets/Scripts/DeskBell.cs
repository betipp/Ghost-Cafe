using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    public ParticleSystem coins;

    Ghost ghost;


    void Start()
    {
        //Chose new ghost
        ghost = new Ghost(choseRandomGhostType());

        gameManager.GetComponent<ListManager>().fillListWithTasks();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            bool taskComplete = gameManager.GetComponent<ListManager>().areAllTrue();
            if (taskComplete)
            {

                //Chose new ghost
                ghost.setGhostType(choseRandomGhostType());
                ghost.setGhostModel();

                //Chose new task
                gameManager.GetComponent<ListManager>().removeOrderItems();
                gameManager.GetComponent<ListManager>().fillListWithTasks();
                gameManager.GetComponent<CoinManager>().increaseCoins(50);
                AudioManager.Play("Coins");
                AudioManager.Play("Boop");
                coins.Play();


            }
        }
    }


    Ghost.GhostType choseRandomGhostType()
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(0, 2);
        if (randomNumber == 0)
        {
            return Ghost.GhostType.Teacher;
        }
        else
        {
            return Ghost.GhostType.Student;
        }
    }
}
