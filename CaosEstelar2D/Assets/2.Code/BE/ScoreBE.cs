using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBE : MonoBehaviour
{
	private int _levelScore;

	public int LevelScore
	{
		get { return _levelScore; }
		set { _levelScore = value; }
	}

	private int _totalScore;

	public int TotalScore
	{
		get { return _totalScore; }
		set { _totalScore = value; }
	}

}
