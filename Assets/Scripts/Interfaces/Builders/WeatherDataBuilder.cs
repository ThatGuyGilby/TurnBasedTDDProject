using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDataBuilder : IBuilder<WeatherData>
{
    #region Private Fields

    private WeatherKey weatherKey;

    public WeatherDataBuilder()
    {
        this.weatherKey = WeatherKey.CLEAR;
    }

    #endregion Private Fields

    #region Public Methods

    public WeatherData Build()
    {
        return RepositoryManager.weatherDataRepository.DataFromKey(weatherKey);
    }

    public WeatherDataBuilder WithWeatherKey(WeatherKey weatherKey)
    {
        this.weatherKey = weatherKey;
        return this;
    }

    #endregion Public Methods
}