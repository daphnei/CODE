using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour {

	public float snapDistance = 0.25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.isPlaying || this.transform.parent == null)
			return;

		Vector3 localTopLeft = this.transform.localPosition;
		if (this.renderer != null) {
			localTopLeft.x = this.renderer.bounds.min.x - this.transform.parent.position.x;
			localTopLeft.y = this.renderer.bounds.max.y - this.transform.parent.position.y;
		}

		Vector3 localTopLeftSnap = Vector3.zero;
		localTopLeftSnap.x = Mathf.Round(localTopLeft.x / snapDistance) * snapDistance;
		localTopLeftSnap.y = Mathf.Round(localTopLeft.y / snapDistance) * snapDistance;

		Vector3 topLeftToCenter = this.transform.localPosition - localTopLeft;

		this.transform.localPosition = localTopLeftSnap + topLeftToCenter;
	}
}
