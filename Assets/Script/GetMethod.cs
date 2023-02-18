using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GetMethod : MonoBehaviour
{
    private const string API_KEY = "CWB-40FF9580-58B4-4E7B-9AD7-EAC511CA098B";
    public string locationName = "宜蘭縣";
    public string elementName = "Wx";   
    void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    IEnumerator GetWeatherData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization={API_KEY}&locationName={locationName}&elementName={elementName}"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);

                var responseJson = JsonUtility.FromJson<WeatherData>(responseText);
                Debug.Log(responseJson.records.location[0].weatherElement[0].time[0].parameter.parameterName);
                
            }
        }
    }   
}