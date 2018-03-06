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

        animate = AnimateButton(0.001f);
        StartCoroutine(animate); 
    }

    IEnumerator AnimateButton(float time)
    {
        while (Vector3.Distance(buttons[0].localPosition, directionList[0].localPosition) > 0.02f)
        {
            Debug.Log("dude im working");
            buttons[0].Translate(directionList[0].localPosition *
                3f * Time.deltaTime);
            yield return new WaitForSeconds(time);
        }
    }
}
