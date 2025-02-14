using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimatorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;
    private EventTrigger eventTrigger;

    private void Start()
    {
        // �������� ��������� Animator
        animator = GetComponent<Animator>();

        // �������� ��������� EventTrigger
        eventTrigger = GetComponent<EventTrigger>();

        // ���������, ���� �� EventTrigger �� �������
        if (eventTrigger == null)
        {
            Debug.LogWarning("EventTrigger �� ������ �� ������. �������� ��������� EventTrigger.");
        }
    }

    // ��� ��������� �������
    public void OnPointerEnter(PointerEventData eventData)
    {
        // �������� �������� ���������
        animator.SetBool("IsHover", true);
    }

    // ��� ����� �������
    public void OnPointerExit(PointerEventData eventData)
    {
        // ��������� �������� ���������
        animator.SetBool("IsHover", false);
    }

    // ��� ������� �� ������
    public void OnPointerDown(PointerEventData eventData)
    {
        // ��������� EventTrigger, ����� ���� ��������� �� ���������������
        if (eventTrigger != null)
        {
            eventTrigger.enabled = false;
        }

        // �������� �������� �������
        animator.SetBool("IsPressed", true);
    }

    // ��� ���������� ������
    public void OnPointerUp(PointerEventData eventData)
    {
        // �������� EventTrigger �������
        if (eventTrigger != null)
        {
            eventTrigger.enabled = true;
        }

        // ��������� �������� �������
        animator.SetBool("IsPressed", false);
    }
}