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


        private float _jumpForce = 7f;

        public float JumpForce
        {
            get { return _jumpForce; }
            set { _jumpForce = value; }
        }

        private int _limitJumps = 3;

        public int LimitJumps
        {
            get { return _limitJumps; }
            set { _limitJumps = value; }
        }

        private bool _playerOnTheGround = false;

        public bool PlayerOnTheGround
        {
            get { return _playerOnTheGround; }
            set { _playerOnTheGround = value; }
        }

        public PlayerBE()
        {
            
        }
    }
}