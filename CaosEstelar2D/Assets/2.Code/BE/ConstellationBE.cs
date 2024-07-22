using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstellationBE : MonoBehaviour
{
	private List<int> _starOrder;

	public List<int> StarOrder
	{
		get { return _starOrder; }
		set { _starOrder = value; }
	}

	private int _currentIndex;

	public int CurrentIndex
	{
		get { return _currentIndex; }
		set { _currentIndex = value; }
	}

	private StarBE _star;

	public StarBE Star
	{
		get { return _star; }
		set { _star = value; }
	}

	private bool _constellationCompleted;

	public bool ConstellationCompleted
	{
		get { return _constellationCompleted; }
		set { _constellationCompleted = value; }
	}

}
