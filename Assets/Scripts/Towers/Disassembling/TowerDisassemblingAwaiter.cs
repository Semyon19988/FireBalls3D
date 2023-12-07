using System;
using System.Runtime.CompilerServices;

namespace Towers.Disassembling
{
	public struct TowerDisassemblingAwaiter : INotifyCompletion
	{
		private readonly TowerDisassembling _disassembling;
		private Action _continuation;
		public bool IsCompleted { get; private set; }

		public TowerDisassemblingAwaiter(TowerDisassembling disassembling)
		{
			_disassembling = disassembling;
			_continuation = null;
			IsCompleted = false;
		}

		public string GetResult() => string.Empty;

		public void OnCompleted(Action continuation)
		{
			_continuation = continuation;
			_disassembling.Disassembled += OnTowerDisassembled;
		}

		private void OnTowerDisassembled()
		{
			_continuation.Invoke();
			IsCompleted = true;
		}
	}
}