using System;
using UniRx;

namespace GameLogic.Services
{
    public class TestService
    {
        public void RunMethodAfterSeconds<T>(Action<T> action, T paramater, float time)
        {
            Observable.Timer(TimeSpan.FromSeconds(time))
                .Subscribe(_ =>
                {
                action(paramater);
                });

        }
    }
}
