using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;

public class QRBackgroundScanner : MonoBehaviour
{

    public ARCameraManager cameraManager;
    public AudioSource beepSound;
    string QrCode = string.Empty;
    
    

    void Start()
    {
        beepSound = GetComponent<AudioSource>();
        var renderer = GetComponent<RawImage>();

        StartCoroutine(GetQRCode());
        InvokeRepeating(nameof(GetAnotherQrCode), 2f, 2f);
    }


    IEnumerator GetQRCode()
    {

        
        try
        {
            if (cameraManager.TryAcquireLatestCpuImage(out XRCpuImage cpuImage))
            {
                using (cpuImage)
                {
                    var texture = new Texture2D(cpuImage.width, cpuImage.height, cpuImage.format.AsTextureFormat(), false);

                    var conversionParams = new XRCpuImage.ConversionParams(cpuImage, cpuImage.format.AsTextureFormat(), XRCpuImage.Transformation.MirrorY);
                    var rawTextureData = texture.GetRawTextureData<byte>();
                    cpuImage.Convert(conversionParams, rawTextureData);
                    texture.Apply();

                    IBarcodeReader barCodeReader = new BarcodeReader();
                    var Result = barCodeReader.Decode(texture.GetRawTextureData(), texture.width, texture.height, RGBLuminanceSource.BitmapFormat.ARGB32);

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
                                QrCode = null;
                                beepSound.Play();
                                
                            }
                        }
                    }
                }
            }
        }





        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        yield return null;

    }


    void GetAnotherQrCode()
    {
        
        try
        {
            if (cameraManager.TryAcquireLatestCpuImage(out XRCpuImage cpuImage))
            {
                using (cpuImage)
                {
                    var texture = new Texture2D(cpuImage.width, cpuImage.height, cpuImage.format.AsTextureFormat(), false);

                    var conversionParams = new XRCpuImage.ConversionParams(cpuImage, cpuImage.format.AsTextureFormat(), XRCpuImage.Transformation.MirrorY);
                    var rawTextureData = texture.GetRawTextureData<byte>();
                    cpuImage.Convert(conversionParams, rawTextureData);
                    texture.Apply();

                    IBarcodeReader barCodeReader = new BarcodeReader();
                    var Result = barCodeReader.Decode(texture.GetRawTextureData(), texture.width, texture.height, RGBLuminanceSource.BitmapFormat.ARGB32);

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
                                QrCode = null;
                               
                            }
                        }
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

    // Source: https://github.com/Unity-Technologies/arfoundation-samples/blob/6296272a416925b56ce85470e0c7bef5c913ec0c/Assets/Scripts/CpuImageSample.cs
    private Texture2D UpdateRawImage(XRCpuImage cpuImage)
    {
        // Get the texture associated with the UI.RawImage that we wish to display on screen.
        var texture = new Texture2D();

        // If the texture hasn't yet been created, or if its dimensions have changed, (re)create the texture.
        // Note: Although texture dimensions do not normally change frame-to-frame, they can change in response to
        //    a change in the camera resolution (for camera images) or changes to the quality of the human depth
        //    and human stencil buffers.
        if (texture == null || texture.width != cpuImage.width || texture.height != cpuImage.height)
        {
            texture = new Texture2D(cpuImage.width, cpuImage.height, cpuImage.format.AsTextureFormat(), false);
            rawImage.texture = texture;
        }

        // For display, we need to mirror about the vertical access.
        var conversionParams = new XRCpuImage.ConversionParams(cpuImage, cpuImage.format.AsTextureFormat(), XRCpuImage.Transformation.MirrorY);

        //Debug.Log("Texture format: " + cpuImage.format.AsTextureFormat()); -> RFloat

        // Get the Texture2D's underlying pixel buffer.
        var rawTextureData = texture.GetRawTextureData<byte>();

        // Make sure the destination buffer is large enough to hold the converted data (they should be the same size)
        Debug.Assert(rawTextureData.Length == cpuImage.GetConvertedDataSize(conversionParams.outputDimensions, conversionParams.outputFormat),
            "The Texture2D is not the same size as the converted data.");

        // Perform the conversion.
        cpuImage.Convert(conversionParams, rawTextureData);

        // "Apply" the new pixel data to the Texture2D.
        texture.Apply();
    }
    }*/
}
