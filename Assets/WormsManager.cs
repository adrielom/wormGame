using System.Linq;
using UnityEngine;


public class WormsManager : MonoBehaviour
{

    static GameObject[] wormPool = new GameObject[10];
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
            wormPool[i].transform.SetParent(transform);
            if (i % 2 != 0) wormPool[i].SetActive(false);
        }
    }

    public static GameObject GetRandomActiveWorm () {
        var list = wormPool.ToList().FindAll(x => x.activeSelf == false);
        return list[Random.Range(0, list.Count)];
    }

    public static GameObject GetRandomActiveWormDiffColor (Color color) {
        var list = wormPool.ToList().FindAll(x => x.activeSelf == false);
        var colourSortedList = list.FindAll(v => v.GetComponent<Worm>().selectedColour != color);
        return colourSortedList.Count == 0 ? list[Random.Range(0, list.Count)] : colourSortedList[Random.Range(0, colourSortedList.Count)];   
    }

    public static Vector3 GetRandomPosition () {
        return new Vector3(Random.Range(minEdge.x, maxEdge.x), Random.Range(minEdge.y, maxEdge.y), 0);
    }

}
