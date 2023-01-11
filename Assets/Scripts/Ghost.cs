using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public void talk()
    {
        AudioManager.Play("Boop");
    }
}
