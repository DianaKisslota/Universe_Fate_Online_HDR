using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EntityAvatar : MonoBehaviour
{
    public BaseEntity Entity { get; set; }
    protected Animator _animator;
    protected NavMeshAgent _agent;
    protected Rigidbody _rigidBody;

    public virtual int CurrentActionPoints { get; set; }

    [SerializeField] protected AudioSource _audioSource;

    protected Vector3? _walkingTo;

    protected Animator Animator
    {
        get
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
            return _animator;
        }
    }

    protected virtual AudioClip _rangeAttackSound
    {
        get { return _audioSource.clip; }
    }
    private bool IsMoving {  get; set; }

    public event Action StartMoving;
    public event Action EndMoving;

    private float _timeBeforeAgentEnabled = 0;


    public int APToReachPoint(Vector3 reachPoint)
    {
        return Mathf.RoundToInt(Vector3.Distance(reachPoint, transform.position) * Entity.StepCost);
    }
    public bool CanReachInTurn(Vector3 reachPoint)
    {
        return Vector3.Distance(reachPoint, transform.position) <= CurrentActionPoints / Entity.StepCost;
    }

    public void SpendAPForMoving(Vector3 reachPoint)
    {
        CurrentActionPoints -= APToReachPoint(reachPoint);
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();
        Init();
    }

    protected virtual void Init()
    {

    }

    public void RestoreAP()
    {
        CurrentActionPoints = Mathf.RoundToInt(Entity.MaxActionPoints);
    }

    public void MoveTo(Vector3 movePoint)
    {
        if (InPoint(movePoint))
            return;
        Animator.ResetTrigger("Idle");
        _walkingTo = movePoint;
        Animator.SetTrigger("Walk");
        _agent.destination = movePoint;
        StartMoving!.Invoke();
    }

    protected virtual void CheckWalking()
    {
        if (_walkingTo != null && InPoint(_walkingTo.Value))
        {
            Animator.ResetTrigger("Walk");
            _agent.ResetPath();
            Animator.SetTrigger("Idle"); 
            _walkingTo = null;
            StopAgent(0.5f);
            EndMoving?.Invoke();
        }
    }

    protected void StopAgent(float sec)
    {
        _timeBeforeAgentEnabled = sec;
        _agent.isStopped = true;
    }

    protected virtual void AdditionChecks()
    {

    }

    public virtual void EntityDie()
    {
        Animator.SetTrigger("Die");
        Entity.Die -= EntityDie;
        GetComponent<BoxCollider>().isTrigger = true;
        GetComponent<NavMeshObstacle>().enabled = false;
    }

    private void Update()
    {
        if (_timeBeforeAgentEnabled > 0)
        {
            _timeBeforeAgentEnabled -= Time.deltaTime;
        }

        if (_agent.enabled)
            _agent.isStopped = Entity.IsDead || _timeBeforeAgentEnabled > 0;        
        CheckWalking();
        AdditionChecks();
    }

    protected bool InPoint(Vector3 point)
    {
        return Mathf.Abs(gameObject.transform.position.x - point.x) < 0.01
                        && Mathf.Abs(gameObject.transform.position.z - point.z) < 0.01;
    }

    public bool CalculateCompletePath(Vector3 targetPoint, NavMeshPath path)
    {
        var result = _agent.enabled && _agent.CalculatePath(targetPoint, path);
        if (!result)
            return false;
        var startPoint = AllignPoint.ToMid(_agent.transform.position);
        var endPoint = path.corners[path.corners.Length - 1];
        
        return Mathf.Abs(endPoint.x - targetPoint.x) < 0.001 && Mathf.Abs(endPoint.z - targetPoint.z) < 0.001
            && Mathf.Abs(startPoint.x - targetPoint.x) > 0.001 || Mathf.Abs(startPoint.z - targetPoint.z) > 0.001;
    }

    public float PathLength(NavMeshPath path)
    {
        float result = 0;
        for (int i = 1; i < path.corners.Length; i++)
        {
            result += Vector3.Distance(path.corners[i - 1], path.corners[i]);
        }
        return result;
    }

    public void PlaySound(AudioClip clip, float delay = 0, int numRepeat = 1)
    {
        StartCoroutine(Play(clip, delay, numRepeat));
    }

    private IEnumerator Play(AudioClip clip, float delay, int numRepeat)
    {
        for (int i = 0; i < numRepeat; i++)
        {
            yield return new WaitForSeconds(delay);
            _audioSource.PlayOneShot(clip);
        }
    }

    protected virtual void RangeAttack(RangeAttackData attackData)
    {

    }

    protected virtual void MeleeAttack(MeleeAttackData attackData)
    {

    }

}
