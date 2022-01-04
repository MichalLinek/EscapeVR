using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class DoorLeft : MonoBehaviour
{
    public float smooth = 2.0f;
    public float DoorOpenAngle = 90.0f;
    private bool open = false;
    public int doorIndex = -1;

    private Vector3 defaultRot;
    private Vector3 openRot;
    
    public GameObject GameObjectLock;
    private LockMechanismAbstract padlockManager;
    private bool IsLocked = false;

    void Start()
    {
        if (GameObjectLock != null)
        {
            padlockManager = GameObjectLock.GetComponent<LockMechanismAbstract>();
            padlockManager.LockCracked += PadlockManager_LockCracked;
            IsLocked = true;
        }
        defaultRot = transform.localEulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y, defaultRot.z - DoorOpenAngle);
    }

    private void PadlockManager_LockCracked(object sender, System.EventArgs e)
    {
        IsLocked = false;
        padlockManager.LockCracked -= PadlockManager_LockCracked;
    }

    public void ToggleDoor()
    {
        if (!IsLocked)
        {
            open = !open;
        }
    }

    void Update()
    {
        if (open)
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRot), 50 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(openRot), 2 * Time.deltaTime);
        }
        else
        {
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(openRot), 2 * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(defaultRot), 2 * Time.deltaTime);
        }
    }
}