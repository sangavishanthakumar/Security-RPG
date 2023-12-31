using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class makes a object collectable
 * The object itself needs to be a collision (for example a BoxCollision2D)
 */
public class Collectable : MonoBehaviour
{
    public CollectableType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>(); // get the player script

        if(player)
        {
            Debug.Log("Triggered with " + collision.gameObject.name);
            player.inventory.Add(type);
            //player.usb++;
            Destroy(this.gameObject);
        }
    }


}

public enum CollectableType
{
    NONE, USB //NONE = 0, USB = 1 by default
}
