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

namespace GameLogic.State
{
    public class UnitAttackState : UnitBaseState
    {
        private float _timeBetweenAttack = 2f;
        private bool _isAttacking = false;
        public UnitAttackState() : base(GameState.Attack)
        {
        }

        public override void RunCurrentState(IUnit unit)
        {
            if(!_isAttacking)
                MainThreadDispatcher.StartCoroutine(AttackEnemy(unit.TargetToPursue,unit.Attack));
        }
        IEnumerator AttackEnemy(IEnemy enemy, float unitAttack)
        {
            _isAttacking = true;
            enemy.TakeDamage(unitAttack);
            yield return new WaitForSeconds(_timeBetweenAttack);
            _isAttacking = false;
        }
    }
}
