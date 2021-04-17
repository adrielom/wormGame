using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public AudioSource audioSource;
    Worm worm;

    void Start() {
        worm = GetComponentInParent<Worm>();
    }

    void OnMouseDown() {
        worm.dragging = true;
        audioSource.Play();
    }

    void OnMouseUp() {
        worm.dragging = false;
    }

}
