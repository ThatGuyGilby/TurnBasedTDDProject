using System.Collections.Generic;
using System.IO;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

public class HelperFunctions
{
    #region Logging

    public static void Log(string message)
    {
        Debug.Log(message);
    }

    public static void LogReminder(string message)
    {
        Debug.LogWarning(message);
    }

    #endregion Logging

    #region Data Helper Functions

    public static Dictionary<string, AttributeData> attributeDataDictionary;
    public static Dictionary<string, MoveData> moveDataDictionary;
    public static Dictionary<string, SpeciesData> speciesDataDictionary;

    public static AttributeData AttributeDataFromAttributeKey(AttributeKey attributeKey)
    {
        if (attributeDataDictionary == null)
        {
            LoadAttributeDataDictionary();
        }

        string keyString = attributeKey.ToString();

        if (attributeDataDictionary.ContainsKey((keyString)))
        {
            return attributeDataDictionary[keyString];
        }
        else
        {
            throw new System.Exception("The given key has no entry in the Dictionary");
        }
    }

    public static AttributeData AttributeDataFromString(string attributeString)
    {
        if (attributeDataDictionary == null)
        {
            LoadAttributeDataDictionary();
        }

        string keyString = attributeString.ToUpper();

        if (attributeDataDictionary.ContainsKey((keyString)))
        {
            return attributeDataDictionary[keyString];
        }
        else
        {
            throw new System.Exception("The given key has no entry in the Dictionary");
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
            throw new System.Exception("The given key has no entry in the Dictionary");
        }
    }

    public static void OutputDummyData()
    {
        SpeciesData speciesData = SpeciesDataFromSpeciesKey(SpeciesKey.CHARMANDER);
        speciesData.speciesMoveLearnData = new List<KeyValuePair<string, int>>();
        speciesData.speciesMoveLearnData.Add(new KeyValuePair<string, int>("Flamethrower", 5));

        string output = JsonConvert.SerializeObject(speciesData);

        Debug.Log(output);
    }

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
            throw new System.Exception("The given key has no entry in the Dictionary");
        }
    }

    private static void LoadAttributeDataDictionary()
    {
        List<AttributeData> attributeDatas;

        using (StreamReader r = new StreamReader(Constants.ATTRIBUTE_DATA_PATH))
        {
            string json = r.ReadToEnd();
            attributeDatas = JsonConvert.DeserializeObject<List<AttributeData>>(json);
        }

        attributeDataDictionary = new Dictionary<string, AttributeData>();

        foreach (var attributeData in attributeDatas)
        {
            attributeDataDictionary.Add(attributeData.name.ToUpper(), attributeData);
        }
    }

    private static void LoadMoveDataDictionary()
    {
        List<MoveData> moveDatas;

        using (StreamReader r = new StreamReader(Constants.MOVE_DATA_PATH))
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

    private static void LoadSpeciesDataDictionary()
    {
        List<SpeciesData> speciesDatas;

        using (StreamReader r = new StreamReader(Constants.SPECIES_DATA_PATH))
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

    #endregion Data Helper Functions
}