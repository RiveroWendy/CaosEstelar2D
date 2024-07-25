using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BE
{
    public class StarBE
    {
        private int _idEstrella;

        public int IdEstrella
        {
            get { return _idEstrella; }
            set { _idEstrella = value; }
        }
        private bool _isTouched = false;

        public bool IsTouched
        {
            get { return _isTouched; }
            set { _isTouched = value; }
        }

        public StarBE(int idEstrella)
        {
            this._idEstrella = idEstrella;
        }


    }
}