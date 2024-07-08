using UnityEngine;
using UnityEngine.UI;
using System;

public class FullscreenToggle : MonoBehaviour
{
    private bool isFullscreen = true; // Переменная, указывающая, находится ли игра в полноэкранном режиме в данный момент

    public Button fullscreenButton; // Кнопка, которая будет переключать полноэкранный режим

    void Start()
    {
        // Проверяем, назначена ли кнопка
        if (fullscreenButton != null)
        {
            // Назначаем функцию ToggleFullscreen() как обработчик нажатия кнопки
            fullscreenButton.onClick.AddListener(ToggleFullscreen);
        }
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen; // Инвертируем состояние переменной полноэкранного режима

        // Изменяем режим экрана в зависимости от текущего состояния
        Screen.fullScreen = isFullscreen;
    }
}
