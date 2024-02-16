using System.Collections;
using System.Collections.Generic;
using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using GameLogic.State;
using GameLogic.StateEnemy;
using UnityEngine;
using Zenject;

public class EnemySquadsController : MonoBehaviour
{
	[SerializeField]
	private float _enemySquadChaseRadius;
	[SerializeField]
	private float _enemySquadAttackRadius;
	[SerializeField]
	private float _enemyAttackRadius;

	private IEnemySquadsProvider _enemySquadsProvider;
	private ISquadUnitsProvider _squadUnitsProvider;
	private EnemySquadStateManager _enemySquadStateManager;

	[Inject]
	void Construct(IEnemySquadsProvider enemySquadsProvider, ISquadUnitsProvider squadUnitsProvider)
	{
		_enemySquadsProvider = enemySquadsProvider;
		_squadUnitsProvider = squadUnitsProvider;
	}
	private void Start()
	{
		_enemySquadStateManager = new EnemySquadStateManager(_enemySquadsProvider,_squadUnitsProvider, _enemySquadAttackRadius,_enemySquadChaseRadius,_enemyAttackRadius);
	}
	private void FixedUpdate()
	{
		_enemySquadStateManager.RunState();
	}


}
