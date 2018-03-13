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
    [SerializeField]
    float scaleForce;

    float pinchiAdistance;
    float pinchBdistance;

    [SerializeField]
    Transform[] targetSelected;

    [SerializeField]
    Transform target;

    Vector3 middlePoint;
    Character character;

    Vector3 initialSize;
    float initialScaleFactor;

    private void Update()
    {
        pinchiAdistance = Vector3.Distance(thumbR.position, indexR.position);
        pinchBdistance = Vector3.Distance(thumbL.position, indexL.position);

        //Debug.Log(pinchiAdistance);

        isPinching = pinchiAdistance < pinchLimit 
            && pinchBdistance < pinchLimit;
        if (isPinching)
        {
            if (!target)
            {
                initialScaleFactor = Vector3.Distance(scaleA.position, scaleB.position);
                target = targetSelected[0];
                initialSize = target.transform.localScale;
                GameObject myObj = (GameObject)Instantiate(target.gameObject, Vector3.zero, Quaternion.identity);
                character = myObj.GetComponent<Character>();
            }

            scaleFactor = Vector3.Distance(scaleA.position, scaleB.position);
            float scaleChange = initialScaleFactor - scaleFactor;
            character.transform.localScale = target.localScale.x <= 0f ? Vector3.one : Vector3.one * scaleChange * scaleForce;
            character.transform.position = GetPoint(scaleA.position, scaleB.position);

        }
        else
        {
            if (target)
            {
                character.Rb.useGravity = true;
                target = null;
                character = null;
            }
        }
    }

    Vector3 GetPoint(Vector3 a, Vector3 b)
    {

        //get the direction between the two transforms -->
        Vector3 dir = (b - a).normalized;

        //get a direction that crosses our [dir] direction
        //NOTE! : this can be any of a buhgillion directions that cross our [dir] in 3D space
        //To alter which direction we're crossing in, assign another directional value to the 2nd parameter
        Vector3 perpDir = Vector3.Cross(dir, Vector3.right);

        //get our midway point
        Vector3 midPoint = (a + b) / 2f;

        return midPoint;
    }

}
