using UnityEngine;
using System.Collections;

public class Stunnable : MultiplayerBehaviour {

    private bool _isStunned;
    public bool IsStunned
    {
        get
        {
            return _isStunned;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Stun(float stunTime)
    {
        Debug.Log("Player " + PlayerID + " Stunned");
        _isStunned = true;
        Invoke("EndStun", stunTime);
    }

    private void EndStun()
    {
        Debug.Log("Ended Player " + PlayerID + " Stun");
        _isStunned = false;
    }
}
