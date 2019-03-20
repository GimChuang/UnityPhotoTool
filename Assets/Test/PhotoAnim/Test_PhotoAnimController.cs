using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PhotoAnimController : MonoBehaviour
{

    public PhotoAnimController photoAnimController;

    public KeyCode key_playCountDownAnim = KeyCode.A;

    void Start()
    {

        photoAnimController = FindObjectOfType<PhotoAnimController>();
        photoAnimController.Init();

    }

    void OnEnable()
    {
        PhotoAnimController.OnCountDownFinish += HandleCountDownFinish;
        PhotoAnimController.OnShotFinish += HandleShotFinish;
    }

    void OnDisable()
    {
        PhotoAnimController.OnCountDownFinish -= HandleCountDownFinish;
        PhotoAnimController.OnShotFinish -= HandleShotFinish;
    }

    void Update()
    {

        if (Input.GetKeyDown(key_playCountDownAnim))
        {
            photoAnimController.PlayCountDownAnim();
        }
    }

    void HandleCountDownFinish()
    {
        Debug.Log("Count Down Finish!");
        photoAnimController.PlayShotAnim();
    }

    void HandleShotFinish()
    {
        Debug.Log("Shot Finish!");
    }
}
