using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_PhotoTool : MonoBehaviour {

    public int startX = 0;
    public int startY = 0;
    public int width = 1080;
    public int height = 1080;

    public PhotoTool photoTool;

    public RawImage rImg_photo;

    public KeyCode key_takePhoto = KeyCode.B;

    void OnEnable()
    {
        PhotoTool.OnPhotoTaken += HandlePhotoTaken;
    }

    void OnDisable()
    {
        PhotoTool.OnPhotoTaken -= HandlePhotoTaken;
    }

    void Start () {

        photoTool = FindObjectOfType<PhotoTool>();
        photoTool.Init(startX, startY, width, height);

    }

    void Update () {

        if (Input.GetKeyDown(key_takePhoto))
        {
            photoTool.TakePhoto();
        }
	}

    void HandlePhotoTaken(Texture2D _takenPhoto)
    {
        rImg_photo.texture = _takenPhoto;
    }
}
