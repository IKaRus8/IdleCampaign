using GameInfoModels.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameInfoModels.Interfaces
{
	public interface IEnemySquadsProvider
	{
		List<IEnemyProvider> Enemies { get; set; }
	}
}
