using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkStream : MonoBehaviour
{
    public string liquid;
    public bool isPouring;

    public void setIsPouring(bool value)
    {
        isPouring = value;
    }

    public bool getIsPouring()
    {
        return isPouring;
    }
}
