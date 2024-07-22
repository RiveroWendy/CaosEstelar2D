using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBE : MonoBehaviour
{
	private float _totalTime;

	public float TotalTime
	{
		get { return _totalTime; }
		set { _totalTime = value; }
	}

	private float _currentTime;

	public float CurrentTime
	{
		get { return _currentTime; }
		set { _currentTime = value; }
	}

	private bool _isGamePaused;

	public bool IsGamePaused
	{
		get { return _isGamePaused; }
		set { _isGamePaused = value; }
	}


}
