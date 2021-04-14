using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormsManager : MonoBehaviour
{

    GameObject[] wormPool = new GameObject[10];
    public GameObject WormPrefab;
    public static Vector2 minEdge = new Vector2(-5, -2); 
    public static Vector2 maxEdge = new Vector2(5, 2); 

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos;
        for (var i = 0; i < wormPool.Length; i++)
        {
            pos =  new Vector3(Random.Range(minEdge.x, maxEdge.x),Random.Range(minEdge.y, maxEdge.y), 0);
            wormPool[i] = Instantiate(WormPrefab, pos, Quaternion.identity);
            wormPool[i].GetComponent<Worm>().ChangeTarget();
            if (i % 2 == 0) wormPool[i].SetActive(false);
        }
    }

}
