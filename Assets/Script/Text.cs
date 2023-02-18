using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Text : MonoBehaviour
{
    public string length = "200";
    public string width = "300";
    public Image image;
    void Start()
    {
        StartCoroutine(GetWeatherData());
    }


    IEnumerator GetWeatherData()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture($"https://picsum.photos/{length}/{width}"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                image.sprite = sprite;
            }
        }
    }   
}
