using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : Interactable
{
    public PortalController portal;
    public ChaliceController chalice;
    public Animator animator;
    public CanvasGroup firstBone;
    public bool fistInteraction = false;

    public override void Update()
    {
        base.Update();
    }

    void Transform()
    {
        animator.SetBool("Transformed", true);
    }

    public override void Interact()
    {
        if (!fistInteraction)
        {
            fistInteraction = true;
            Debug.Log("Voc� precisa me entregar o calice das almas para eu voltar a minha antiga forma");
        }
        else if (chalice.isPicked)
        {
            portal.levelComplete();
            Transform();
            Debug.Log("Obrigada! Aqui est� uma recompensa!");
            Inventory.Add(firstBone);
        }
        else
        {
            Debug.Log("Onde est� o c�lice que eu te pedi?");
        }
    }
}
