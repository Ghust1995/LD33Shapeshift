using UnityEngine;
using System.Collections;

public class ExitArena : MonoBehaviour {
	
	void OnTriggerExit(Collider other){
		if(other.gameObject.transform.parent.tag == "Player")
            other.gameObject.GetComponentInParent<Player>().Die();
	}
}
