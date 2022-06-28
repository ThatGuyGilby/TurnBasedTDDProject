using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class MasterFactory
{
    public static Dictionary<string, SpeciesData> speciesDataDictionary;
    public static Dictionary<string, MoveData> moveDataDictionary;

    public static SpeciesData SpeciesDataFromSpeciesKey(SpeciesKey speciesKey)
    {
        if (speciesDataDictionary == null)
        {
            LoadSpeciesDataDictionary();
        }

        string keyString = speciesKey.ToString();

        if (speciesDataDictionary.ContainsKey((keyString)))
        {
            return speciesDataDictionary[keyString];
        }
        else
        {
            throw new System.Exception("The given key has no entry in  the Species Dictionary");
        }
    }

    public static MoveData MoveDataFromMoveKey(MoveKey moveKey)
    {
        if (moveDataDictionary == null)
        {
            LoadMoveDataDictionary();
        }

        string keyString = moveKey.ToString();

        if (moveDataDictionary.ContainsKey((keyString)))
        {
            return moveDataDictionary[keyString];
        }
        else
        {
            throw new System.Exception("The given key has no entry in  the Species Dictionary");
        }
    }



    private static void LoadSpeciesDataDictionary()
    {
        List<SpeciesData> speciesDatas;

        using (StreamReader r = new StreamReader("Assets/SpeciesData.json"))
        {
            string json = r.ReadToEnd();
            speciesDatas = JsonConvert.DeserializeObject<List<SpeciesData>>(json);
        }

        speciesDataDictionary = new Dictionary<string, SpeciesData>();

        foreach (var speciesData in speciesDatas)
        {
            speciesDataDictionary.Add(speciesData.name.ToUpper(), speciesData);
        }
    }

    private static void LoadMoveDataDictionary()
    {
        List<MoveData> moveDatas;

        using (StreamReader r = new StreamReader("Assets/MoveData.json"))
        {
            string json = r.ReadToEnd();
            moveDatas = JsonConvert.DeserializeObject<List<MoveData>>(json);
        }

        moveDataDictionary = new Dictionary<string, MoveData>();

        foreach (var moveData in moveDatas)
        {
            moveDataDictionary.Add(moveData.name.ToUpper(), moveData);
        }
    }

    public static EntityData EntityDataFromSpeciesKey(SpeciesKey speciesKey)
    {
        SpeciesData speciesData = SpeciesDataFromSpeciesKey(speciesKey);

        return new EntityData(speciesData.name, 5, speciesKey, speciesData);
    }
}
