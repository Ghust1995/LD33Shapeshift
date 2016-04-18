using UnityEngine;
using System.Collections;

public class MissMark : MonoBehaviour {

    public Transform thingToFollow;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(thingToFollow.position.x, transform.position.y, thingToFollow.position.z);
        Invoke("Die", 0.3f);
	}

    void Die()
    {
        Destroy(this.gameObject);
    }
}
