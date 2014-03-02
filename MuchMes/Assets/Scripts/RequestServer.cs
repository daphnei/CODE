using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System.Text;
using SimpleJSON;
using System.Collections.Generic;
using System;

public static class RequestServer {

	static String serverURL = "http://agile-basin-3337.herokuapp.com/";

	private static JSONNode Request(String requestStr) {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create (serverURL + requestStr);
		HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
		Stream receiveStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (receiveStream);
		JSONNode j = JSON.Parse (reader.ReadToEnd ());
		reader.Close ();
		response.Close ();
		return j;
	}

	private static JSONNode SecureRequest(String requestStr) {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create (serverURL + requestStr);
		HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
		Stream receiveStream = response.GetResponseStream ();
		StreamReader reader = new StreamReader (receiveStream);
		JSONNode j = JSON.Parse (reader.ReadToEnd ());
		reader.Close ();
		response.Close ();
		return j;
	}

	public static List<Question> GetQuestions() {
		JSONNode json = Request("questions/cached?count=20");
		List<Question> questions = new List<Question>();
		foreach (JSONNode node in json.AsArray) {
			questions.Add(Question.FromJSON(node));
		}
		return questions;
	}

	public static string GetSearchImageURL(String search) {
		JSONNode json = Request("image?keyword=" + search);

		return "AS";
	}
}
