using GameInfoModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameInfoModels
{
	public class UnitOptions : MonoBehaviour, IUnitOptions
	{
		[SerializeField]
		private Rigidbody _rigidbody;
		[SerializeField]
		private float _squadChaseRadius;
		[SerializeField]
		private float _squadAttackRadius;
		[SerializeField]
		private float _unitAttackRadius;

		public Rigidbody SquadRigidbody { get => _rigidbody; }
		public float SquadChaseRadius { get => _squadChaseRadius; }
		public float SquadAttackRadius { get => _squadAttackRadius; }
		public float UnitAttackRadius { get => _unitAttackRadius; }
		public float Velocity => 30f;

	}
}
