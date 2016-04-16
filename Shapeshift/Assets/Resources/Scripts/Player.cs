using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int PlayerID;

	public void Die(){
		Destroy(this.gameObject);
		//End game
	}

}