using Levels.Generation;
using SceneLoading;
namespace Levels
{
	[System.Serializable]
	public struct Level
	{
		public Scene LocationScene;
		public PathStructureSo PathStructure;
	}
}