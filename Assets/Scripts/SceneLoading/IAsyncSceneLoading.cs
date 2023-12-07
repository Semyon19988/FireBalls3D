using System.Threading.Tasks;
using UnityEngine;

namespace SceneLoading
{
	public interface IAsyncSceneLoading
	{
		Task<AsyncOperation> LoadAsync(Scene scene);
		Task<AsyncOperation> UnloadAsync(Scene scene);
	}
}