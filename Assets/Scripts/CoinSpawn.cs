using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public List<Transform> cspawnlocation; //List of prefabs is shown on the unity UI, not the code. List contains 10 emptygameobject locations for possible coin locations.
    public GameObject Spaghetti;
    int index;

    // Start is called before the first frame update
    void Start()
    {
        while (cspawnlocation.Count > 6)
        {
            index = Random.Range(0, cspawnlocation.Count);
            cspawnlocation.RemoveAt(index);
        }
        foreach (Transform t in cspawnlocation) 
        {
            GameObject coin = Instantiate(Spaghetti, t.position, Quaternion.identity);
            coin.transform.SetParent(t);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
