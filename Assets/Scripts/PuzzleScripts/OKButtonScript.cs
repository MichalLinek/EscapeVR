using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OKButtonScript : MonoBehaviour
{
    public AudioClip successClip;
    public AudioClip wrongClip;
    private Animator animator;
    private PanelLockMechanism controller;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        controller = transform.parent.parent.Find("Display").GetComponent<PanelLockMechanism>();
    }

    public void Click()
    {
        animator.SetBool("IsPressed", true);
        if (controller.Check())
        {
            audioSource.clip = successClip;
        }
        else
        {
            audioSource.clip = wrongClip;
        }

        audioSource.Play();
    }

    void FixedUpdate()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Press"))
        {
            animator.SetBool("IsPressed", false);
        }
    }
}