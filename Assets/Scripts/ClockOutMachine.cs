using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockOutMachine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.tag == "Hand")
        {
            Application.Quit();
        }
    }
}
