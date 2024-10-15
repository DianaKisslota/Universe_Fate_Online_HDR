using UnityEngine;
using UnityEngine.UI;

public class FixedScrollRect : ScrollRect
{
    [Range(0f, 1f)]
    public float fixedScrollbarSize = 0.2f; // Фиксированный размер ползунка от 0 до 1

    protected override void SetNormalizedPosition(float value, int axis)
    {
        base.SetNormalizedPosition(value, axis);

        // Вручную устанавливаем размер ползунка на фиксированное значение
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }

    protected override void SetContentAnchoredPosition(Vector2 position)
    {
        base.SetContentAnchoredPosition(position);

        // Обновляем размер ползунка, если его значение изменяется
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();

        // Обновляем размер ползунка каждый кадр
        if (verticalScrollbar != null)
        {
            verticalScrollbar.size = fixedScrollbarSize;
        }
    }
}
