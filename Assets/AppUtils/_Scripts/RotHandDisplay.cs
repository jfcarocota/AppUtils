using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotHandDisplay : MonoBehaviour
{
    [SerializeField]
    GameObject rotableUI;

    [SerializeField]
    Vector2 range;


    private void Update()
    {
        rotableUI.SetActive(transform.localRotation.z >= range.x &&
            transform.localRotation.z <= range.y);
    }
}
