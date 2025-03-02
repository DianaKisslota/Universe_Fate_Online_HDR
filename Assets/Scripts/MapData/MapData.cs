using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class MapData : MonoBehaviour
{
    [SerializeField] protected Navigation _navigation;
    [SerializeField] protected Vector2 _startSector;
    [SerializeField] protected TMP_Text _sectorInfoText;
    [SerializeField] protected Button _cleanupSectorButton;
    [SerializeField] protected Button _transferButton;
    [SerializeField] protected TMP_Text _transferCaption;
    [SerializeField] protected Camera _miniMapCamera;
    [SerializeField] protected GameObject _inventoryPanel;

    // **���������: ��������� ���� ��� ������ ��������**
    [SerializeField] protected Button _shopButton; // ������ ��������
    [SerializeField] protected Button _HospitalButton; // ������ ���������
    [SerializeField] protected Button _ArenaButton; // ������ �����
    [SerializeField] protected Button _WarehouseButton; // ������ �����


    protected SectorData _currentSector;
    protected IDataSource _source;
    public event Action<List<string>> RefreshDirections;

    protected string SceneName { get; set; }
    protected string Name { get; set; }

    protected string DefaultBattleScene { get; set; }

    public bool IsDark { get; set; }

    protected SectorData GetSectorData(string sectorID)
    {
        var result = _source.GetSectorData(sectorID);
        return result;
    }

    private void Start()
    {
        _cleanupSectorButton.gameObject.SetActive(false);
        _transferButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false); // **������ ������ �������� ��� ������**
        _HospitalButton.gameObject.SetActive(false); // **������ ������ ��������� ��� ������**
        _ArenaButton.gameObject.SetActive(false); // **������ ������ ����� ��� ������**
        _WarehouseButton.gameObject.SetActive(false); // **������ ������ ������ ��� ������**
        _navigation.ArriveToSector += OnArriveToSector;
        RefreshDirections += _navigation.UpdateButtons;
        _navigation.GoToSector += StartToGo;
        Global.CurrentMapName = SceneName;
        _source = new DataSource();
        if (Global.CurrentSectorID == null)
        {
            var x = _startSector.x.ConvertTo<int>();
            var y = _startSector.y.ConvertTo<int>();
            _currentSector = GetSectorData(SectorData.CoordsToID(Name, x, y));
        }
        else
        {
            _currentSector = GetSectorData(Global.CurrentSectorID);
            SetNavigationToSector(_currentSector);
        }

        ReactToArriving();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            _miniMapCamera.gameObject.SetActive(!_miniMapCamera.gameObject.activeSelf);
    }

    private void StartToGo(string direction)
    {
        _cleanupSectorButton.gameObject.SetActive(false);
        _transferButton.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false); // **������ ������ �������� ��� ��������**
        _HospitalButton.gameObject.SetActive(false); // **������ ������ ��������� ��� ��������**
        _ArenaButton.gameObject.SetActive(false); // **������ ������ ����� ��� ��������**
        _WarehouseButton.gameObject.SetActive(false); // **������ ������ ����� ��� ��������**
        var nextSectorX = _currentSector.X;
        var nextSectorY = _currentSector.Y;
        switch (direction)
        {
            case "N":
                { nextSectorY++; }
                break;
            case "S":
                { nextSectorY--; }
                break;
            case "W":
                { nextSectorX--; }
                break;
            case "E":
                { nextSectorX++; }
                break;
            case "NW":
                { nextSectorY++; nextSectorX--; }
                break;
            case "NE":
                { nextSectorY++; nextSectorX++; }
                break;
            case "SW":
                { nextSectorY--; nextSectorX--; }
                break;
            case "SE":
                { nextSectorY--; nextSectorX++; }
                break;
        }

        Debug.Log("������������ � ������ " + _currentSector.ID);
        var nextSectorID = SectorData.CoordsToID(Name, nextSectorX, nextSectorY);
        _currentSector = GetSectorData(nextSectorID);
        _sectorInfoText.text = "������ " + _currentSector.X.ToString() + ":" + _currentSector.Y.ToString() + "\n\n";
    }

    private void OnArriveToSector(string direction)
    {
        Debug.Log("������� � ������ " + _currentSector.ID);
        ReactToArriving();
    }

    private void ReactToArriving()
    {
        _sectorInfoText.text = "������ " + _currentSector.X.ToString() + ":" + _currentSector.Y.ToString() + "\n\n";
        var monsters = _currentSector.GetMonsterList();
        if (!string.IsNullOrEmpty(monsters))
        {
            _sectorInfoText.text += "����� ������� �������:\n" + monsters;
            _cleanupSectorButton.gameObject.SetActive(true);
        }

        var npc = _currentSector.GetNPCList();
        if (!string.IsNullOrEmpty(npc))
            _sectorInfoText.text += "����� ��������� ���: \n" + npc;

        Global.CurrentSectorID = _currentSector.ID;
        CheckDirections();

        // **���������: ���������� ������� ��������**
        _shopButton.gameObject.SetActive(_currentSector.HasShop); // ���������� ��� �������� ������ ��������
        _HospitalButton.gameObject.SetActive(_currentSector.Hospital); // ���������� ��� �������� ������ ���������
        _ArenaButton.gameObject.SetActive(_currentSector.Arena); // ���������� ��� �������� ������ �����
        _WarehouseButton.gameObject.SetActive(_currentSector.Warehouse); // ���������� ��� �������� ������ �����

        if (_currentSector.TransferTo != null)
        {
            _transferCaption.text = _currentSector.TransferTo.TransferCaption;
            _transferButton.gameObject.SetActive(true);
        }
        else
        {
            _transferButton.gameObject.SetActive(false);
        }

        InitCurrentSectorInfo();
    }

    private void InitCurrentSectorInfo()
    {
        if (_currentSector == null)
            return;
        if (_currentSector.IsDark == null)
            Global.CurrentSectorInfo.IsDark = IsDark;
        else
            Global.CurrentSectorInfo.IsDark = _currentSector.IsDark.Value;
    }

    public void Transfer()
    {
        Global.CurrentSectorID = _currentSector.TransferTo.TransferToSector;
        SceneManager.LoadScene(_currentSector.TransferTo.TransferToScene);
    }

    private bool isSectorAvailable(int x, int y)
    {
        var sector = GetSectorData(SectorData.CoordsToID(Name, x, y));
        return sector != null && !sector.IsRestricted();
    }

    private void CheckDirections()
    {
        var availableDirections = new List<string>();
        if (isSectorAvailable(_currentSector.X, _currentSector.Y + 1))
            availableDirections.Add("N");
        if (isSectorAvailable(_currentSector.X, _currentSector.Y - 1))
            availableDirections.Add("S");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y))
            availableDirections.Add("W");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y))
            availableDirections.Add("E");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y + 1))
            availableDirections.Add("NW");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y + 1))
            availableDirections.Add("NE");
        if (isSectorAvailable(_currentSector.X + 1, _currentSector.Y - 1))
            availableDirections.Add("SE");
        if (isSectorAvailable(_currentSector.X - 1, _currentSector.Y - 1))
            availableDirections.Add("SW");

        RefreshDirections?.Invoke(availableDirections);
    }

    private void SetNavigationToSector(SectorData sectorData)
    {
        var deltaX = sectorData.X - _startSector.x;
        var deltaY = sectorData.Y - _startSector.y;
        var newPosition = _navigation.gameObject.transform.position;
        newPosition.x += deltaX * _navigation.XStep;
        newPosition.z += deltaY * _navigation.ZStep;
        _navigation.gameObject.transform.position = newPosition;
        _currentSector = sectorData;
        ReactToArriving();
    }

    public void CleanupSector()
    {
        var battleSceneName = _currentSector.GetRandomBattleScene();
        if (battleSceneName == null)
            battleSceneName = DefaultBattleScene;
        SceneManager.LoadScene(battleSceneName);
    }

    public void ShowBirdEyeView()
    {
        _miniMapCamera.gameObject.SetActive(!_miniMapCamera.gameObject.activeSelf);
    }

    public void ShowInventory()
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeSelf);
    }
}
