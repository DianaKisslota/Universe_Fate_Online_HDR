using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ItemPresenter : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _countText;
    [SerializeField] private TMP_Text _nameText;

    private Transform _transportPanel;
    private Transform _oldParent;
    protected CanvasGroup _canvasGroup;
    protected RectTransform _rectTransform;

    private int _count;
    private StoragePosition _storagePosition;
    public Item Item { get; set; }

    public Transform OldParent => _oldParent;

    public void HideName()
    {
        _nameText.gameObject.SetActive(false);
    }
    public Sprite Icon 
    { set {_icon.sprite = value;}}

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            if(_storagePosition != null)
                _storagePosition.Count = value;
            if (_count == 0)
                Destroy(gameObject);
            else
                RefreshInfo();
        }
    }

    public void SetStoragePosition(StoragePosition storagePosition)
    {
        _storagePosition = storagePosition;
    }

    public void RefreshInfo()
    {
        if (_count > 1)
            _countText.text = _count.ToString();
        else
           _countText.text = string.Empty;
        if (Item is RangeWeapon rangeWeapon)
        {
            _countText.text = rangeWeapon.AmmoCount.ToString() + "/" + rangeWeapon.AmmoCapacity.ToString();
        }
    }

    public string Name
    {
        set { _nameText.text = value; }
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
        if (_oldParent.TryGetComponent<DropSlot>(out var dropSlot))
            dropSlot.OnItemLeave(Item);
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

        if (transform.parent.gameObject.TryGetComponent<ItemSlot>(out var itemSlot))
        {
            if (itemSlot.SlotType == SlotType.Shoulder)
                eventData.pointerDrag.transform.localEulerAngles = new Vector3(0, 0, -90);
            _nameText.gameObject.SetActive(false);
        }
        else
            _nameText.gameObject.SetActive(true);

        _canvasGroup.blocksRaycasts = true;
    }
}
