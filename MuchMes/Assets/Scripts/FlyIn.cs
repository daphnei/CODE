using UnityEngine;
using System.Collections;

public class FlyIn : MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 startRotate;

	public Vector3 flyPositionOffset = Vector2.one * 5f;
	public float flyRotationOffset = 20f;
	public float multiplier = 0.80f;

	float t = 1;

	// Use this for initialization
	void Start () {
		this.startPosition = this.transform.localPosition;
		this.startRotate = this.transform.localRotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		this.t = t * multiplier;

		if (t > float.Epsilon) {

			Color c = this.renderer.material.color;
			c.a = 0.5f;
			this.renderer.material.color = c;

			this.transform.localPosition = Vector3.Lerp(startPosition, startPosition + flyPositionOffset, t);
			this.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(startRotate), Quaternion.Euler(startRotate + new Vector3(0, 0, flyRotationOffset)), t);
		}
	}

	void OnMouseDown() {
		this.t = 1;
	}
}
