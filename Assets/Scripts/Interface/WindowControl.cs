using UnityEngine;
using UnityEngine.UI;
using System;

public class FullscreenToggle : MonoBehaviour
{
    private bool isFullscreen = true; // ����������, �����������, ��������� �� ���� � ������������� ������ � ������ ������

    public Button fullscreenButton; // ������, ������� ����� ����������� ������������� �����

    void Start()
    {
        // ���������, ��������� �� ������
        if (fullscreenButton != null)
        {
            // ��������� ������� ToggleFullscreen() ��� ���������� ������� ������
            fullscreenButton.onClick.AddListener(ToggleFullscreen);
        }
    }

    void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen; // ����������� ��������� ���������� �������������� ������

        // �������� ����� ������ � ����������� �� �������� ���������
        Screen.fullScreen = isFullscreen;
    }
}
