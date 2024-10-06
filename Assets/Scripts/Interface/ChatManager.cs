using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public TMP_InputField chatInput; // ���� ��� ����� ���������
    public TMP_Text chatLog;         // ���� ��� ����������� ����
    public ScrollRect scrollRect; // ��� �������������� ���������

    // ����� �������� ���������
    public void SendMessageToChat()
    {
        // ���������, ��� ����� �� ������
        if (!string.IsNullOrEmpty(chatInput.text))
        {
            // ��������� ��������� � ��� ����
            string newMessage = "Player: " + chatInput.text;
            chatLog.text += newMessage + "\n";

            // ������� ���� ����� ����� ��������
            chatInput.text = "";

            // ������������ ��� ����
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
            Canvas.ForceUpdateCanvases();
        }
    }

    // �������� ��������� ��� ������� �� Enter
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToChat();
        }
    }
}
