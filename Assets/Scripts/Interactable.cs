using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactable : MonoBehaviour
{
    public float radius = 1f;

    bool isFocus = false;
    Transform playerTrans;
    public Transform interactionTransform;

    bool hasInteracted = false;

    public virtual void Interact ()
    {

    }

    public virtual void Update ()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(playerTrans.position, transform.position);
            if (distance <= radius)
            {
                Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        playerTrans = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused ()
    {
        isFocus = false;
        playerTrans = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected ()
    {
        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
