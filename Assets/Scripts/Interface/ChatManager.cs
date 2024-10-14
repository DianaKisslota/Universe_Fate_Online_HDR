using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button sendButton;
    public Transform messagesContainer;
    public ScrollRect scrollRect;
    public GameObject messagePrefab;  // Префаб для сообщений

    void Start()
    {
        if (sendButton != null)
        {
            sendButton.onClick.AddListener(SendMessage);
        }
        else
        {
            Debug.LogError("Send Button is not assigned in the inspector.");
        }

        if (inputField != null)
        {
            inputField.onSubmit.AddListener(delegate { SendMessage(); });
        }
        else
        {
            Debug.LogError("Input Field is not assigned in the inspector.");
        }
    }

    void SendMessage()
    {
        if (messagesContainer == null)
        {
            Debug.LogError("Messages Container is not assigned in the inspector.");
            return;
        }

        if (inputField == null)
        {
            Debug.LogError("Input Field is not assigned.");
            return;
        }

        if (!string.IsNullOrEmpty(inputField.text))
        {
            // Используем префаб для нового сообщения
            GameObject newMessage = Instantiate(messagePrefab, messagesContainer);

            TMP_Text messageText = newMessage.GetComponent<TMP_Text>();
            if (messageText != null)
            {
                messageText.text = inputField.text;
                inputField.text = "";
                ScrollToBottom();
            }
            else
            {
                Debug.LogError("Message Prefab does not contain a TMP_Text component.");
            }
        }
    }

    void ScrollToBottom()
    {
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0;
            Canvas.ForceUpdateCanvases();
        }
        else
        {
            Debug.LogError("Scroll Rect is not assigned in the inspector.");
        }
    }
}
