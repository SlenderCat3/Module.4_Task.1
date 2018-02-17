using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToPosition : MonoBehaviour {
    public GameObject play;
    public GameObject way;
    public void MovePlayer()
    {
        play.transform.position = way.transform.position;
    }
}
