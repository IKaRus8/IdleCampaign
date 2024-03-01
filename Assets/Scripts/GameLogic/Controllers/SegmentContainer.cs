using GameLogic.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Unity.AI.Navigation;
using UnityEngine;

namespace GameLogic.Controllers
{
    public class SegmentContainer : MonoBehaviour, ISegmentContainer
    {
        private const float SegmentLength = 100;

        [SerializeField]
        private List<RoadController> _roads;
        public ReactiveProperty<IRoadController> ActiveRoadRx { get; } = new();
        public ReactiveProperty<float> EdgeSegmentPos { get; } = new();

        private NavMeshSurface _navMeshSurface;

        private IRoadController _edgeSegment;

        private void Awake()
        {
            _navMeshSurface = GetComponent<NavMeshSurface>();
        }
        private void Update()
        {
            var currentSegment = _roads.FirstOrDefault(r => r.IsActive);

            _roads.ToObservable().Subscribe();

            if (currentSegment != null && currentSegment != ActiveRoadRx.Value)
            {
                ReplaceSegment();

                _edgeSegment = ActiveRoadRx.Value;

                ActiveRoadRx.Value = currentSegment;
            }
        }

        private void ReplaceSegment()
        {
            if (_edgeSegment != null)
            {
                var wayPoint = _edgeSegment.WayPoint + _roads.Count * SegmentLength;
                EdgeSegmentPos.Value = wayPoint;
                _edgeSegment.SetPosition(new Vector3(0, 0, wayPoint));

				_navMeshSurface.BuildNavMesh();
			}
        }
    }
}