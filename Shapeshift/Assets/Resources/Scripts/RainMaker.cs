using UnityEngine;
using System.Collections;

public class RainMaker : MonoBehaviour {

	public Mesh[] meshes;
	public Color[] colors = {Color.blue, Color.red, Color.green};
	public GameObject rainDropPrefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating("MakeItRain", 0f, 0.4f);
	}
	
	void MakeItRain(){
		GameObject instantiated = Instantiate(rainDropPrefab, new Vector3(Random.Range(0f,25f),Random.Range(0f,10f), Random.Range(0f,20f)), Quaternion.identity) as GameObject;
		instantiated.transform.SetParent(GameObject.Find("Rain Maker").transform, false);
		instantiated.GetComponent<MeshFilter>().mesh = meshes[Random.Range(0,2)];
		instantiated.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0,2)];
		instantiated.GetComponent<Rigidbody>().AddTorque(300*Random.insideUnitSphere);
	}
}
