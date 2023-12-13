using System;
using UnityObject = UnityEngine.Object;

namespace Tools
{
	public static class Inspector
	{
		public static void ValidateOn<T>(ref UnityObject validatedObject)
		{
			if (validatedObject != null && validatedObject is T == false)
			{
				validatedObject = null;
				throw new InvalidOperationException($"{nameof(validatedObject)} should be derived from {typeof(T)}");
			}
		}
	}
}