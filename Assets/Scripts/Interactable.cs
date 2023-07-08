using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    bool isFocus = false;
    Transform player;

    void Update (){
        if (isFocus){
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius){
                Debug.Log("Interact");
            }
        }
    }

    public void OnFocused (Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused () {
        isFocus = false;
        player = null;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
