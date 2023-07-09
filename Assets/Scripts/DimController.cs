using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimController : MonoBehaviour
{
    public float SetDim(float alpha)
    {
        Debug.Log("Setting dim to " + alpha);

        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        Color color = rend.color;
        color.a = alpha;
        rend.color = color;

        return alpha;
    }
}
