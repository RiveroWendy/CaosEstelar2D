using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BE
{
    public class PlayerBE : MonoBehaviour
    {
        private float _speedMovement;

        public float SpeedMovement
        {
            get { return _speedMovement; }
            set { _speedMovement = value; }
        }


        private float _jumpForce;

        public float JumpForce
        {
            get { return _jumpForce; }
            set { _jumpForce = value; }
        }

    }
}