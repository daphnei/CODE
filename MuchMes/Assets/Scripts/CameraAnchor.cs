using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraAnchor : MonoBehaviour {

	public Vector2 anchorPosition = new Vector2(0, 1);

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = CameraPosition.instance.GetCameraPosition(anchorPosition);

		Transform backPlane = this.transform.FindChild("BackPlane");
		if (backPlane != null) {
			// Standard Unity plane is 10x10.
			Vector3 scale = Vector3.one * ((1f / 10f) * Camera.main.orthographicSize * 2);
			scale.x *= Camera.main.aspect;
			backPlane.localScale = scale;
			backPlane.localPosition = 10 * new Vector3(scale.x, -scale.y, 0) / 2f;
		}
	}
}
