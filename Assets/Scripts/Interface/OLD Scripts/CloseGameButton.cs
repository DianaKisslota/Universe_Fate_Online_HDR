using UnityEngine;
using UnityEngine.UI;

public class CloseGameButton : MonoBehaviour
{
    public Button closeButton; // Кнопка для закрытия приложения

    void Start()
    {
        // Проверяем, назначена ли кнопка
        if (closeButton != null)
        {
            // Назначаем функцию CloseGame() как обработчик нажатия кнопки
            closeButton.onClick.AddListener(CloseGame);
        }
    }

    public void CloseGame()
    {
        // Закрываем приложение
        Application.Quit();

        // Если вы работаете в редакторе Unity, остановите воспроизведение
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
