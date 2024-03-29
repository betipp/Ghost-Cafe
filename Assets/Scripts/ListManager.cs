using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ListManager : MonoBehaviour
{

    public string[] List = new string[3];
    [SerializeField]
    public string[] AllTasks = { };
    public bool[] ListStatus = { false, false, false };
    [SerializeField]
    public TMPro.TextMeshProUGUI textList;
    [SerializeField]
    public ParticleSystem stars;

    private GameObject[] orderItems = { null, null, null };

    [SerializeField]
    private GameObject[] orderItemsLocation = { null, null, null };








    void OnTriggerEnter(Collider other)
    {

        for (int i = 0; i < List.Length; i++)
        {
            //Go thru the list of taska and figure out if the colliding object in one of them, if that is so consider the task done
            if (other.tag == "Prepered" && other.name.Contains(List[i]) && !ListStatus[i])
            {
                ListStatus[i] = true;
                AudioManager.Play("Done");
                stars.Play();
                printTasks();
                orderItems[i] = other.gameObject;
                //Set order to its intended location on the order plate
                other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
                other.gameObject.transform.position = orderItemsLocation[i].transform.position;
                other.gameObject.transform.rotation = orderItemsLocation[i].transform.rotation;
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                other.tag = "TaskDone";


            }
        }
    }






    public void fillListWithTasks()
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
                strTasks = strTasks + " - <s>" + getTaskName(List[i]) + "</s>" + System.Environment.NewLine;
            }
            else
            {
                strTasks = strTasks + " - " + getTaskName(List[i]) + System.Environment.NewLine;
            }
        }
        textList.text = strTasks;
    }

    string getTaskName(String taskName)
    {
        if (LanguageManager.translation)
        {
            switch (taskName)
            {
                case "Dounut":
                    return ("Krof");
                case "Coffee":
                    return ("Kava");
                case "Bacon":
                    return ("Slanina");
                case "ToastJelly":
                    return ("Toast z marmelado");
                case "ToastPeanut":
                    return ("Toast z arašidi");
                case "Egg":
                    return ("Jajca");
                case "Sausage":
                    return ("Hrenovka");
                case "ChocolateShake":
                    return ("Čokoladni shake");
                case "StrawberryShake":
                    return ("Jagodni shake");
                case "Pie":
                    return ("Pita");
                case "Oreo":
                    return ("Oreo");
                case "Pudding":
                    return ("Puding");
                case "Cookie":
                    return ("Piškot");
                case "FRIPastry":
                    return ("FRI piškot");
                case "JuiceShake":
                    return ("Smuti");
            }
            return null;
        }
        else
        {
            switch (taskName)
            {
                case "Dounut":
                    return ("Donut");
                case "Coffee":
                    return ("Coffee");
                case "Bacon":
                    return ("Bacon");
                case "ToastJelly":
                    return ("Jelly toast");
                case "ToastPeanut":
                    return ("Peanut toast");
                case "Egg":
                    return ("Egg");
                case "Sausage":
                    return ("Sausage");
                case "ChocolateShake":
                    return ("Chocolate shake");
                case "StrawberryShake":
                    return ("Strawberry shake");
                case "Pie":
                    return ("Pie");
                case "Oreo":
                    return ("Oreo");
                case "Pudding":
                    return ("Pudding");
                case "Cookie":
                    return ("Cookie");
                case "FRIPastry":
                    return ("FRI cookie");
                case "JuiceShake":
                    return ("Smoothie");
            }
            return null;
        }

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
    public void removeOrderItems()
    {
        for (int i = 0; i < orderItems.Length; i++)
        {
            Destroy(orderItems[i]);
        }
        orderItems = new GameObject[] { null, null, null };
        ListStatus = new bool[] { false, false, false };
    }



    public bool areAllTrue()
    {
        for (int i = 0; i < ListStatus.Length; ++i)
        {
            if (ListStatus[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
