using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class Repository<T> where T : DataSource
{
    #region Public Fields

    public Dictionary<string, T> dataDictionary;

    public string dataPath;

    #endregion Public Fields

    #region Public Constructors

    public Repository(string dataPath)
    {
        this.dataPath = dataPath;
    }

    #endregion Public Constructors

    #region Public Methods

    public T DataFromKey(Enum attributeKey)
    {
        if (dataDictionary == null)
        {
            LoadDataDictionary();
        }

        string keyString = attributeKey.ToString();

        if (dataDictionary.ContainsKey((keyString)))
        {
            return dataDictionary[keyString];
        }
        else
        {
            throw new Exception("The given key has no entry in the Dictionary");
        }
    }

    #endregion Public Methods

    public T DataFromString(string dataString)
    {
        if (dataDictionary == null)
        {
            LoadDataDictionary();
        }

        string keyString = dataString.ToUpper();

        if (dataDictionary.ContainsKey((keyString)))
        {
            return dataDictionary[keyString];
        }
        else
        {
            throw new Exception("The given key has no entry in the Dictionary");
        }
    }

    #region Private Methods

    private void LoadDataDictionary()
    {
        List<T> dataSources;

        using (StreamReader r = new StreamReader(dataPath))
        {
            string json = r.ReadToEnd();
            dataSources = JsonConvert.DeserializeObject<List<T>>(json);
        }

        dataDictionary = new Dictionary<string, T>();

        foreach (T dataSource in dataSources)
        {
            dataDictionary.Add(dataSource.name.ToUpper(), dataSource);
        }
    }

    #endregion Private Methods
}