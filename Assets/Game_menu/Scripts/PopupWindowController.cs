using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopupWindowController : MonoBehaviour, IPointerEnterHandler
{
    public GameObject imgObject; // Дочерний объект img

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Активируем дочерний объект при наведении на кнопку
        imgObject.SetActive(true);
    }

    private void OnDisable()
    {
        // Отключаем дочерний объект при закрытии всплывающего окна
        imgObject.SetActive(false);
    }
}
