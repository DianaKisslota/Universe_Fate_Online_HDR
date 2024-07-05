using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject staticWindow;
    public AudioSource popupSound;

    // ���������� ��� ������� �� UI ������ ��� �������� ��� �������� ������������ ����
    public void TogglePopup()
    {
        if (popupWindow != null)
        {
            bool newState = !popupWindow.activeSelf; // ����� ��������� ������������ ����

            popupWindow.SetActive(newState);

            // ���� ����������� ���� �������, ��������� ����������� ����
            if (newState && staticWindow != null)
            {
                staticWindow.SetActive(false);
            }
            // ���� ����������� ���� �������, ��������� ����������� ����
            else if (!newState && staticWindow != null)
            {
                staticWindow.SetActive(true);
            }

            // ������������� ���� ��� �������� ������������ ����
            if (newState && popupSound != null)
            {
                popupSound.Play();
            }
        }
    }

    void Update()
    {
        // ��������� ������� �� ������� Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� ����������� ���� �������, ��������� ���
            if (popupWindow.activeSelf)
            {
                TogglePopup();
            }
            // ���� ����������� ���� �������, ��������� ���
            else
            {
                TogglePopup();
            }
        }
    }
}
