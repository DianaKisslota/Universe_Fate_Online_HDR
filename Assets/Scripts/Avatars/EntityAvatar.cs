using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public abstract class EntityAvatar : MonoBehaviour
{
    public BaseEntity Entity { get; set; }
    protected Animator _animator;
    protected NavMeshAgent _agent;
    protected Rigidbody _rigidBody;

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
    public bool IsMoving {  get; set; }

    public event Action StartMoving;
    public event Action EndMoving;

    private float _timeBeforeAgentEnabled = 0;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();
        Init();
    }

    protected abstract void Init();

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
        var endPoint = path.corners[path.corners.Length - 1];
        return Mathf.Abs(endPoint.x - targetPoint.x) < 0.001 && Mathf.Abs(endPoint.z - targetPoint.z) < 0.001;
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


    //public bool PathReachable(NavMeshPath path)
    //{
    //    return PathLength(path) <= entity.MaxDistance();
    //}

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

}
