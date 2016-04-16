using UnityEngine;
using System.Collections;

public class TopDownMovement : MultiplayerBehaviour {

    Rigidbody2D rigidBody;

    [SerializeField]
    float MOVE_SPEED = 0.0f;
    [SerializeField]
    float TURN_SPEED = 0.0f;

    Stunnable hitStunInfo;
    AreaAttacker atackInfo;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        hitStunInfo = GetComponent<Stunnable>();
        atackInfo = GetComponent<AreaAttacker>();
    }
	
	// Update is called once per frame
	void Update () {
        if(!hitStunInfo.IsStunned && !atackInfo.IsAttacking)
        {
            rigidBody.velocity = MOVE_SPEED * Input.GetAxis(AxisString("Vertical")) * transform.up;
            transform.Rotate(0, 0, -TURN_SPEED * Input.GetAxis(AxisString("Horizontal")));
        }
    }
}
