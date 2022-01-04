using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonScript : MonoBehaviour
{
    private PanelLockMechanism controller;
    private AudioSource audioSource;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        controller = transform.parent.parent.Find("Display").GetComponent<PanelLockMechanism>();
    }

    public void Click()
    {
        animator.SetBool("IsPressed", true);
        audioSource.Play();
        controller.RemoveSymbol();
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