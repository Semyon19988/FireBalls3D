using System;
using System.Collections.Generic;
using Factory;
using UnityEngine;

namespace Pool
{
	public class ComponentPool<T> : IPool<T> where T :Component
	{
		private readonly Stack<T> _availableMembers = new Stack<T>();
		private readonly IFactory<T> _factory;
		private readonly Transform _root;

		private readonly int _initialCapacity;

		public ComponentPool(IFactory<T> factory, Transform root, int initialCapacity)
		{
			_factory = factory;
			_root = root;
			if (initialCapacity < 0)
				throw new ArgumentOutOfRangeException(nameof(initialCapacity));
			_initialCapacity = initialCapacity;
		}
		
		public void Prewarm()
		{
			for (int i = 0; i < _initialCapacity; i++)
			{
				T member = _factory.Create();
				Setup(member);
				_availableMembers.Push(member);
			}
		}

		public T Request()
		{
			T member;
			if (_availableMembers.Count > 0)
			{
				member = _availableMembers.Pop();
				
			}
			else
			{
				member = _factory.Create();
				Setup(member);
			}
			Show(member);

			return member;
		}

		public void Return(T member)
		{
			_availableMembers.Push(member);
			
			Setup(member);
		}

		private void Setup(T member)
		{
			member.transform.SetParent(_root);
			member.gameObject.SetActive(false);
		}

		private void Show(T member) =>
			member.gameObject.SetActive(true);
	}
}