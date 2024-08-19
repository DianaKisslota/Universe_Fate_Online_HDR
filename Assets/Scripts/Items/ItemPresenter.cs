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

    public int TestID;

    private Transform _transportPanel;
    private Transform _oldParent;
    protected CanvasGroup _canvasGroup;
    protected RectTransform _rectTransform;
    private StoragePosition _storagePosition;
    public StoragePosition StoragePosition 
    { 
        get => _storagePosition;
        set
        {
            _storagePosition = value;
            RefreshInfo();
        } 
    }

    public Item Item => StoragePosition.Item;

    public string Name => Item.Name;
    public Transform OldParent => _oldParent;

    public void HideName()
    {
        _nameText.gameObject.SetActive(false);
    }
    public Sprite Icon 
    { set {_icon.sprite = value;}}

    public int Count
    {
        get => StoragePosition.Count;
        set
        {
            StoragePosition.Count = value;
            if (StoragePosition.Count == 0 && gameObject != null)
                Destroy(gameObject);
            else
                RefreshInfo();
        }
    }

    public void RefreshInfo()
    {
        if (Count > 1)
            _countText.text = Count.ToString();
        else
           _countText.text = string.Empty;
        if (Item is RangeWeapon rangeWeapon && TestID > -1)
        {
            _countText.text = rangeWeapon.AmmoCount.ToString() + "/" + rangeWeapon.AmmoCapacity.ToString();
        }
    }
    private void Start()
    {
        _transportPanel = GameObject.Find("TransportPanel").transform;
        _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _nameText.text = Name;
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
        //if (Count <= 0)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        if (transform.parent == _transportPanel)
        {
            SetToParent(_oldParent);
            if (transform.parent.gameObject.TryGetComponent<StorageSlot>(out var storageSlot) && Count > 0)
            {
                storageSlot.InsertItem(this);
            }
        }

        var sourceSlot = _oldParent.GetComponent<DropSlot>();

        var currentSlot = transform.parent.gameObject.GetComponent<DropSlot>();
        if (Count > 0)
            currentSlot.OnPresenterSet(this, sourceSlot);

        if (currentSlot is StorageSlot storageSlot1)
            storageSlot1.FillSlots();
        _canvasGroup.blocksRaycasts = true;

        if (Count <= 0)
            Destroy(gameObject);
    }

    public void SetToParent(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector2.zero;

        if (transform.parent.gameObject.TryGetComponent<ItemSlot>(out var itemSlot))
        {
            if (itemSlot.SlotType == SlotType.Shoulder)
                transform.localEulerAngles = new Vector3(0, 0, -90);
            _nameText.gameObject.SetActive(false);
            itemSlot.PresenterSet(this);
        }
        else
            _nameText.gameObject.SetActive(true);

    }
}
