using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    private bool isFullscreen = true; // Переменная, указывающая, находится ли игра в полноэкранном режиме в данный момент

    void Start()
    {
        // Назначаем функцию ToggleFullscreen() как обработчик нажатия кнопки
        GetComponent<Button>().onClick.AddListener(ToggleFullscreen);
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen; // Инвертируем состояние переменной полноэкранного режима

        // Изменяем режим экрана в зависимости от текущего состояния
        Screen.fullScreen = isFullscreen;
    }
}
