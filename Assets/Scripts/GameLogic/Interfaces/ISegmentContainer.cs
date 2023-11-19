using UniRx;

namespace GameLogic.Interfaces
{
    public interface ISegmentContainer
    {
        ReactiveProperty<IRoadController> ActiveRoadRx { get; }
        ReactiveProperty<float> EdgeSegmentPos { get; }
    }
}