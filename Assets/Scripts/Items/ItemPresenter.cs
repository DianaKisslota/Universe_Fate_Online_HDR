using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPresenter : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;

    private Transform _transportPanel;
    private Transform _oldParent;
    protected CanvasGroup _canvasGroup;
    protected RectTransform _rectTransform;

    private int _count;
    public Item Item { get; set; }

    public Transform OldParent => _oldParent;

    public Sprite Icon 
    { set {_icon.sprite = value;}}

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            if (value > 1)
                _countText.text = value.ToString();
            else
                _countText.text = string.Empty;
        }
    }

    private void Start()
    {
        _transportPanel = GameObject.Find("TransportPanel").transform;
        _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _oldParent = transform.parent;
        transform.SetParent(_transportPanel);
        transform.localEulerAngles = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;// / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == _transportPanel)
        {
            transform.SetParent(_oldParent);
            transform.localPosition = Vector2.zero;
        }
        if (transform.parent.gameObject.TryGetComponent<ItemSlot>(out var itemSlot) && itemSlot.SlotType == SlotType.Shoulder)
        {
            eventData.pointerDrag.transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        _canvasGroup.blocksRaycasts = true;
    }
}
