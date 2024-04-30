using UnityEngine;

public class ItemPickup : Interactable
{
    public override void Interact()
    {
        PickUp();
    }

    public virtual void PickUp()
    {
        Debug.Log("Picking up item.");
        Destroy(gameObject);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

}
