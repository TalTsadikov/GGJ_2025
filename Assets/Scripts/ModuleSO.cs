using UnityEngine;

[CreateAssetMenu(fileName = "Module", menuName = "ScriptableObjects/Module", order = 1)]
public class ModuleSO : ScriptableObject
{
    public string _moduleName;
    public int _cellSize;
    public float _moduleWeight;
    public GameObject _modulePrefab;
}
