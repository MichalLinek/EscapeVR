using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets;

public class InventoryScript : MonoBehaviour
{
    public List<ICollectibleItem> items = new List<ICollectibleItem>();
    public int CurrentItem = 0;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.DpadDown) || Input.GetKeyDown(KeyCode.K))
        {
            if (items.Count > 1)
            {
                items[CurrentItem].Deactivate();
                CurrentItem += 1;
                if (CurrentItem >= items.Count)
                {
                    CurrentItem = 0;
                }
                items[CurrentItem].Activate();
            }
        }
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void AddToInventory(ICollectibleItem item)
    {
        if (!IsEmpty())
        {
            items[CurrentItem].Deactivate();
        }

        items.Add(item);
        CurrentItem = items.IndexOf(item);
        items[CurrentItem].Activate();
    }

    public ICollectibleItem GetCurrentItem()
    {
        return items[CurrentItem];
    }

    public void SetNextItem()
    {
        if (!IsEmpty())
        {
            CurrentItem += 1;
            if (CurrentItem >= items.Count)
            {
                CurrentItem = 0;
            }
            items[CurrentItem].Activate();
        }
    }
}
