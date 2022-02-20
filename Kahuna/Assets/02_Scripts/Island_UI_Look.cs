using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_UI_Look : MonoBehaviour
{
    void Update()
    {
        CameraLook();
    }

    public void CameraLook()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
        
    }
}
