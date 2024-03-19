using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light directionalLight;
  
    public void SetNight()
    {
        directionalLight.intensity = 0;
    }

    public void SetDay()
    {
        directionalLight.intensity = 1;
    }

}
