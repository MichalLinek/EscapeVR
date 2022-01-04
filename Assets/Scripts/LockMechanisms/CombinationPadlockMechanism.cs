using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

public class CombinationPadlockMechanism : LockMechanismAbstract
{
    public string Code = "ABCD";
    private char[] currentGuess = new char[4];
    private GameObject Handle;
    public override event EventHandler LockCracked;
    private Animator animator;
    private AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        this.Handle = transform.Find("Handle").gameObject;
    }

    public override void CrackLock()
    {
        if (Code.Equals(new string(currentGuess)))
        {
            animator.SetInteger("success", 1);
            StartCoroutine(KillOnAnimationEnd());
            OnLockCracked(EventArgs.Empty);
        }
        else
        {
            animator.SetInteger("success", 2);
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Locked"))
        {
            animator.SetInteger("success", 0);
        }
    }

    public void Toggle(int currentSlot, char currentValue)
    {
        currentGuess[currentSlot] = currentValue;
    }

    private void OnLockCracked(EventArgs e)
    {
        EventHandler handler = LockCracked;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.45f);
        Destroy(gameObject);
    }
}
