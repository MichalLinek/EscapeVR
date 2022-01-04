using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;
using Assets;

public class SimplePadlockMechanism : LockMechanismAbstract {

    public KeyCollectible Key;
    public InventoryScript inventory;
    public override event EventHandler LockCracked;

    private GameObject Handle;
    private Animator animator;
    private AudioSource audioSource;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        this.Handle = transform.Find("Handle").gameObject;
    }

    private void OnLockCracked(EventArgs e)
    {
        EventHandler handler = LockCracked;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public override void CrackLock()
    {
        if (inventory.items.Count > 0 && inventory.items[inventory.CurrentItem] == Key)
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

    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(0.45f);
        Destroy(gameObject);
    }
}
