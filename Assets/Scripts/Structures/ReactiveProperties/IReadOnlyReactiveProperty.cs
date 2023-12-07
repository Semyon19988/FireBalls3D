using System;

namespace Structures.ReactiveProperties
{
	public interface IReadOnlyReactiveProperty<out T>
	{
		T Value { get; }

		void Subscribe(Action<T> valueChanged);
		void Unsubscribe(Action<T> valueChanged);
	}
}