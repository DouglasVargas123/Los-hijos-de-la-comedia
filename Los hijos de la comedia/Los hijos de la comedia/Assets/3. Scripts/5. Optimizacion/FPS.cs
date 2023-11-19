using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 60; // Limita los FPS a 60
    }
}
