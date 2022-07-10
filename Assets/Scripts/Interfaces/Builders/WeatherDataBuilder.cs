using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherDataBuilder : IBuilder<WeatherData>
{
    private WeatherKey weatherKey;

    public WeatherDataBuilder()
    {
        this.weatherKey = WeatherKey.CLEAR;
    }

    public WeatherData Build()
    {
        return RepositoryManager.weatherDataRepository.DataFromKey(weatherKey);
    }

    public WeatherDataBuilder WithWeatherKey(WeatherKey weatherKey)
    {
        this.weatherKey = weatherKey;
        return this;
    }
}