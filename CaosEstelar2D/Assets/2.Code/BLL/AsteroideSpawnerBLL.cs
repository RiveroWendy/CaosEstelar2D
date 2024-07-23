using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;

namespace BLL
{
    public class AsteroideSpawnerBLL : MonoBehaviour
    {
        private float _spawnRate;

        public float SpawnRate
        {
            get { return _spawnRate; }
            set { _spawnRate = value; }
        }

        private float _spawnRadio;

        public float SpawnRadio
        {
            get { return _spawnRadio; }
            set { _spawnRadio = value; }
        }

        private GameObject _asteroidPrefab;

        public GameObject AsteroidPrefab
        {
            get { return _asteroidPrefab; }
            set { _asteroidPrefab = value; }
        }

        public void SpawnAsteroid()
        {

        }

    }

}