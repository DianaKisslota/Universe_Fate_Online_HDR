using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField chatInput; // Поле для ввода сообщений
    public TMP_Text chatLog;         // Поле для отображения чата
    public ScrollRect scrollRect; // Для автоматической прокрутки

    // Метод отправки сообщений
    public void SendMessageToChat()
    {
        // Проверяем, что текст не пустой
        if (!string.IsNullOrEmpty(chatInput.text))
        {
            // Добавляем сообщение в лог чата
            string newMessage = "Player: " + chatInput.text;
            chatLog.text += newMessage + "\n";

            // Очищаем поле ввода после отправки
            chatInput.text = "";

            // Прокручиваем чат вниз
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
            Canvas.ForceUpdateCanvases();
        }
    }

    // Отправка сообщений при нажатии на Enter
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToChat();
        }
    }
}
