using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    Vector3 lastPosition;
    List<GameObject> list = new List<GameObject>();
    List<WormRing> wormRingList = new List<WormRing>();
    Color [] colors = new Color[] { Color.red, Color.yellow, Color.blue };
    [SerializeField]
    GameObject nodeSprite;
    [SerializeField]
    Transform body, head;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    float bodyDistance = 0.2f;
    [SerializeField]
    float wormSize = 1f;
    [SerializeField]
    float colourOffset = 0.3f;

    void Awake() {
        SetUpWorm();
    }

    Vector3 GetRandomPosition () {
        return Vector3.zero;
    }

    public void SetUpWorm () {
          int randSize = Random.Range(4, 8);
        GameObject temp = null;
        Color selectedColour = colors[(int) Random.Range(0, colors.Length)];
        sprite.GetComponent<SpriteRenderer>().color = selectedColour;
        var vect = Vector3.one * bodyDistance;

        for (var i = 0; i < randSize; i++)
        {
            temp = Instantiate(nodeSprite, GetRandomPosition (), Quaternion.identity);

            if (i % 2 == 0) {
                temp.GetComponent<SpriteRenderer>().color = selectedColour;
            } else {
                Color c = selectedColour * colourOffset;
                c.a =1;
                temp.GetComponent<SpriteRenderer>().color = c;
            }

            if (i == 0) {
                temp.transform.position = transform.position + vect * bodyDistance;
                vect.y = 0;
            } else {
                temp.transform.position = list[i - 1].transform.position + vect;
            }
            
            list.Add(temp); 

            temp.transform.SetParent(body);
            WormRing wormR = temp.AddComponent<WormRing>();

            if (i == 0)
                wormR.target = head.gameObject;
            else
                wormR.target = wormRingList[i - 1].gameObject;

            wormR.offset = vect;
            wormRingList.Add (wormR);
        }


        transform.localScale = Vector2.one * wormSize;
    }

  
}
