using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField chatInput;  // ���� ��� �����
    public TextMeshProUGUI chatLog;   // ��� ���� (TextMeshPro)
    public ScrollRect scrollRect;     // ScrollRect ��� ���������� ����������

    private void Start()
    {
        // ������� ��� ���� ��� ������ ����
        chatLog.text = "";
    }

    // ����� �������� ��������� � ���
    public void SendMessageToChat()
    {
        // ���������, ��� ���� ����� �� ������
        if (!string.IsNullOrEmpty(chatInput.text))
        {
            // ��������� ��������� � ���
            string newMessage = "Player: " + chatInput.text;
            chatLog.text += newMessage + "\n";

            // ������� ���� ����� ����� ��������
            chatInput.text = "";

            // ������������ ��� ����
            ScrollToBottom();
        }
    }

    // ����� ��������� ���� ����
    private void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0f;
        Canvas.ForceUpdateCanvases();
    }

    private void Update()
    {
        // �������� ��������� ��� ������� ������� Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToChat();
        }

        // ��������� � �������������� �������� ����
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            scrollRect.verticalNormalizedPosition += scroll * 0.1f;  // �������� ���������
        }
    }
}
