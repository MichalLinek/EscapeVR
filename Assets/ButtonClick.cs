using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private PanelLockMechanism controller;
    private AudioSource audioSource;
    private Animator animator;
    private Text text;

    public void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        controller = transform.parent.parent.Find("Display").GetComponent<PanelLockMechanism>();
    }

    public void Click()
    {
        animator.SetBool("IsPressed", true);
        audioSource.Play();
        controller.AddSymbol(text.text);
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
