using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BE
{
public class AsteroideBE : MonoBehaviour
{
	private float _speedMovement;

	public float SpeedMovement
	{
		get { return _speedMovement; }
		set { _speedMovement = value; }
	}

	private float _lifeTime;

	public float LifeTime
	{
		get { return _lifeTime; }
		set { _lifeTime = value; }
	}

	private Transform _playerPosition;

	public Transform PlayerPosition
	{
		get { return _playerPosition; }
		set { _playerPosition = value; }
	}

	private void CalcularAngulo()
	{

	}
}
}