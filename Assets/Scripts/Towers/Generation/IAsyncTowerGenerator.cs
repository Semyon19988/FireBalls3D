using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Towers.Generation
{
    public interface IAsyncTowerGenerator
    {
	    Task<Tower> CreateAsync(Transform tower);
    }
}
