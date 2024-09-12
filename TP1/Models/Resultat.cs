using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Models
{
    public class Resultat
    {
		private int _note;

        public Resultat(int note)
        {
            _note = note;
        }

        public int Note
		{
			get { return _note; }
			set { _note = value; }
		}

		
		public bool Reussite
		{
			get { return _note >= 60; }
		}

	}
}
