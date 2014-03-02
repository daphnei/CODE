using UnityEngine;
using System.Collections;

public class FlyIn : MonoBehaviour {

	private Vector3 startPosition;
	private Vector3 startRotate;

	public Vector3 flyPositionOffset = Vector2.one * 5f;
	public float flyRotationOffset = 20f;
	public float time = 0.5f;
	public float delay = 0f;

	float d = 0;
	float t = 1;
	float sign = 1;

	// Use this for initialization
	void Awake () {
		this.startPosition = this.transform.localPosition;
		this.startRotate = this.transform.localRotation.eulerAngles;

		TriggerIn();
	}

	// Update is called once per frame
	void Update () {

		if (this.d > 0f)
			this.d -= Time.deltaTime;
		else {
			this.t += (Time.deltaTime / time) * sign;
			if (this.t < 0)
				t = 0;
			if (this.t > 1)
				t = 1;
		}

        Reposition();

		// Color c = this.renderer.material.color;
		// c.a = 0.5f;
		// this.renderer.material.color = c;
	}

	void OnMouseDown() {
		// TriggerIn();
	}

	public void TriggerIn() {
		this.t = 0;
		this.d = delay;
		this.sign = 1;
	}

	public void TriggerOut() {
		this.t = 1;
		this.d = delay;
		this.sign = -1;
	}

    private void Reposition() {
        float lerp = 1 - Mathf.SmoothStep(0, 1, t);
        this.transform.localPosition = Vector3.Lerp(startPosition, startPosition + flyPositionOffset * sign, lerp);
        this.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(startRotate), Quaternion.Euler(startRotate + new Vector3(0, 0, flyRotationOffset)), lerp);
    }
}
