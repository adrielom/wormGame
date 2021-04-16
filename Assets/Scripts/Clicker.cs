using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    
    Worm worm;

    void Start() {
        worm = GetComponentInParent<Worm>();
    }

    void OnMouseDown() {
        worm.dragging = true;
    }

    void OnMouseUp() {
        worm.dragging = false;
    }

}
