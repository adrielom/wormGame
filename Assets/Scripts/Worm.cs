using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();
    Color [] colors = new Color[] { Color.red, Color.yellow, Color.blue };
    [SerializeField]
    GameObject nodeSprite;
    [SerializeField]
    Transform body;
    [SerializeField]
    float bodyDistance = 0.2f;
    [SerializeField]
    float wormSize = 1f;
    [SerializeField]
    float colourOffset = 0.3f;


    void Start() {
        SetUpWorm();
    }

    Vector3 GetRandomPosition () {
        return Vector3.zero;
    }

    public void SetUpWorm () {
          int randSize = Random.Range(4, 8);
        GameObject temp = null;
        Color selectedColour = colors[(int) Random.Range(0, colors.Length)];
        GetComponent<SpriteRenderer>().color = selectedColour;
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
                temp.transform.position = transform.position + Vector3.one * bodyDistance;
            } else {
                temp.transform.position = list[i - 1].transform.position + Vector3.one * bodyDistance;
            }
            
            list.Add(temp); {

            }
            temp.transform.SetParent(body);
        }


        transform.localScale = Vector2.one * wormSize;
    }

  
}
