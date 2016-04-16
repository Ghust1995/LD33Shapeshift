﻿using UnityEngine;
using System.Collections;

public class TopDownMovement : MultiplayerBehaviour {

    Rigidbody2D rigidBody;

    [SerializeField]
    float MOVE_SPEED = 5.0f;

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
            var x = Input.GetAxis(AxisString("Horizontal"));
            var y = Input.GetAxis(AxisString("Vertical"));
            rigidBody.velocity = MOVE_SPEED * new Vector2(x, y);
            //TODO: Fix rotation
            //if(x != 0 || y != 0)
                //transform.rotation = new Quaternion(0, 0, Mathf.Sin(Mathf.Atan2(x, y)), Mathf.Cos(Mathf.Atan2(x, y)));

        }
    }
   
}
