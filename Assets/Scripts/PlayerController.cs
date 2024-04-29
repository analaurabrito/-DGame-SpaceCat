using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public GameObject portal;
    public LayerMask movementMask;
    public float movementSpeed = 5f;


    private Rigidbody rb;
    private Animator animator;
    private Vector2 input;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private string currentAnimState = "Idle";

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (input.sqrMagnitude > 0)
        {
            if (currentAnimState != "Movement")
            {
                animator.SetFloat("Horizontal", input.x);
                animator.SetFloat("Vertical", input.y);
                animator.SetFloat("Speed", input.sqrMagnitude);
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

    void SetFocus (Interactable newFocus)
    {
        focus = newFocus;
        transform.position = Vector2.MoveTowards(transform.position, focus.transform.position, movementSpeed);
    }

    void RemoveFocus ()
    {
        focus = null;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(input.x, 0, input.y).normalized * movementSpeed * Time.deltaTime);
    }
}
