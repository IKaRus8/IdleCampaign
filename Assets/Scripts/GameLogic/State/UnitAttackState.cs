using Data.Enums;
using Models;
using Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

namespace GameLogic.State
{
    public class UnitAttackState : UnitBaseState
    {
        private float _timeBetweenAttack = 2f;
        public UnitAttackState() : base(GameState.Attack)
        {
        }

        public override void RunCurrentState(IUnit unit)
        {
            if(!unit.IsAttacking)
                MainThreadDispatcher.StartCoroutine(AttackEnemy(unit));
        }
        IEnumerator AttackEnemy(IUnit unit)
        {
            unit.IsAttacking = true;
            unit.TargetToPursue.TakeDamage(unit.Attack);
            yield return new WaitForSeconds(_timeBetweenAttack);
            unit.IsAttacking = false;
        }
    }
}
