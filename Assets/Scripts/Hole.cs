using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hole : MonoBehaviour
{

   public AudioSource audioSource;

   void OnTriggerStay2D (Collider2D other) {
      Worm worm = other.gameObject.GetComponentInParent<Worm>();
      if (other.gameObject.tag == "Worm" && !worm.dragging) {
         audioSource.Play();
         StartCoroutine(ShiftWorms(worm, 0.2f));
      }
   }

   IEnumerator ShiftWorms (Worm other, float time) {
      yield return new WaitForSeconds(time);
      GameObject newWorm = WormsManager.GetRandomActiveWormDiffColor(other.selectedColour);
      newWorm.transform.position = WormsManager.GetRandomPosition();    
      newWorm.transform.localScale = Vector3.zero;
      newWorm.SetActive(true);
      newWorm.transform.DOScale(Vector3.one * 0.3f, 0.5f);
      other.gameObject.SetActive(false);
   }


   
}
