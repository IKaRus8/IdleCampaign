using GameInfoModels.Interfaces;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UI.Interfaces;
using UnityEngine;

namespace GameInfoModels
{
    public class EnemyProvider : IEnemyProvider
    {
        public List<IEnemy> Enemies { get; set; } = new List<IEnemy>();
        public bool IsEnemyNotExist => Enemies.Count == 0;

        public Vector3 EnemySquadPosition => Enemies[0].EnemyPosition;
        public IEnemy NearestEnemy => Enemies.OrderBy(o => o.EnemyPosition).Where(s => !s.IsDead).FirstOrDefault();
		public void RemoveDeadEnemies()
        {
            Enemies.RemoveAll(u => u.IsDead == true);
        }
    }
}