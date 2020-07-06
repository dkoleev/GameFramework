using Avocado.Framework.Optimization.Pool;
using UnityEngine;

namespace Avocado.Examples.Pool {
    public class Enemy : MonoBehaviour, IPoolable {
        public void Spawn() {
            gameObject.SetActive(true);
            transform.position = new Vector3(Random.Range(-3, 3), 0);
        }

        public void Release() {
            gameObject.SetActive(false);
            transform.position = Vector3.zero;
        }
    }
}