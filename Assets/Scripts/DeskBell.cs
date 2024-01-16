using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBell : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    public ParticleSystem coins;

    Ghost ghost;

    private int tasksDone = 0;
    private int rewardAmount = 50;


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
            newTask();
        }
    }

    void newTask()
    {
        bool taskComplete = gameManager.GetComponent<ListManager>().areAllTrue();
        if (taskComplete)
        {
            tasksDone++;
            if (tasksDone == 5)
            {
                rewardAmount = 80;
                this.GetComponent<Timer>().Duration = 90;
            }
            if (tasksDone == 10)
            {
                this.GetComponent<Timer>().Duration = 60;
                rewardAmount = 120;
            }

            this.GetComponent<Timer>().remainingDuration = 0;

            //Chose new ghost
            ghost.setGhostType(choseRandomGhostType());
            ghost.setGhostModel();

            //Chose new task
            gameManager.GetComponent<ListManager>().removeOrderItems();
            gameManager.GetComponent<ListManager>().fillListWithTasks();
            gameManager.GetComponent<CoinManager>().increaseCoins(rewardAmount);
            AudioManager.Play("Coins");
            AudioManager.Play("Boop");
            coins.Play();

        }
    }

    public void forceNewTask()
    {

        //Chose new ghost
        ghost.setGhostType(choseRandomGhostType());
        ghost.setGhostModel();

        //Chose new task
        gameManager.GetComponent<ListManager>().removeOrderItems();
        gameManager.GetComponent<ListManager>().fillListWithTasks();
        AudioManager.Play("Down");

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
