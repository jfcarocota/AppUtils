using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRbutton : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    Transform objectSelected;

    public Transform ObjectSelected
    {
        get
        {
            return objectSelected;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IndexTip"))
        {
            Click();
        }
    }

    private void Start()
    {
        gm = GameManager.instance;
    }

    public virtual void Click()
    {
        gm.Target = objectSelected;
        gm.Aud.PlayOneShot(gm.ButtonBeepSFX);
        Debug.Log("Click");
    }
}
