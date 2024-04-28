using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    private RigidBody rb;
    public float movementSpeed;
    private float dirX, dirZ;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = boxCollider.bounds.center;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                dirX = Input.GetAxis("Horizontal") * movementSpeed;
                dirZ = Input.GetAxis("Vertical") * movementSpeed;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
