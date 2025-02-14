using UnityEngine;
using UnityEngine.UI;

public class FixedScrollRect : ScrollRect
{
    [Range(0f, 1f)]
    public float fixedScrollbarSize = 0.2f; // ������������� ������ �������� �� 0 �� 1

    protected override void SetNormalizedPosition(float value, int axis)
    {
        base.SetNormalizedPosition(value, axis);

        // ������� ������������� ������ �������� �� ������������� ��������
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }

    protected override void SetContentAnchoredPosition(Vector2 position)
    {
        base.SetContentAnchoredPosition(position);

        // ��������� ������ ��������, ���� ��� �������� ����������
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        // ��������� ������ �������� ������ ����
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }
}
