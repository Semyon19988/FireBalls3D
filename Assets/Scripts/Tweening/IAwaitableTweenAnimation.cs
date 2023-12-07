using System.Threading.Tasks;
using UnityEngine;

namespace Tweening
{
	public interface IAwaitableTweenAnimation
	{
		Task ApplyTo(Transform transform);
	}
}