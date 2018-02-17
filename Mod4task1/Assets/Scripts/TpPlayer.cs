using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlayer : MonoBehaviour
{
    private static TpPlayer instance;
    private void Start()
    {
        instance = this;
    }
    public static Vector3 GetPosition()
    {
        return instance.transform.position;
    }
    public static void SetPosition(Vector3 position)
    {
        instance.transform.position = new Vector3(position.x, 1.8f, position.z);
    }
}
