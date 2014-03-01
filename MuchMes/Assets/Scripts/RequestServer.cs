using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using SimpleJSON;
using System.Collections.Generic;

public static class RequestServer {
	public static Question GetQuestion() {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create ("http://localhost:3000/questions/generate?type=composition");
		HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
		Stream receiveStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (receiveStream);

		JSONNode json = JSON.Parse (reader.ReadToEnd ());
		Question question = Question.FromJSON (json);

		reader.Close ();
		response.Close ();

		return question;
	}
}
