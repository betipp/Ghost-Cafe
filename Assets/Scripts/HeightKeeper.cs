using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightKeeper : MonoBehaviour
{

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y = 1.131f;
        transform.position = pos;

    }
}
