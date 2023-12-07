using System;

namespace Structures.ReactiveProperties
{
	public interface IReactiveProperty<T> : IReadOnlyReactiveProperty<T>
	{
		void Change(T value);
	}

	public class FakeReactiveProperty<T> : IReactiveProperty<T>
	{
		public T Value { get; }
		
		public void Subscribe(Action<T> valueChanged){ }

		public void Unsubscribe(Action<T> valueChanged) { }

		public void Change(T value) { }
	}
}