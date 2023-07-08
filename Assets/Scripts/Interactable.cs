using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCircle(transform.position, radius);
    }
}
