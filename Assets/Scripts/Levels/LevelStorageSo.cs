using System;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
	[CreateAssetMenu(fileName = "LevelStorage", menuName = "ScriptableObjects/Levels/LevelStorage")]
	public class LevelStorageSo : ScriptableObject
	{
		[SerializeField] private Level[] _levels = Array.Empty<Level>();

		public IReadOnlyList<Level> Levels => _levels;
	}
}