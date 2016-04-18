using UnityEngine;
using System.Collections;

public class ThumbStick : MultiplayerBehaviour {

    public float maxangle = 30;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gameStart == false && GameManager.gameStarting == false)
        {

            transform.eulerAngles = new Vector3(Input.GetAxis(AxisString("Vertical")) * maxangle, -Input.GetAxis(AxisString("Horizontal")) * maxangle, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
