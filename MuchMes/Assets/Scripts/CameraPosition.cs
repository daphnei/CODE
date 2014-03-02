using UnityEngine;
using System.Collections;

public class CameraPosition {

	public static CameraPosition instance = new CameraPosition(Camera.main);

	Camera camera;

	public CameraPosition(Camera camera) {
		this.camera = camera;
	}

	public Vector3 GetCameraPosition(Vector2 anchor) {
		Vector3 position = Camera.main.ScreenToWorldPoint (new Vector3 (anchor.x * Camera.main.pixelWidth, anchor.y * Camera.main.pixelHeight, 10));
		position.z = 0;
		return position;
	}
}
