using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    public CinemachineVirtualCamera VC1;
    public CinemachineVirtualCamera VC2;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(VC1.m_Priority > VC2.m_Priority)
            {
                VC1.m_Priority = 9;
                VC2.m_Priority = 11;
            }
            else
            {
                VC1.m_Priority = 11;
                VC2.m_Priority = 9;
            }
        }
    }
}
