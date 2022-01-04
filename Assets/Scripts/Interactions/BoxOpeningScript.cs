using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class BoxOpeningScript : MonoBehaviour
{
    public GameObject GameObjectLock;
    public float delayInSeconds = 0;
    public Vector3 targetAngle = new Vector3(0f, 345f, 0f);
    public AudioClip OpeningAudioClip;
    public AudioClip ClosingAudioClip;
    public AudioClip LockedAudioClip;

    private bool IsIdle = false;
    private bool open = false;
    private LockMechanismAbstract lockMechanism;
    private bool IsLocked = false;
    private float yAxis = 136.1f;
    private float zAxis = 270f;
    private float xAxis = 270f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = OpeningAudioClip;
        yAxis = transform.rotation.eulerAngles.y;
        zAxis = transform.rotation.eulerAngles.z;
        if (GameObjectLock != null)
        {
            lockMechanism = GameObjectLock.GetComponent<LockMechanismAbstract>();
            lockMechanism.LockCracked += PadlockManager_LockCracked;
            IsLocked = true;
            audioSource.clip = LockedAudioClip;
        }
    }

    private void PadlockManager_LockCracked(object sender, System.EventArgs e)
    {
        IsLocked = false;
        lockMechanism.LockCracked -= PadlockManager_LockCracked;
    }

    public void ToggleDoor()
    {
        if (!IsIdle)
        {
            IsIdle = true;
            if (!IsLocked)
            {
                Invoke("OpenBox", delayInSeconds);
                Invoke("SetNotIdle", delayInSeconds + 4);
            }
            audioSource.Play();
        }
        else
        {
            if (IsLocked)
                audioSource.Play();
        }
    }

    private void OpenBox()
    {
        open = !open;
    }

    private void SetNotIdle()
    {
        IsIdle = false;
        if (!open)
        {
            audioSource.clip = OpeningAudioClip;
        }
        else
        {
            audioSource.clip = ClosingAudioClip;
        }
    }

    void Update()
    {
        if (open)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetAngle.x, targetAngle.y, targetAngle.z), Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(270, targetAngle.y, targetAngle.z), Time.deltaTime * 2);
        }
    }
}