using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFire : MonoBehaviour {
    public GameObject go;

    public void SwitchFireTo()
    {
        if (go.gameObject.activeSelf == true)
        {
            go.SetActive(false);
            Debug.Log("Set to false");
            return;
        }
        if (go.gameObject.activeSelf == false)
        {
            go.SetActive(true);
            Debug.Log("Set to true");
            return;
        }
        else Debug.Log("Wtf just happend??");

    }
}
