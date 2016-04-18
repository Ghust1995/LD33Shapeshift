using UnityEngine;
using System.Collections;

public class VertexSound : MonoBehaviour {

    private AudioSource source;

    // Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.clip = transform.parent.parent.GetComponent<Player>().MoveSound;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Platform")
        {
            source.Play();
        }
    }
}
