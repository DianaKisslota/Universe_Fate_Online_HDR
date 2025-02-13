using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimatorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;
    private EventTrigger eventTrigger;

    private void Start()
    {
        // Получаем компонент Animator
        animator = GetComponent<Animator>();

        // Получаем компонент EventTrigger
        eventTrigger = GetComponent<EventTrigger>();

        // Проверяем, есть ли EventTrigger на объекте
        if (eventTrigger == null)
        {
            Debug.LogWarning("EventTrigger не найден на кнопке. Добавьте компонент EventTrigger.");
        }
    }

    // При наведении курсора
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Включаем анимацию наведения
        animator.SetBool("IsHover", true);
    }

    // При уходе курсора
    public void OnPointerExit(PointerEventData eventData)
    {
        // Отключаем анимацию наведения
        animator.SetBool("IsHover", false);
    }

    // При нажатии на кнопку
    public void OnPointerDown(PointerEventData eventData)
    {
        // Отключаем EventTrigger, чтобы звук наведения не воспроизводился
        if (eventTrigger != null)
        {
            eventTrigger.enabled = false;
        }

        // Включаем анимацию нажатия
        animator.SetBool("IsPressed", true);
    }

    // При отпускании кнопки
    public void OnPointerUp(PointerEventData eventData)
    {
        // Включаем EventTrigger обратно
        if (eventTrigger != null)
        {
            eventTrigger.enabled = true;
        }

        // Отключаем анимацию нажатия
        animator.SetBool("IsPressed", false);
    }
}