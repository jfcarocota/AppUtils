using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenu : MonoBehaviour
{
    [SerializeField]
    Color circleColor = Color.yellow;
    [SerializeField, Range(0f, 10f)]
    float radius;
    [SerializeField]
    List<Transform> buttons;
    [SerializeField]
    List<Transform> directionList;

    [SerializeField]
    float animationTime;
    [SerializeField]
    float stopDistance;

    IEnumerator animate;

    private void Awake()
    {
        GetChilds(transform);
    }

    private void Start()
    {
        //StartCoroutine(animate);
        //Debug.Log(animate);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = circleColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void GetChilds(Transform p)
    {
        foreach(Transform t in p)
        {
            buttons.Add(t);
        }
    }

    private void OnDisable()
    {
        StopCoroutine(animate);
        
        foreach(Transform b in buttons)
        {
            b.transform.localPosition = Vector3.zero;
        }
    }

    private void OnEnable()
    {
        /*buttons[0].localPosition = directionList[2].localPosition;
        buttons[1].localPosition = directionList[1].localPosition;
        buttons[2].localPosition = directionList[0].localPosition;*/

        animate = AnimateButton(animationTime);
        StartCoroutine(animate); 
    }

    IEnumerator AnimateButton(float time)
    {
        float distanceA = Vector3.Distance(buttons[0].localPosition,
            directionList[0].localPosition);
        float distanceB = Vector3.Distance(buttons[1].localPosition,
            directionList[1].localPosition);
        float distanceC = Vector3.Distance(buttons[2].localPosition,
            directionList[2].localPosition);

        while (distanceA > stopDistance | distanceB > stopDistance | distanceC > stopDistance)
        {
            distanceA = Vector3.Distance(buttons[0].localPosition,
                directionList[0].localPosition);
            distanceB = Vector3.Distance(buttons[1].localPosition,
                directionList[1].localPosition);
            distanceC = Vector3.Distance(buttons[2].localPosition,
                directionList[2].localPosition);

            if (distanceA > stopDistance)
            {
                AnimateSomething(buttons[0], directionList[0]);
            }
            if (distanceB > stopDistance)
            {
                AnimateSomething(buttons[1], directionList[1]);
            }
            if (distanceC > stopDistance)
            {
                AnimateSomething(buttons[2], directionList[2]);
            }
            yield return new WaitForSeconds(time);
        }
    }

    void AnimateSomething(Transform a, Transform target)
    {
        a.Translate(target.localPosition *
                    3f * Time.deltaTime);
    }
}
