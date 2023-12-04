using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public bool usbIsCollected = false;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(4);
    }
}
