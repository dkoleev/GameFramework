using System.Collections;
using System.Collections.Generic;
using Avocado.Framework.Optimization;
using Avocado.Framework.Optimization.Pool;
using UnityEngine;

namespace Avocado.Framework.Examples.Pool {
    public class TestPool : MonoBehaviour {
        [SerializeField]private Enemy _enemyPrefab;
        [SerializeField]
        private int _startPoolSize = 10;
        [SerializeField]
        private float _spawnDelay = 2.0f;
        [SerializeField]
        private float _releaseDelay = 10.0f;
        [SerializeField]
        private float _optimizeAfter = 10.0f;
        [SerializeField]
        private float _clearAfter = 15.0f;

        [SerializeField]
        private bool _useFirstPool;
        
        private Pool<Enemy> _enemyPool;
        private Pool<Enemy> _enemyPool2;

        private Pool<Enemy> _currentPool;
        private List<Enemy> _enemies = new List<Enemy>();
        private bool _currentPoolBufferState = false;

        private Coroutine _spawnCor;
        private Coroutine _destoryCor;
        
        private void Start() {
            _currentPoolBufferState = _useFirstPool;
                
            _enemyPool = new Pool<Enemy>(_enemyPrefab, _startPoolSize, transform);
            _enemyPool2 = new Pool<Enemy>(_enemyPrefab, _startPoolSize);

            _currentPool = _useFirstPool ? _enemyPool : _enemyPool2;

            _spawnCor =  StartCoroutine(SpawnEnemy());
            _destoryCor = StartCoroutine(DestroyEnemy());
            StartCoroutine(Optimize());
            StartCoroutine(Clear());
        }

        private void Update() {
            if (_currentPoolBufferState != _useFirstPool) {
                _currentPoolBufferState = _useFirstPool;
                _currentPool = _useFirstPool ? _enemyPool : _enemyPool2;
            }
        }

        private IEnumerator SpawnEnemy() {
            while (true) {
                yield return new WaitForSeconds(_spawnDelay);

                var enemy = _currentPool.Get();
                _enemies.Add(enemy);
            }
        }

        private IEnumerator DestroyEnemy() {
            while (true) {
                yield return new WaitForSeconds(_releaseDelay);
                foreach (var enemy in _enemies) {
                    _enemyPool.Release(enemy);
                }
                
                _enemies.Clear();
            }
        }

        private IEnumerator Optimize() {
            yield return new WaitForSeconds(_optimizeAfter);
            StopCoroutine(_spawnCor);
            StopCoroutine(_destoryCor);
            _currentPool.Optimize();
        }
        
        private IEnumerator Clear() {
            yield return new WaitForSeconds(_clearAfter);
            StopCoroutine(_spawnCor);
            StopCoroutine(_destoryCor);
            _currentPool.Clear();
        }
    }
}
