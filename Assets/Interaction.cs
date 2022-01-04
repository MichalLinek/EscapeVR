using UnityEngine;
using System.Collections;
using Assets.Scripts;
using Assets;

public class Interaction : MonoBehaviour {

    public InventoryScript inventory;
    
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.O))
        {
            if (!inventory.IsEmpty())
            {
                ICollectibleItem item = inventory.GetCurrentItem();
                if (item != null)
                {
                    item.TriggerAction();
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0) && (Physics.Raycast(transform.position, fwd, out hit,2)))
        {
            if (hit.transform.tag.Equals("Collectible"))
            {
                ICollectibleItem gameObject = hit.transform.GetComponent<ICollectibleItem>();
                gameObject.SetUpItem();
                inventory.AddToInventory(gameObject);
            }
            if (hit.transform.tag.Equals("PadlockHandle"))
            {
                LockMechanismAbstract combinationPadlockMechanism = hit.transform.gameObject.GetComponentInParent<LockMechanismAbstract>();
                combinationPadlockMechanism.CrackLock();
            }
            if (hit.transform.tag == "Open")
            {
                GameObject gameObject = hit.transform.gameObject;
                gameObject.SendMessage("ToggleDoor");
            }
            if (hit.transform.tag == "BoxOpen")
            {
                GameObject gameObject = hit.transform.gameObject;
                gameObject.SendMessage("ToggleDoor");
            }
            
            if (hit.transform.tag.Equals("Circle") || hit.transform.tag.Equals("Drawer") || hit.transform.tag.Equals("LightSwitch"))
            {
                GameObject gameObject = hit.transform.gameObject;
                gameObject.SendMessage("Toggle");
            }

            if (hit.transform.tag.Equals("PlaceHolder"))
            {
                GameObject gameObject = hit.transform.gameObject;
                gameObject.SendMessage("Put");
            }

            if (hit.transform.tag.Equals("Painting"))
            {
                Painting paintingScript = hit.transform.GetComponent<Painting>();
                if (paintingScript != null)
                {
                    paintingScript.TogglePainting();
                }
            }

            if (hit.transform.tag == "Button")
            {
                ButtonClick buttonClick = hit.transform.GetComponent<ButtonClick>();
                if (buttonClick != null)
                {
                    buttonClick.Click();
                }
                else
                {
                    DeleteButtonScript deleteButtonScript = hit.transform.GetComponent<DeleteButtonScript>();
                    if (deleteButtonScript != null)
                    {
                        deleteButtonScript.Click();
                    }
                    else
                    {
                        OKButtonScript OkButton = hit.transform.GetComponent<OKButtonScript>();
                        if (OkButton != null)
                        {
                            OkButton.Click();
                        }
                    }
                }
            }
            if (hit.transform.tag == "CombinationPuzzleSlot")
            {
                CombinationPadlockSlot combinationLetterPadlockSlot = hit.transform.GetComponent<CombinationPadlockSlot>();
                if (combinationLetterPadlockSlot != null)
                {
                    combinationLetterPadlockSlot.Toggle();
                }
            }
        }
    }
}
