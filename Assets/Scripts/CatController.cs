using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private CatMovement controls;

    private void Awake()
    {
        controls = new CatMovement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Move(Vector2 direction) {

    }
}
