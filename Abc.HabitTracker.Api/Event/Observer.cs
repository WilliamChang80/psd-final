using Abc.HabitTracker.Api.Entity;
using System;

namespace Abc.HabitTracker.Api.Event
{
    public interface IObserverCustom<T>
    {
        void Update(T e);
    }

    public interface IObservableCustom<T>
    {
        void Attach(IObserverCustom<T> obs);
        void Broadcast(T e);
    }
}