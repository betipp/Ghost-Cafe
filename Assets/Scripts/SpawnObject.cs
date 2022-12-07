using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;
    [SerializeField]
    GameObject spawnLocation;
    // Start is called before the first frame update
    public void SpawnGameObject()
    {
        print("INTERACTED");
        GameObject newObject = Instantiate(objectPrefab, spawnLocation.gameObject.transform.position, Quaternion.identity);
        newObject.transform.localScale = objectPrefab.gameObject.transform.localScale;
        //newObject.transform.position = new Vector3(6.924f, 2.344f, 1.735f);

    }
}
