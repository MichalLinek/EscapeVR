using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class InteractionMenu : MonoBehaviour
{
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0) && (Physics.Raycast(transform.position, fwd, out hit,1000)))
        {
            if (hit.transform.tag.Equals("ButtonUI"))
            {
                MenuManagerScript menuManager = new MenuManagerScript();
                GameObject gameObject = hit.transform.gameObject;

                if (gameObject.name.Equals("StartButton"))
                {
                    menuManager.StartGame();
                }
                else if (gameObject.name.Equals("ControlsButton"))
                {
                    menuManager.OpenControlsLevel();
                }
            }
        }
    }
}
