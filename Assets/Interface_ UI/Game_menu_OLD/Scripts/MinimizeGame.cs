using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class MinimizeWindow : MonoBehaviour
{

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    static public void OnMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }



}