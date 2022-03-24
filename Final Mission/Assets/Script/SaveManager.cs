using System;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    [SerializeField] public FieldInfo dataToCheck;
    [System.Serializable]
    public class SaveData
    {
        [SerializeField] public Vector3 Unknow;
        [SerializeField] public Vector3 Owl;
        [SerializeField] public Vector3 Crocodile;
        [SerializeField] public Vector3 Cow;
        [SerializeField] public Vector3 Chicken;
        [SerializeField] public Vector3 Chick;
        [SerializeField] public int[] score = new int[6];
    }
    public SaveData saveData = new SaveData();


    private void Awake()
    {
        InstanceInitialize();
    }

    private void InstanceInitialize()
    {
        if (instance == null) 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
            LoadPersistantData();
        }
        else Destroy(gameObject);
    }

    private void LoadPersistantData()
    {
        string path = Application.persistentDataPath + "/Save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }

    private void OnApplicationQuit()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/Save.json", json);
    }



    private bool TryVariableName(string stringName)
    {
        bool result = false;
        foreach(FieldInfo field in typeof(SaveManager.SaveData).GetFields())
        {
            if (field.Name == stringName) result = true;
        }
        return result;
        
    }

    public void Save<T>(T saving, string stringName)
    {
        if (TryVariableName(stringName) == true)
        {
            dataToCheck = typeof(SaveManager.SaveData).GetField(stringName);
            if (dataToCheck.FieldType == typeof(T))
            {
                dataToCheck.SetValue(saveData, saving);
            }
            else Debug.Log("Type Error");
        }
        else Debug.Log("Name Error, Variable not existing");
    }

    public T Load<T>(T baseValue, string stringName)
    {
        dataToCheck = typeof(SaveManager.SaveData).GetField(stringName);
        if (dataToCheck.FieldType == typeof(T))
        {
            if (dataToCheck != null)
            {
                baseValue = (T)dataToCheck.GetValue(saveData);
                return baseValue;
            }
        }
        return baseValue;
    }
}
