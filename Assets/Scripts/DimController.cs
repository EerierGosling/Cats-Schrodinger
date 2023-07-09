using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimController : MonoBehaviour
{

    public GameObject dim;

    public void DimControl(bool inBox) {
        
        SpriteRenderer spriteRenderer = dim.GetComponent<SpriteRenderer>();

        if (inBox) {
            spriteRenderer.color = new Color(0f, 0f, 0f, 1f);
        }
        else {
            spriteRenderer.color = new Color(0f, 0f, 0f, 0.75f);
        }
    }
}
