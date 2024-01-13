using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockOutMachine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

}
