using System;
using System.Collections.Generic;
using GameLogic.Controllers;
using GameLogic.Interfaces;
using UniRx;

namespace GameLogic.Services
{
    public class RoadManager : IDisposable
    {
        private IRoadController _currentRoad;
        private readonly ISegmentContainer _segmentContainer;
        private readonly IDisposable _disposable;

        public RoadManager(ISegmentContainer segmentContainer)
        {
            _segmentContainer = segmentContainer;

            _disposable = _segmentContainer.ActiveRoadRx.Subscribe(ChangeRoad);
        }

        private void ChangeRoad(IRoadController road)
        {
            if (road == null)
            {
                return;
            }
            
            _currentRoad = road;
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}