using UnityEngine;
using System.Collections;

public class ExitArena : MonoBehaviour {
	
	void OnTriggerExit2D(Collider2D other){
		other.gameObject.GetComponent<Player>().Die();
	}
}
