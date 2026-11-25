using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Organizer : MonoBehaviour
{
    [SerializeField] Dictionary<string, InformationClass> InformationDictionary;

    void Start()
    {
        InformationDictionary = new Dictionary<string, InformationClass>();
    }

    void Update()
    {
        
    }

    public void AddInformation(string IdNum, InformationClass Content)
    {
        if (!InformationDictionary.ContainsKey(IdNum))
        {
            InformationDictionary.Add(IdNum, Content);
        }
        else
        {
            Debug.LogError("Los datos ya estan digitados");
        }
    }

    public InformationClass ProvideInformation(string IdNum)
    {
        if (InformationDictionary.ContainsKey(IdNum))
        {
            return InformationDictionary[IdNum];
        }
        else
        {
            return null;
        }
    }
}
