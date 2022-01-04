using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderScript : MonoBehaviour {

    public GameObject ObjectToPlace;
    public Transform Place;
    public InventoryScript inventory;

    void Put()
    {
        if (!inventory.IsEmpty())
        {
            ICollectibleItem item = ObjectToPlace.GetComponent<ICollectibleItem>();
            if (item != null && item == inventory.GetCurrentItem())
            {
                ObjectToPlace.transform.parent = Place;
                ObjectToPlace.transform.position = new Vector3(0, 0, 0);
                ObjectToPlace.transform.localScale = new Vector3(0.1f, ObjectToPlace.transform.localScale.y, ObjectToPlace.transform.localScale.z);
                ObjectToPlace.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
                ObjectToPlace.transform.localPosition = new Vector3(0, 0, 0);
                inventory.items.Remove(item);
                inventory.SetNextItem();
                (item as PaperCollectible).PutElement();
                ObjectToPlace.layer = 1;
            }
        }
    }
}
