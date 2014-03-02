using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class TimerManager : MonoBehaviour {

	public static TimerManager instance;

	private class Timer {
		public Action timerAction;
		public float timerTime;
		public float timer;

		public Timer(Action action, float time) {
			this.timerTime = time;
			this.timerAction = action;
			this.timer = 0;
		}
	}

	List<Timer> timers = new List<Timer>();

	void Awake() {
		TimerManager.instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Timer t in timers) {
			t.timer += Time.deltaTime;
			if (t.timer > t.timerTime) {
				if (t.timerAction != null) {
					t.timerAction();
				}
				t.timer = -1;
			}
		}
		timers.RemoveAll(t => t.timer == -1);
	}

	public void StartTimer(Action action, float time) {
		timers.Add(new Timer(action, time));
	}
}
