using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimatorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter()
    {
        animator.SetTrigger("Hover");
    }

    public void OnPointerExit()
    {
        animator.SetTrigger("Normal");
    }

    public void OnPointerDown()
    {
        animator.SetTrigger("PointerDown");
    }

    public void OnPointerClick()
    {
        animator.SetTrigger("Pressed");
    }
}