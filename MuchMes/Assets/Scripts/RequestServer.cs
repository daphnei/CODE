using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using SimpleJSON;
using System.Collections.Generic;

public static class RequestServer {
	public static List<Question> GetQuestions() {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create ("http://localhost:3000/questions/generate/random?count=10");
		HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
		Stream receiveStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (receiveStream);


		JSONNode json = JSON.Parse (reader.ReadToEnd ());
		List<Question> questions = new List<Question>();
		foreach (JSONNode node in json.AsArray) {
			questions.Add(Question.FromJSON(node));
		}

		reader.Close ();
		response.Close ();

		return questions;
	}
}
