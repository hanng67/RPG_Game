using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool canPickup;

    private void Update()
    {
        if(canPickup && Input.GetButtonDown("Fire1") && PlayerMgr.Instance.PMove.CanMove){
            PlayerMgr.Instance.BagInventory.AddItem(GetComponent<GroundItem>().ItemSlot);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player")
        {
            canPickup = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Player")
        {
            canPickup = false;
        }
    }
}
