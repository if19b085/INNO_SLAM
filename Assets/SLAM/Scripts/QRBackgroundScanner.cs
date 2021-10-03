using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRBackgroundScanner : MonoBehaviour
{


    WebCamTexture webcamTexture;
    string QrCode = string.Empty;
    public AudioSource beepSound;
    public Text text;

    void Start()
    {
        var renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture(512, 512);
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
        text.gameObject.SetActive(false);
        StartCoroutine(GetQRCode());
        InvokeRepeating(nameof(GetAnotherQrCode), 2f, 2f);
    }


    IEnumerator GetQRCode()
    {
        Debug.Log("i bims qrcodegetter");
        IBarcodeReader barCodeReader = new BarcodeReader();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);

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
                        string[] xAndZ = QrCode.Split('/');
                        float x = float.Parse(xAndZ[0]);
                        float z = float.Parse(xAndZ[1]);
                        SceneDataHandler.myData.startX = x;
                        SceneDataHandler.myData.startZ = z;
                        Debug.Log(x + ", " + z);
                        text.gameObject.SetActive(true);
                        QrCode = null;

                    }
                }
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        yield return null;



    }

    private void DisplayDialog(string v1, string v2, string v3)
    {
        throw new NotImplementedException();
    }

    void GetAnotherQrCode()
    {
        Debug.Log("hi");
        IBarcodeReader barCodeReader = new BarcodeReader();
        var snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);


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
                        string[] xAndZ = QrCode.Split('/');
                        float x = float.Parse(xAndZ[0]);
                        float z = float.Parse(xAndZ[1]);
                        SceneDataHandler.myData.startX = x;
                        SceneDataHandler.myData.startZ = z;
                        Debug.Log(x + ", " + z);                        
                        text.gameObject.SetActive(true);                       
                        QrCode = null;

                    }
                }
            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }

    }

    /*
    void Start()
    {
        InvokeRepeating("Autofocus", 2f, 2f);
    }

    void Autofocus()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_TRIGGERAUTO);
        //CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);

        RegognizeQR();
    }

    private Vuforia.Image GetCurrFrame()
    {


        return VuforiaBehaviour.Instance.CameraDevice.GetCameraImage(PixelFormat.GRAYSCALE);
        //return CameraDevice.Instance.GetCameraImage(Vuforia.Image.PIXEL_FORMAT.GRAYSCALE);
    }

    void RegognizeQR()
    {
        if (!_isFrameFormatSet == _isFrameFormatSet)
        {

            //_isFrameFormatSet = CameraDevice.Instance.SetFrameFormat(Vuforia.Image.PIXEL_FORMAT.GRAYSCALE, true);
            _isFrameFormatSet = VuforiaBehaviour.Instance.CameraDevice.SetFrameFormat(PixelFormat.GRAYSCALE, true);
        }

        var currFrame = GetCurrFrame();

        if (currFrame == null)
        {
            Debug.Log("Camera image capture failure;");
        }
        else
        {
            //var imgSource = new RGBLuminanceSource(currFrame.Pixels, currFrame.BufferWidth, currFrame.BufferHeight, true);
            var imgSource = new RGBLuminanceSource(currFrame.Pixels, currFrame.Width, currFrame.Height);

            var result = _barcodeReader.Decode(imgSource);
            if (result != null)
            {
                Debug.Log("RECOGNIZED: " + result.Text);
            }
        }
    }*/
}
