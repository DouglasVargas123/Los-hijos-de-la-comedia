using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class UITransitionManager : MonoBehaviour
{

    public CinemachineVirtualCamera currentCamera;
    public CinemachineVirtualCamera menuInicio;
    public Animator anim;


    public void Start()
    {
        currentCamera.Priority++;
        currentCamera = menuInicio;
        anim.SetTrigger("Inicio");
    }

  
    public void UpdateCamera(CinemachineVirtualCamera target)
    {
        currentCamera.Priority--;

        currentCamera = target;

        currentCamera.Priority++; 
    }
}
