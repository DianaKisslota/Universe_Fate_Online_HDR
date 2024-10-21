using EasyRoads3Dv3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleRutine : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<Transform> _staticContainersPoints;
    [SerializeField] private List<Transform> _characterSpawnPoints;
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private Transform _camera;
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private int _cameraScrollSpeed = 10;
    [SerializeField] private int _cameraRotateSpeed = 50;
    [SerializeField] private float _frontFrontier = 17;
    [SerializeField] private float _backFrontier = -17;
    [SerializeField] private float _leftFrontier = -15;
    [SerializeField] private float _rightFrontier = 2.5f;
    [SerializeField] private float _maxHeigh = 20;
    [SerializeField] private float _minHeigh = 1;

    private CharacterAvatar _character;

    private float _rotationX;
    private float _rotationY;

    private IDataSource _source;
    private SectorData _sectorData;

    private void Start()
    {
        _rotationY = -_camera.rotation.eulerAngles.x;
        _source = new DataSource();
        _sectorData = _source.GetSectorData(Global.CurrentSectorID);

        _character = AvatarFactory.CreateCharacter(Global.Character, _characterSpawnPoints[0]);

        _characterController.BindAvatar(_character);

        foreach (StaticContainer container in _sectorData.StaticContainers)
        {
            if (_staticContainersPoints.Count == 0)
                break;
            var staticContainerPointIndex = Random.Range(0, _staticContainersPoints.Count);
            var staticContainerPoint = _staticContainersPoints[staticContainerPointIndex];
            var staticContainer = ContainerFactory.CreateContainer(container, Global.CurrentSectorInfo.IsDark, staticContainerPoint);
            _staticContainersPoints.Remove(staticContainerPoint);
        }

        foreach (SmallContainer container in _sectorData.SmallContainers)
        {
            if (_spawnPoints.Count == 0)
                break;
            var smallContainerPointIndex = Random.Range(0, _spawnPoints.Count);
            var smallContainerPoint = _spawnPoints[smallContainerPointIndex];
            var smallContainer = ContainerFactory.CreateContainer(container, Global.CurrentSectorInfo.IsDark, smallContainerPoint);
            _spawnPoints.Remove(smallContainerPoint);
        }

        foreach (ItemSpawner spawner in _sectorData.Items)
        {
            if (_spawnPoints.Count == 0)
                break;
            var spawnPointIndex = Random.Range(0, _spawnPoints.Count);
            var spawnPoint = _spawnPoints[spawnPointIndex];
            var item = ItemFactory.CreateItem(spawner.ItemType, Global.CurrentSectorInfo.IsDark);
            item.transform.position = spawnPoint.position;
            _spawnPoints.Remove(spawnPoint);
        }

            foreach (EntitySpawner spawner in _sectorData.Monsters)
        {
            if (_spawnPoints.Count == 0)
                break;
            var numberSpawned = 0;
            if (spawner.MaxSpawn == 0)
                numberSpawned = 1;
            else
                numberSpawned = Random.Range(spawner.MinSpawn, spawner.MaxSpawn + 1);

            for (int i = 0; i < numberSpawned; i++)
            {
                if (_spawnPoints.Count == 0)
                    break;
                var spawnPointIndex = Random.Range(0, _spawnPoints.Count);
                var spawnPoint = _spawnPoints[spawnPointIndex];
                var avatar = AvatarFactory.CreateMob(spawner.EntityType, spawnPoint);
                var lookAtPosition = _character.transform.position;
                lookAtPosition.y = spawnPoint.position.y;
                avatar.transform.LookAt(lookAtPosition);
                _spawnPoints.Remove(spawnPoint);
            }

        }
    }

    private void Update()
    {
        Quaternion ang = _cameraHolder.rotation;

        if (Input.GetKey(KeyCode.E))
        {
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, _cameraHolder.eulerAngles.y + _cameraRotateSpeed * Time.deltaTime, ang.eulerAngles.z);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            ang.eulerAngles = new Vector3(ang.eulerAngles.x, _cameraHolder.eulerAngles.y - _cameraRotateSpeed * Time.deltaTime, ang.eulerAngles.z);
        }

        _cameraHolder.rotation = ang;

        //Vector3 forward = _cameraHolder.TransformDirection(Vector3.forward);

        var newPosition = _cameraHolder.position;

        if (Input.GetKey(KeyCode.A))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.left) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.right) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.forward) * _cameraScrollSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += _cameraHolder.TransformDirection(Vector3.back) * _cameraScrollSpeed * Time.deltaTime;
        }

        if (newPosition.x >= _leftFrontier && newPosition.x <= _rightFrontier && newPosition.z <= _frontFrontier && newPosition.z >= _backFrontier)
            _cameraHolder.position = newPosition;


        float wheelScroll = Input.GetAxis("Mouse ScrollWheel");

        if (wheelScroll < 0 && _cameraHolder.position.y <= _maxHeigh || wheelScroll > 0 && _cameraHolder.position.y >= _minHeigh)
        {
            _cameraHolder.Translate(Vector3.up * -wheelScroll * 3);
        }

        if (Input.GetMouseButton(1) && !_characterController.MouseOverUI)
        {
            _rotationX += Input.GetAxis("Mouse X") * _cameraRotateSpeed * 5 * Time.deltaTime;
            _rotationY += Input.GetAxis("Mouse Y") * _cameraRotateSpeed * 5 * Time.deltaTime;

            _camera.localEulerAngles = new Vector3(-_rotationY, 0, 0);
            _cameraHolder.localEulerAngles = new Vector3(0, _rotationX, 0);
        }
    }

    public void FinishBattle()
    {
        _characterController.ClearAllQuants();
        SceneManager.LoadScene(Global.CurrentMapName);
    }
}
