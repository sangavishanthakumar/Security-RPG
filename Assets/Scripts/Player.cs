using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public bool usbIsCollected = false;
    public Inventory inventory;
    public GameObject DialogueBox;

    // create an inventory for the player
    private void Awake()
    {
        inventory = new Inventory(4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Computer"))
        {
            Console.WriteLine("Player entered Computer");
            // open dialogue box
            DialogueBox.SetActive(true);
            // start dialogue
            DialogueBox.GetComponent<Dialogue>().StartDialogue(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Computer"))
        {
            Console.WriteLine("Player exited Computer");
            // close dialogue box
            DialogueBox.SetActive(false);
            DialogueBox.GetComponent<Dialogue>().ClearDialogue();

        }
    }



}
