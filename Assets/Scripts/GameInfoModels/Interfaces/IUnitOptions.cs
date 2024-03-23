using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameInfoModels.Interfaces
{
	public interface IUnitOptions
	{

		public Rigidbody SquadRigidbody { get; }
		public float SquadChaseRadius { get; }
		public float SquadAttackRadius { get; }
		public float UnitAttackRadius { get; }
		public float Velocity { get; }
	}
}
