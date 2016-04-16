using UnityEngine;
using System.Collections;

public abstract class MultiplayerBehaviour : MonoBehaviour {

    protected int PlayerID;

    void Start()
    {
        PlayerID = int.Parse(gameObject.name.Remove(0, gameObject.name.Length));
    }

    protected string AxisString(string axisName)
    {
        return PlayerID + "_" + axisName;
    }
}
