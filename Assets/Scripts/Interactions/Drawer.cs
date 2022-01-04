using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Drawer : MonoBehaviour
{
    public float smooth = 2.0f;
    public Vector3 DrawOpenPosition;
    private AudioSource audioSource;
    private bool open = false;
    public int drawIndex = -1;
    private bool IsIdle = false;

    private Vector3 basePosition;
    
    public GameObject GameObjectLock;
    private LockMechanismAbstract lockMechanism;
    private bool IsLocked = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (GameObjectLock != null)
        {
            lockMechanism = GameObjectLock.GetComponent<LockMechanismAbstract>();
            lockMechanism.LockCracked += PadlockManager_LockCracked;
            IsLocked = true;
        }

        basePosition = this.transform.localPosition;
    }

    private void PadlockManager_LockCracked(object sender, System.EventArgs e)
    {
        IsLocked = false;
        lockMechanism.LockCracked -= PadlockManager_LockCracked;
    }

    public void Toggle()
    {
        if (!IsIdle)
        {
            if (!IsLocked)
            {
                open = !open;
                IsIdle = true;
                audioSource.Play();
                if (open)
                {
                    StartCoroutine(OpenEnumerator());
                }
                else
                {
                    StartCoroutine(CloseEnumerator());
                }
            }
        }
    }

    private IEnumerator OpenEnumerator()
    {
        while (Vector3.Distance(transform.localPosition, DrawOpenPosition) >= 0.00001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, DrawOpenPosition, Time.deltaTime * smooth);
            yield return null;
        }
        IsIdle = false;
    }

    private IEnumerator CloseEnumerator()
    {
        while (Vector3.Distance(transform.localPosition, basePosition) >= 0.00001f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, basePosition, Time.deltaTime * smooth);
            yield return null;
        }
        IsIdle = false;
    }
}