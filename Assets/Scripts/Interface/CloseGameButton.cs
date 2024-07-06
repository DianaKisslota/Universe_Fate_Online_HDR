using UnityEngine;
using UnityEngine.UI;

public class CloseGameButton : MonoBehaviour
{
    // Публичный метод, который будет вызываться при нажатии на кнопку
    public void CloseGame()
    {
        // Закрываем приложение
        Application.Quit();
    }
}
