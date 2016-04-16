using UnityEngine;
using System.Collections;

public class TopDownMovement : MultiplayerBehaviour {

    Rigidbody2D rigidbody;

    [SerializeField]
    float MOVE_SPEED;
    [SerializeField]
    float TURN_SPEED;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = MOVE_SPEED * Input.GetAxis(AxisString("Vertical")) * transform.up;
        Debug.Log(rigidbody.velocity);
        transform.Rotate(0,0,-TURN_SPEED * Input.GetAxis(AxisString("Horizontal")));
    }
}
