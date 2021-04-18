using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    AudioSource audioSource;
    Worm worm;
    void Start() {
        worm = GetComponentInParent<Worm>();
        audioSource = GameObject.Find("Audio Pop").GetComponent<AudioSource>();
    }

    void OnMouseDown() {
        if (gameObject.activeSelf == false) return;
        worm.dragging = true;
        audioSource?.Play();
    }

    void OnMouseUp() {
        worm.dragging = false;
    }

}
