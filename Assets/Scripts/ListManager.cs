using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ListManager : MonoBehaviour
{

    private string[] List = new string[3];
    [SerializeField]
    public string[] AllTasks = { };
    public bool[] ListStatus = { false, false, false };
    [SerializeField]
    public TMPro.TextMeshProUGUI textList;
    [SerializeField]
    public ParticleSystem stars;



    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < List.Length; i++)
        {
            //Go thru the list of taska and figure out if the colliding object in one of them, if that is so consider the task done
            if (other.tag == "Prepered" && other.name.Contains(List[i]))
            {
                ListStatus[i] = true;
                AudioManager.Play("Done");
                stars.Play();
                printTasks();
                other.tag = "TaskDone";
            }
        }
    }

    void Start()
    {
        fillListWithTasks();
    }

    void fillListWithTasks()
    {
        int tasks = 0;
        while (tasks < List.Length)
        {
            string newTask = getRandomTask();
            if (!isTaskAlreadyInList(newTask))
            {
                List[tasks] = newTask;
                tasks++;
            }
        }

        printTasks();


    }
    void printTasks()
    {
        String strTasks = "";
        for (int i = 0; i < List.Length; i++)
        {
            if (ListStatus[i] == true)
            {
                strTasks = strTasks + " - <s>" + List[i] + "</s>" + System.Environment.NewLine;
            }
            else
            {
                strTasks = strTasks + " - " + List[i] + System.Environment.NewLine;
            }
        }
        textList.text = strTasks;
    }

    string getRandomTask()
    {
        var rnd = new System.Random();
        return (AllTasks[rnd.Next(AllTasks.Length)]);

    }
    bool isTaskAlreadyInList(string newTask)
    {
        for (int i = 0; i < List.Length; i++)
        {
            if (newTask == List[i])
            {
                return true;
            }
        }


        return false;

    }
}
