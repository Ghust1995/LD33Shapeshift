using UnityEngine;
using System.Collections;

public abstract class MultiplayerBehaviour : MonoBehaviour {

    private int _playerID;
    public int PlayerID
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
        var joysticks = Input.GetJoystickNames();
        var s = PlayerID + "_" + axisName;
        if (PlayerID <= joysticks.Length)
        {
            s = "j" + s;
        }
        return s;
    }
}
