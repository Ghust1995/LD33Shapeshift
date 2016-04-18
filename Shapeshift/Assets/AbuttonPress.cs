using UnityEngine;
using System.Collections;

public class AbuttonPress : MultiplayerBehaviour {

    Vector3 initialPos;

    public float depth = 0.5f;
	
    // Use this for initialization
	void Start () {
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameStart == false && GameManager.gameStarting == false)
        {
            transform.position = initialPos + new Vector3(0, 0, Input.GetButton(AxisString("Attack")) ? depth : 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
