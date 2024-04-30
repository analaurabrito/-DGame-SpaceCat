using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureController : Interactable
{
    public Animator itemAnimator;
    public Animator altarAnimator;
    public bool isEnabled = false;
    public NPCController npc;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Interact()
    {
        if (npc.fistInteraction && !isEnabled)
        {
            altarAnimator.SetTrigger("Trigger");
            itemAnimator.SetBool("Appeared", true);
        }
    }
}