using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawInventoryItemScript : MonoBehaviour {

    public InventoryScript inventory;
    private int preferredSize = 100;
    private Texture txtSelected;

    //void Start()
    //{
    //    txtSelected = Resources.Load<Texture>("selected");
    //    GUI.DrawTexture(new Rect(0, 0, 100, 200), txtSelected);
    //}
    //void OnGUI()
    //{
    //    for (int i = 0; i < inventory.items.Count; i++)
    //    {
    //        Texture texture = inventory.items[i].GetComponent<GUITexture>().texture;
    //        GUI.DrawTexture(new Rect(10 + i * 60, screenHeigth - 60, 50, 50),texture, ScaleMode.StretchToFill, true, 10.0F);

    //        if (inventory.CurrentItem == i)
    //        {
    //            txtSelected = Resources.Load<Texture>("selected");
    //            GUI.DrawTexture(new Rect(10 + i * 60, screenHeigth - 60, 50, 50), txtSelected, ScaleMode.StretchToFill, true, 10.0F);
    //        }
    //    }
    //}
}
