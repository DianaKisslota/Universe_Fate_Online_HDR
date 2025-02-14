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

    public Button minimizeButton; // Кнопка, которая будет сворачивать окно

    void Start()
    {
        // Проверяем, назначена ли кнопка
        if (minimizeButton != null)
        {
            // Назначаем функцию OnMinimizeButtonClick() как обработчик нажатия кнопки
            minimizeButton.onClick.AddListener(OnMinimizeButtonClick);
        }
    }

    public void OnMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }
}
