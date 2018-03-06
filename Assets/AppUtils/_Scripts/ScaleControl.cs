using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleControl : MonoBehaviour
{
    //Fingers
    [SerializeField]
    Transform thumbR;
    [SerializeField]
    Transform indexR;
    [SerializeField]
    Transform thumbL;
    [SerializeField]
    Transform indexL;

    [SerializeField]
    Transform scaleA;
    [SerializeField]
    Transform scaleB;

    bool isPinching;
    [SerializeField]
    float pinchLimit;

    float scaleFactor;

    float pinchiAdistance;
    float pinchBdistance;

    [SerializeField]
    Transform target;

    private void Update()
    {
        pinchiAdistance = Vector3.Distance(thumbR.position, indexR.position);
        pinchBdistance = Vector3.Distance(thumbL.position, indexL.position);

        //Debug.Log(pinchiAdistance);

        isPinching = pinchiAdistance < pinchLimit 
            && pinchBdistance < pinchLimit;
        if (isPinching)
        {
            scaleFactor = Vector3.Distance(scaleA.position, scaleB.position);
            target.localScale = target.localScale.x <= 0f ? Vector3.one : Vector3.one * scaleFactor;
        }
    }
}
