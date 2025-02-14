using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class PopupWindowController : MonoBehaviour, IPointerEnterHandler
{
    public GameObject imgObject; // �������� ������ img

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ���������� �������� ������ ��� ��������� �� ������
        imgObject.SetActive(true);
    }

    private void OnDisable()
    {
        // ��������� �������� ������ ��� �������� ������������ ����
        imgObject.SetActive(false);
    }
}
