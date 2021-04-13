using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Worm") {
         other.gameObject.GetComponentInParent<Worm>().gameObject.SetActive(false);
      }
   }
   
}
