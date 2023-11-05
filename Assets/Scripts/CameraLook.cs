using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    float xRotation=0;
    Transform Player;
    [SerializeField] float mousexSensitivity=80f,mouseySensitivity=80f;
    

    void Awake()
    {
       
        Player=GetComponentInParent<PlayerMotor>().transform;
    }
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }


    public void Look(Vector2 mouseInput){
        float mouseX=mouseInput.x*Time.deltaTime*mousexSensitivity;
        float mouseY=mouseInput.y*Time.deltaTime*mouseySensitivity;
        xRotation-=mouseY;
        xRotation=Mathf.Clamp(xRotation,-80,80);
        transform.localRotation= Quaternion.Euler(xRotation,0,0);
        //Player.transform.rotation*=Quaternion.Euler(0,mouseX,0);
        Player.transform.Rotate(Vector3.up*mouseX);
    }
}
