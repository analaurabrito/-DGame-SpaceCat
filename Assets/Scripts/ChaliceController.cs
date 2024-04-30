using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaliceController : ItemPickup
{
    public bool isPicked;

    public override void PickUp()
    {
        base.PickUp();
        isPicked = true;
    }
}
