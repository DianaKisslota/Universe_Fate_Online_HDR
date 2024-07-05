using UnityEngine;
using UnityEngine.UI;

public class CloseGameButton : MonoBehaviour
{
    public Button closeButton; // ������ ��� �������� ����������

    void Start()
    {
        // ���������, ��������� �� ������
        if (closeButton != null)
        {
            // ��������� ������� CloseGame() ��� ���������� ������� ������
            closeButton.onClick.AddListener(CloseGame);
        }
    }

    public void CloseGame()
    {
        // ��������� ����������
        Application.Quit();

        // ���� �� ��������� � ��������� Unity, ���������� ���������������
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
