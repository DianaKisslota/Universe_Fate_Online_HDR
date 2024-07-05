using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    private bool isFullscreen = true; // ����������, �����������, ��������� �� ���� � ������������� ������ � ������ ������

    void Start()
    {
        // ��������� ������� ToggleFullscreen() ��� ���������� ������� ������
        GetComponent<Button>().onClick.AddListener(ToggleFullscreen);
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen; // ����������� ��������� ���������� �������������� ������

        // �������� ����� ������ � ����������� �� �������� ���������
        Screen.fullScreen = isFullscreen;
    }
}
