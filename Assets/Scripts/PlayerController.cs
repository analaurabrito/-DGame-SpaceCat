using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public GameObject portal;
    public LayerMask movementMask;
    public float movementSpeed = 5f;


    public Rigidbody rb;
    public Animator animator;
    private Vector2 input;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
        animator.SetFloat("Speed", input.sqrMagnitude);

        if (input.sqrMagnitude > 0)
        {
            RemoveFocus();
        }
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
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
                    interactable.Interact();
                }
            }
        }
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
        }

        newFocus.OnFocused(transform);
    }

    void RemoveFocus ()
    {
        if(focus != null)
            focus.OnDefocused();
        focus = null;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + new Vector3(input.x, 0, input.y).normalized * movementSpeed * Time.deltaTime);
    }

    public void Stop ()
    {
        movementSpeed = 0f;
    }

    public void MoveToPosition(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        rb.MovePosition((rb.position + direction * movementSpeed) * Time.deltaTime);
    }
}
