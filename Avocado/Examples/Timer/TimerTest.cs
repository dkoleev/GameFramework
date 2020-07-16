using System;
using Avocado.UnityToolbox.Timer;
using UnityEngine;
using Logger = Avocado.UnityToolbox.Logger;

namespace Avocado.Examples.Timer {


    public class TimerTest : MonoBehaviour {
        [Serializable]
        public enum TestType {
            Base,
            Repeat,
            Logged
        }

        [SerializeField]
        private TestType _testType;

        private ITimeManager _timeManager;
        
        void Start() {
            _timeManager = new TimeManager();
            
            switch (_testType) {
                case TestType.Base:
                    TestBase();
                    break;
                case TestType.Repeat:
                    TestRepeat();
                    break;
                case TestType.Logged:
                    _timeManager = new TimeManagerLogWrapper(new TimeManager());
                    TestBase();
                    break;
            }
        }

        private void TestBase() {
            var timer = _timeManager.Call(1.0f, () => {
                Logger.Log("Pause Call");
            });
            timer.Pause();
            
            _timeManager.Call(1.5f, () => {
                Logger.Log("call timer");
            });

            _timeManager.Call(3.0f, () => {
                Logger.Log("Second Call");
                timer.Resume();
            });
            
            _timeManager.PauseAll();
            _timeManager.Call(1.0f, _timeManager.ResumeAll);
        }

        private void TestRepeat() {
            var timer = _timeManager.RepeatCall(0.5f, () => {
                Logger.Log("repeat call");
            });

            _timeManager.Call(4.0f, () => {
                timer.Pause();
                _timeManager.Call(3.0f, () => {
                    timer.Resume();
                    _timeManager.Call(3.0f, timer.Stop);
                });
            });
        }
    }
}