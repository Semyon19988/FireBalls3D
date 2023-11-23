using System.Collections;

namespace Obstacles.Sequence
{
	public interface IMovementSequenceTerm
	{
		IEnumerator GetSequenceTermCoroutine();
	}
}