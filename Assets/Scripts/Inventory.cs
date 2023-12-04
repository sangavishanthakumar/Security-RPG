using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count; // keep track of how many itmes are in the slot
        public int maxAllowed; // maximum allowed items
        public bool hasCollected; // tracks if item was collected

        public Slot()
        {
            type = CollectableType.NONE;
            hasCollected = false;
            count = 0;
            maxAllowed = 1;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }
            return false;
        }

        public void AddItem(CollectableType type)
        {
            this.type = type;
            count++;
            hasCollected = true;
        }
    }

    public List<Slot> slots = new List<Slot>(); // create list of slots

    // create constructor for the inventory

    public Inventory(int numSlots)
    {
        for(int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CollectableType typeToAdd) { 
        foreach( Slot slot in slots)
        {
            if(slot.type == typeToAdd && slot.CanAddItem())
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }

        foreach( Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }
}
