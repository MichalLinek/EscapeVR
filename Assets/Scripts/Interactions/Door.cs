using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Door : MonoBehaviour
{
    public float smooth = 2.0f;
    public float delayInSeconds = 0;
    public float DoorOpenAngle = 90.0f;
    public GameObject GameObjectLock;
    public AudioClip OpeningAudioClip;
    public AudioClip ClosingAudioClip;
    public AudioClip LockedAudioClip;

    private bool open = false;
    private AudioSource audioSource;
    private Vector3 defaultRot;
    private Vector3 openRot;
    private LockMechanismAbstract padlockManager;
    private bool IsLocked = false;
    private bool IsIdle = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (GameObjectLock != null)
        {
            padlockManager = GameObjectLock.GetComponent<LockMechanismAbstract>();
            padlockManager.LockCracked += PadlockManager_LockCracked;
            IsLocked = true;
            audioSource.clip = LockedAudioClip;
        }

        defaultRot = transform.localEulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    private void PadlockManager_LockCracked(object sender, System.EventArgs e)
    {
        IsLocked = false;
        padlockManager.LockCracked -= PadlockManager_LockCracked;
    }
    
    public void ToggleDoor()
    {
        if (!IsIdle)
        {
            if (!IsLocked)
            {
                IsIdle = true;
                if (animator != null && !open)
                {
                    animator.SetBool("IsOpening", true);
                }
                OpenDoor();
            }
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        if (animator != null)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.IsName("Door"))
            {
                animator.SetBool("IsOpening", false);
            }
        }
    }

    private void OpenDoor()
    {
        open = !open;
        if (open)
        {
            audioSource.clip = OpeningAudioClip;
            StartCoroutine(OpenEnumerator());
        }
        else
        {
            audioSource.clip = ClosingAudioClip;
            StartCoroutine(CloseEnumerator());
        }
    }

    private IEnumerator OpenEnumerator()
    {
        while (Vector3.Distance(transform.localEulerAngles, openRot) >= 0.1f)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, openRot, Time.deltaTime * smooth);
            yield return new WaitForSeconds(delayInSeconds);
        }

        IsIdle = false;
    }

    private IEnumerator CloseEnumerator()
    {
        while (Vector3.Distance(transform.localEulerAngles, defaultRot) >= 0.1f)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, defaultRot, Time.deltaTime * smooth);
            yield return null;
        }

        IsIdle = false;
    }
}