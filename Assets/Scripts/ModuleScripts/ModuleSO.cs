using UnityEngine;

[CreateAssetMenu(fileName = "Module", menuName = "ScriptableObjects/Module", order = 1)]
public class ModuleSO : ScriptableObject
{
    public string _moduleName;
    public int _cellSize;
    public float _moduleWeight;
    public float _moduleWeightChange;

    //have a list of vector2int to store the location of the cells,
    //then go one by one of the cells marked unoccupied and treat the firs cell as 0,0.
    //then check what the  next cell is and if its unoccupied, if it is continue to the next one.
}
