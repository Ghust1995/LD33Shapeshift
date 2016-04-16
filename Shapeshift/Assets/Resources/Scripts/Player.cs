using UnityEngine;
using System.Collections;

public class Player : MultiplayerBehaviour {
    
	public void Die(){
		Destroy(this.gameObject);
		//End game
	}

}