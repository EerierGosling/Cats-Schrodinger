using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CatController : MonoBehaviour
{

    // [SerializeField]
    // private Tilemap groundTilemap;
    // [SerializeField]
    // private Tilemap wallTileMap;

    private CatMovement controls;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public OptionShower optionShower;
    public Camera cam;

    private Vector3 startPos;

    private void Awake()
    {
        controls = new CatMovement();
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Cat.Movement.performed += OnMovementPerformed;
        controls.Cat.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.Cat.Movement.performed -= OnMovementPerformed;
        controls.Cat.Movement.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        if(optionShower.inMenu)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        // Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)moveVector);
        // if (groundTilemap.HasTile(gridPosition) && !wallTileMap.HasTile(gridPosition))
        rb.velocity = moveVector * moveSpeed;

        if (Input.GetMouseButtonDown(1)){
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)){
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                float radius = interactable.radius;
                Transform player = transform;
                Transform interactableTransform = interactable.transform;
                if (interactable != null){
                    float distance = Vector3.Distance(player.position, interactableTransform.position);
                    if (distance <= radius){
                        Debug.Log("Interact");
                        // interact with the object
                    }
                }
            }
        }
    }

    public void ResetPos()
    {
        transform.position = startPos;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}