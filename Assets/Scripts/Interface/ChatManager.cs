using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField chatInput;  // Поле для ввода
    public TextMeshProUGUI chatLog;   // Лог чата (TextMeshPro)
    public ScrollRect scrollRect;     // ScrollRect для управления прокруткой

    private void Start()
    {
        // Очищаем лог чата при старте игры
        chatLog.text = "";
    }

    // Метод отправки сообщения в чат
    public void SendMessageToChat()
    {
        // Проверяем, что поле ввода не пустое
        if (!string.IsNullOrEmpty(chatInput.text))
        {
            // Добавляем сообщение в лог
            string newMessage = "Player: " + chatInput.text;
            chatLog.text += newMessage + "\n";

            // Очищаем поле ввода после отправки
            chatInput.text = "";

            // Прокручиваем лог вниз
            ScrollToBottom();
        }
    }

    // Метод прокрутки чата вниз
    private void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }

    private void Update()
    {
        // Отправка сообщения при нажатии клавиши Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToChat();
        }

        // Прокрутка с использованием колесика мыши
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            scrollRect.verticalNormalizedPosition += scroll * 0.1f;  // Скорость прокрутки
        }
    }
}
