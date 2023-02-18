using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeatherData
{
    public string success;
    public Result result;
    public Records records;
}
[System.Serializable]
public class Result
{
    public string resource_id;
    public List<Fields> fields;
}
[System.Serializable]
public class Fields
{
    public string id;
    public string type;
}
[System.Serializable]
public class Records
{
    public string datasetDescription;
    public List<Location> location;
}
[System.Serializable]
public class Location
{
    public string locationName;
    public List<WeatherElement> weatherElement;
}
[System.Serializable]
public class WeatherElement
{
    public string elementName;
    public List<Time> time;
}
[System.Serializable]
public class Time
{
    public string startTime;
    public string endTime;
    public Parameter parameter;
}
[System.Serializable]
public class Parameter
{
    public string parameterName;
    public string parameterValue;
}