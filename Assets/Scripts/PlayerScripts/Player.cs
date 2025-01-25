using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public List<ModuleSO> _moduleList { get; private set; }

    [SerializeField] private int _maxHP;
    [SerializeField] private int _hp;
    [SerializeField] private AttackModule _rosemary;

    public event Action<ModuleSO> OnModuleAdded;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        _moduleList = new List<ModuleSO>();
        _hp = _maxHP;
        AddModule(_rosemary);
    }

    public void AddModule(ModuleSO module)
    {
        _moduleList.Add(module);
        OnModuleAdded?.Invoke(module);
    }   
}
