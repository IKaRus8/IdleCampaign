using GameInfoModels.Interfaces;
using GameLogic.Interfaces;
using GameLogic.State;
using UnityEngine;
using Zenject;

namespace GameLogic.Controllers
{
    public class PlayerSquadController : MonoBehaviour
    {
		private ISquadUnitsStateManager _squadUnitsStateManager;

        [Inject]
        void Construct(ISquadUnitsStateManager squadUnitsStateManager)
        {
            _squadUnitsStateManager = squadUnitsStateManager;
        }

		private void FixedUpdate()
        {
           _squadUnitsStateManager.RunState();
        }
    }
}