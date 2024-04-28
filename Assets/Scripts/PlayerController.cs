using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Interactable focus;

    public LayerMask movementMask;

    private Rigidbody rb;
    public float movementSpeed;
    private float dirX, dirZ;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxis("Horizontal") * movementSpeed;
        dirZ = Input.GetAxis("Vertical") * movementSpeed;

        if (dirX != null || dirZ != null)
        {
            RemoveFocus();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
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
