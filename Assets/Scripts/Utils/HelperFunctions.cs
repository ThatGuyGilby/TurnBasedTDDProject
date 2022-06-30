using System;
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
        //Debug.LogWarning(message);
    }

    #endregion Logging

    #region Public Methods

    public static void ThrowException(string message)
    {
        throw new Exception(message);
    }

    #endregion Public Methods

    #region Data Helper Functions

    public static Repository<AttributeData> attributeDataRepository = new Repository<AttributeData>(Constants.ATTRIBUTE_DATA_PATH);
    public static Repository<MoveData> moveDataRepository = new Repository<MoveData>(Constants.MOVE_DATA_PATH);
    public static Repository<SpeciesData> speciesDataRepository = new Repository<SpeciesData>(Constants.SPECIES_DATA_PATH);

    #endregion Data Helper Functions
}