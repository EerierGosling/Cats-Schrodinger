using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CatController : MonoBehaviour
{

    private CatMovement controls;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public OptionShower optionShower;
    public Interactable focus;
    public Camera cam;
    private Vector3 startPos;
    private Animator animator;

    private void Awake()
    {
        controls = new CatMovement();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        if (optionShower.inMenu)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = moveVector * moveSpeed;
    }

    private void Update(){
        if (Input.GetMouseButtonDown(1)){
            Debug.Log("Right Click");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    public void ResetPos()
    {
        transform.position = startPos;
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
    }
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();

        if (moveVector.x != 0)
            animator.SetFloat("X", moveVector.x);
        else
            animator.SetFloat("X", animator.GetFloat("X") / 2);
        animator.SetFloat("Y", moveVector.y);
        animator.SetBool("Moving", true);
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;

        animator.SetBool("Moving", false);
    }
}