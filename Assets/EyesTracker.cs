using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesTracker : MonoBehaviour
{
    public GameObject leftEye, rightEye;
    public float radius = 0.2f;
    float speed = 1f;

    Vector3 lastTouch = Vector3.zero;

    

    void Update() {
        if (Input.GetMouseButtonDown(0)) {

            lastTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir  = (lastTouch - transform.position).normalized;
            print("here");
            StartCoroutine(SetEyes(dir));
            
         
        }

    }

    public IEnumerator SetEyes (Vector3 dir, float time = .5f) {
        Vector3 startingPos = Vector3.zero;
        yield return new WaitForSeconds(time);
        
        leftEye.transform.localPosition = Vector3.MoveTowards(leftEye.transform.localPosition, startingPos + radius * dir, time);
        rightEye.transform.localPosition = Vector3.MoveTowards(rightEye.transform.localPosition, startingPos + radius * dir, time);
        // leftEye.transform.localPosition = startingPos + radius * dir;
        // rightEye.transform.localPosition = startingPos + radius * dir;
        yield return new WaitForSeconds(time * 5);
        leftEye.transform.localPosition = Vector3.MoveTowards(leftEye.transform.localPosition, Vector3.zero, time);
        rightEye.transform.localPosition = Vector3.MoveTowards(rightEye.transform.localPosition, Vector3.zero, time);
        // leftEye.transform.localPosition = Vector3.zero;
        // rightEye.transform.localPosition = Vector3.zero;
    }

}
