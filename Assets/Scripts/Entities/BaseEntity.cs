using System;
using UnityEngine;

public abstract class BaseEntity: ITarget
{
    public int Level { get; set; } = 1;
    public string Name {  get; set; }
    public string Description { get; set; }  

    private int _strength;
    private int _perception;
    private int _agility;
    private int _constitution;
    private int _intelligence;
    private int _will;

    private float _currentHealth;

    protected BaseEntity()
    {
        Init();
    }

    public event Action Die;

    protected virtual void Init()
    {
        CurrentHealth = MaxHealth;
    }

    public int StepCost { get; set; } = 2;
    public int RunCost { get; set; } = 1;


    public int Strength 
    {  
        get { return _strength; } 
        set {  _strength = value; } 
    }

    public int Perception 
    { 
        get { return _perception; } 
        set { _perception = value; }
    }

    public int Agility 
    { 
        get { return _agility; }
        set { _agility = value; }
    }

    public int Constitution 
    { 
        get { return _constitution; }
        set { _constitution = value; }
    }

    public int Intelligence 
    { 
        get { return _intelligence; }
        set { _intelligence = value; }
    }

    public int Will
    {
        get { return _will; }
        set { _will = value; }
    }

    public float MaxHealth
    {
        get
        {
            return Constitution * 20;
        }
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            if (_currentHealth == 0)
                Die?.Invoke();
        }
    }

    public bool IsDead
    {
        get => CurrentHealth <= 0;
    }

    public float MaxWeight
    { 
        get
        {
            return Strength * 20;
        }
    }

    public float BaseMeleeDamage
    {
        get
        {
            return Strength / 2f;
        }
    }

    public float BaseRangeHitChance
    {
        get
        {
            return (Perception + 50) / 100f;
        }
    }

    public float BaseMeleeHitChance
    {
        get
        {
            return (Agility + 70) / 100f;
        }
    }

    public float NaturalArmor { get; set; } = 0;

    public virtual float Armor => NaturalArmor;

    public int MaxActionPoints
    {
        get
        {
            return Agility * 2;
        }
    }
}

