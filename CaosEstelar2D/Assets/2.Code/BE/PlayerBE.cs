using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BE
{
    public class PlayerBE
    {
        private float _speedMovement = 5f;

        public float SpeedMovement
        {
            get { return _speedMovement; }
            set { _speedMovement = value; }
        }


        private float _jumpForce = 5f;

        public float JumpForce
        {
            get { return _jumpForce; }
            set { _jumpForce = value; }
        }

        public PlayerBE()
        {
            
        }
    }
}