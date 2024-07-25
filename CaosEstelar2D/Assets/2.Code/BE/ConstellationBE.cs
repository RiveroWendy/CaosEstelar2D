using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;
public class ConstellationBE: MonoBehaviour
{
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

    public ConstellationBE()
    {
        _currentIndex = 0;
        _constellationCompleted = false;
    }
}
