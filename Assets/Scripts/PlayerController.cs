using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public GameObject portal;
    public LayerMask movementMask;

    private Rigidbody2D rb;
    public float movementSpeed = 5f;
    private Animator animator;
    private Vector2 input;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private string currentAnimState = "Idle";

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.magnitude > 0)
        {
            if (currentAnimState != "Movement")
            {
                animator.CrossFade("Movement", 0, 0);
                currentAnimState = "Movement";
                RemoveFocus();
            }
        }
        else
        {
            if (currentAnimState != "Idle")
            {
                animator.CrossFade("Idle", 0, 0);
                currentAnimState = "Idle";
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                if (interactable == portal)
                {
                    animator.SetTrigger("EnteringPortal");
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(input.x, input.y).normalized * movementSpeed * Time.deltaTime);
    }

    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;
    }

    void RemoveFocus ()
    {
        focus = null;
    }
}
