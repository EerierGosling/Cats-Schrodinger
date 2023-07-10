using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimController : MonoBehaviour
{
    public void SetDim(float alpha, float r = 0f, float g = 0f, float b = 0f)
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        rend.color = new Color(r, g, b, alpha);
    }
}
