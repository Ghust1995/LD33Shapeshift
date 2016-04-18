using UnityEngine;
using System.Collections;

public class ColorShifter : MonoBehaviour {

    public float saturation = 220;
    public float value = 255;
    public float hueSpeed = 0.1f;
    private MeshRenderer meshRenderer;
    private static float startHue = Random.Range(0.0f, 1.0f);

    public Vector3 hsvCurrent;

	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        hsvCurrent = new Vector3();
        meshRenderer.material.color = Color.HSVToRGB(startHue, saturation / 256.0f, value / 256.0f);
    }
	
	// Update is called once per frame
	void Update () {       

        var hsvNext = new Vector3(.5f, saturation/256.0f, value/256.0f);

        var rgbCurrent = meshRenderer.material.color;

        Color.RGBToHSV(rgbCurrent, out hsvCurrent.x, out hsvCurrent.y, out hsvCurrent.z);

        hsvNext.x = (hsvCurrent.x + (hueSpeed / 256.0f)) % 1.0f;

        meshRenderer.material.color = Color.HSVToRGB(hsvNext.x, hsvNext.y, hsvNext.z);

    }
}
