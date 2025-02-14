using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.InteropServices;

public class MinimizeGame : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public Button minimizeButton; // ������, ������� ����� ����������� ����

    void Start()
    {
        // ���������, ��������� �� ������
        if (minimizeButton != null)
        {
            // ��������� ������� OnMinimizeButtonClick() ��� ���������� ������� ������
            minimizeButton.onClick.AddListener(OnMinimizeButtonClick);
        }
    }

    public void OnMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }
}
