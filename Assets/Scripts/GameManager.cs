using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] List<ModuleSO> moduleList;

    [Header("Parameters")]
    [SerializeField] float dropWaitTime;
    [SerializeField] float dropTime;
    [SerializeField] float dropPercentage;

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
    }

    public void Start()
    {
        InvokeRepeating("determineModuleDrop", dropWaitTime, dropTime);
    }

    public float calculateWeightTable()
    {
        float totalWeight = 0;

        foreach (ModuleSO module in moduleList)
        {
            totalWeight += module._moduleWeight;
        }

        return totalWeight;
    }

    public void determineModuleDrop()
    {
        int lootAchieved = Random.Range(1, 100);

        if (lootAchieved <= (int)dropPercentage)
        {
            ModuleSO chosenModule;
            int choiceIndex;
            choiceIndex = Random.Range(1, (int)calculateWeightTable());
            Debug.Log(choiceIndex);
            chosenModule = moduleList[0];
            float tester = 0;
            for (int i = 0; i < moduleList.Count; i++)
            {

                if (choiceIndex > moduleList[i]._moduleWeight + tester)
                {
                    tester += moduleList[i]._moduleWeight;
                }

                else
                {
                    chosenModule = moduleList[i];
                    break;
                }
                chosenModule = moduleList[i];
            }

            Vector3 pos = Random.insideUnitCircle * 5;
            Instantiate(chosenModule._modulePrefab, transform.position + pos, Quaternion.identity);
        }
    }
}
