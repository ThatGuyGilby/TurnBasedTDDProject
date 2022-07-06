using System;
using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;

public class Repository<T> where T : DataSource
{
    public Dictionary<string, T> dataDictionary;

    public string dataPath;

    public Repository(string dataPath)
    {
        this.dataPath = dataPath;
    }

    public T DataFromKey(Enum dataKey)
    {
        if (dataDictionary == null)
        {
            LoadDataDictionary();
        }

        string keyString = dataKey.ToString().Replace("_", " ");

        if (dataDictionary.ContainsKey(keyString))
        {
            return dataDictionary[keyString];
        }
        else
        {
            throw new Exception("The given key has no entry in the Dictionary");
        }
    }

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
}