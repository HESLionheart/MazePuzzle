using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileManager : MonoBehaviour {

    public static FileManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Create(string filename)
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/" + filename))
            {
                throw new Exception("file already exists");
            }
            else
            {
                FileStream file = File.Create(Application.persistentDataPath + "/" + filename);
                file.Close();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void Save<T>(T data,string filename)
    {
        try
        {
            if (!File.Exists(Application.persistentDataPath + "/" + filename))
                Create(filename);
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/" + filename,json);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public T Load<T>(string filename)
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/" + filename))
            {
                string json = File.ReadAllText(Application.persistentDataPath + "/" + filename);
                T res = JsonUtility.FromJson<T>(json);
                return res;
            }
            else
                return default(T);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default(T);
        }
    }


}
