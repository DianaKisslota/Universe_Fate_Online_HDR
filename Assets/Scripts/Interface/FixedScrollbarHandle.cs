using UnityEngine;
using UnityEngine.UI;

public class FixedScrollbarSize : MonoBehaviour
{
    public Scrollbar scrollbar;      // ������ �� ���������
    public float fixedHandleSize = 0.1f; // ������������� ������ �������� (�� 0 �� 1)

    void Start()
    {
        // ������������� ������������� ������ �������� ����� �������� �����
        SetFixedHandleSize();
    }

    void SetFixedHandleSize()
    {
        if (scrollbar != null)
        {
            // ������������� ������������� ������ ��������
            scrollbar.size = fixedHandleSize;

            // ������������� ��������� ��������
            Canvas.ForceUpdateCanvases();
        }
    }
}
