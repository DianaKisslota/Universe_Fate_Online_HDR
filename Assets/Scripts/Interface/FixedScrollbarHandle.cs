using UnityEngine;
using UnityEngine.UI;

public class FixedScrollbarSize : MonoBehaviour
{
    public Scrollbar scrollbar;      // Ссылка на скроллбар
    public float fixedHandleSize = 0.1f; // Фиксированный размер ползунка (от 0 до 1)

    void Start()
    {
        // Устанавливаем фиксированный размер ползунка после загрузки сцены
        SetFixedHandleSize();
    }

    void SetFixedHandleSize()
    {
        if (scrollbar != null)
        {
            // Устанавливаем фиксированный размер ползунка
            scrollbar.size = fixedHandleSize;

            // Принудительно обновляем ползунок
            Canvas.ForceUpdateCanvases();
        }
    }
}
