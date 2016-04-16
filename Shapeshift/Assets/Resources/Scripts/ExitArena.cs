using UnityEngine;
using System.Collections;

public class ExitArena : MonoBehaviour {
	
	void OnTriggerExit(Collider other){
		other.gameObject.GetComponent<Player>().Die();
	}
}
