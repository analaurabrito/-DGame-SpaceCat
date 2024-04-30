using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : Interactable
{
    public Animator animator;
    public bool challengeComplete = false;
    public PlayerController player;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {

        animator.SetBool("Enabled", false);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (challengeComplete == true)
            animator.SetBool("Enabled", true);
    }

    public void levelComplete()
    {
        challengeComplete = true;
        animator.SetBool("Enabled", true);
    }

    public override void Interact ()
    {
        if(challengeComplete == true)
        {
            player.MoveToPosition(interactionTransform);
            player.Stop();
            playerAnimator.SetTrigger("EnteringPortal");
        }
        else
        {
            Debug.Log("Portal Desabilitado");
        }
    }
}
