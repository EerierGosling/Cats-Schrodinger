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

    private void Awake()
    {
        controls = new CatMovement();
        rb = GetComponent<Rigidbody2D>();
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
        // Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)moveVector);
        // if (groundTilemap.HasTile(gridPosition) && !wallTileMap.HasTile(gridPosition))
        rb.velocity = moveVector * moveSpeed;
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
