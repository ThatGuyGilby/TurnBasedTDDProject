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
}