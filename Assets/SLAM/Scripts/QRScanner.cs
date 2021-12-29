using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using ZXing;

public class QRScanner : MonoBehaviour
{
    WebCamTexture webcamTexture;
    string QrCode = string.Empty;
    public AudioSource beepSound;
    private Room roomy;

    void Start()
    {
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(512, 512);
        renderer.material.mainTexture = webcamTexture;
        StartCoroutine(GetQRCode());
    }

    IEnumerator GetQRCode()
    {
        IBarcodeReader barCodeReader = new BarcodeReader();
        webcamTexture.Play();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        if (!string.IsNullOrEmpty(QrCode))
                        {
                            var shortID = Result.Text;
                            //string[] xAndZ = QrCode.Split('/');
                            //float x = float.Parse(xAndZ[0]);
                            //float z = float.Parse(xAndZ[1]);
                            //SceneDataHandler.myData.startX = x;
                            //SceneDataHandler.myData.startZ = z;
                            //Application.LoadLevel("IndoorNavigation");
                            JsonParse(shortID);

                            break;
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        webcamTexture.Stop();
    }

    public void JsonParse(string shortID)
    {
        var loadingRequest = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, "fhtwroomsF_E.json"));
        loadingRequest.SendWebRequest();
        while (!loadingRequest.isDone)
        {
            if (loadingRequest.isNetworkError || loadingRequest.isHttpError)
            {
                break;
            }
        }

        string jsonString = loadingRequest.downloadHandler.text;


        //string jsonString = File.ReadAllText("Assets/StreamingAssets/fhtwroomsF_E.json");
        JObject data = JObject.Parse(jsonString);
        string roomArray = data["roomDescriptions"].ToString();
        JArray jArray = JArray.Parse(roomArray);
        foreach (JObject jObject in jArray)
        {
                       
            var jsonID = jObject["shortId"].ToString();

            if (shortID.Equals(jsonID))
            {
                
                SceneDataHandler.myData.startX = float.Parse(jObject["x"].ToString());
                SceneDataHandler.myData.startZ = float.Parse(jObject["z"].ToString());

                Debug.Log("x: " + float.Parse(jObject["x"].ToString()) + "\n y: " + float.Parse(jObject["z"].ToString()));

                Application.LoadLevel("IndoorNavigation");
                break;
            }
            
        }
    }
}