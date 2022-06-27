using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRScanner : MonoBehaviour
{
    WebCamTexture webcamTexture;
    RawImage renderer;
    string QrCode;
    public Text qrOutput;

    void Start()
    {
        QrCode  = string.Empty;
        renderer = GetComponent<RawImage>();
        webcamTexture = new WebCamTexture((int)renderer.rectTransform.rect.width, (int)renderer.rectTransform.rect.height);
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();

    }
    void Update()
    {
        int oriented = -webcamTexture.videoRotationAngle;
        renderer.rectTransform.localEulerAngles = new Vector3(0, 0, oriented);

        scan();
    }

    void scan()
    {
        IBarcodeReader barCodeReader = new BarcodeReader();
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                Result Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    QrCode = Result.Text;
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        qrOutput.text = QrCode;
                }
                }
            }
            catch (Exception ex) { qrOutput.text = ex.Message; }

        }

}
