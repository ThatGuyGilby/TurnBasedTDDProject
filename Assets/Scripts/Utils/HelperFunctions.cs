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

    public static void SerializeObject(object obj)
    {
        Log(JsonConvert.SerializeObject(obj));
    }

    #endregion Logging

    public static MoveKey StringToMoveKey(string currentMoveString)
    {
        currentMoveString = currentMoveString.Replace(" ", "_").ToUpper();

        return (MoveKey)Enum.Parse(typeof(MoveKey), currentMoveString);
    }

    public static void ThrowException(string message)
    {
        throw new Exception(message);
    }
}