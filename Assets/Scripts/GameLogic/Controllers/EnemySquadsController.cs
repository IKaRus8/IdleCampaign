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
	private ISquadEnemyStateManager _enemySquadStateManager;

	[Inject]
	void Construct(ISquadEnemyStateManager squadEnemyStateManager)
	{
		_enemySquadStateManager = squadEnemyStateManager;
	}

	private void FixedUpdate()
	{
		_enemySquadStateManager.RunState();
	}


}
