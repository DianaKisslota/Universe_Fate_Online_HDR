using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;

    private int _count;
    public Item Item { get; set; }

    public Sprite Icon 
    { set {_icon.sprite = value;}}

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            if (value > 0)
                _countText.text = value.ToString();
            else
                _countText.text = string.Empty;
        }
    }
}
