using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;

public class RequestServer : MonoBehaviour {
	// Use this for initialization
	void Start() {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create ("http://www.timeapi.org/utc/now");
		HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
		Stream receiveStream = response.GetResponseStream();
		StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);

		Debug.Log("Read response");
		Debug.Log("Response is: " + reader.ReadToEnd());

		response.Close();
		reader.Close();
	}

	// Update is called once per frame
	void Update() {
	}
}
