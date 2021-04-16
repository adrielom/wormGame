using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hole : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Worm") {
         StartCoroutine(ShiftWorms(other.gameObject.GetComponentInParent<Worm>().gameObject, 0.2f));
      }
   }

   IEnumerator ShiftWorms (GameObject other, float time) {
      yield return new WaitForSeconds(time);
      GameObject newWorm = WormsManager.GetRandomActiveWorm();
      newWorm.transform.position = WormsManager.GetRandomPosition();
      newWorm.transform.localScale = Vector3.zero;
      newWorm.SetActive(true);
      newWorm.transform.DOScale(Vector3.one * 0.3f, 0.5f);
      other.SetActive(false);
   }
   
}
