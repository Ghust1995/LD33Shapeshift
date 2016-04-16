using UnityEngine;
using System.Collections;

public abstract class MultiplayerBehaviour : MonoBehaviour {

    private int _playerID;
    protected int PlayerID
    {
        get
        {
            if (_playerID == 0)
            {
                _playerID = int.Parse(gameObject.name.Remove(0, gameObject.name.Length - 1));
            }
            return _playerID;
        }
    }

    protected string AxisString(string axisName)
    {
        return PlayerID + "_" + axisName;
    }
}
