using UnityEngine;

public class Show_hide_inventory : MonoBehaviour
{
    public static Show_hide_inventory Instance;

    public GameObject panel; // ������, ������� ����� �������/�������

    private void Awake()
    {
        // ������������, ��� ��������� ��������� ������������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ����� ��� ������������ ��������� ������
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}
