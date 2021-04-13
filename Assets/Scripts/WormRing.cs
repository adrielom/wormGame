using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormRing : MonoBehaviour
{

    public GameObject target;
    public Vector3 offset;
    float time = 10f;
    float dist = 0.2f;
    
    void Update() {
        if (Vector2.Distance(target.transform.position, transform.position) > dist) {
            Lerp();
        }
    }

    public void Lerp()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, time * Time.deltaTime);
    }
}
