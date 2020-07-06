using System;
using Avocado.UnityToolbox.Timer;
using UnityEngine;
using Logger = Avocado.Framework.Utilities.Logger;

namespace Avocado.Examples.Timer {


    public class TimerTest : MonoBehaviour {
        [Serializable]
        public enum TestType {
            Base,
            Repeat
        }

        [SerializeField]
        private TestType _testType;
        
        void Start() {
            switch (_testType) {
                case TestType.Base:
                    TestBase();
                    break;
                case TestType.Repeat:
                    TestRepeat();
                    break;
            }
        }

        private void TestBase() {
            var timer = TimeManager.Call(1.0f, () => {
                Logger.Log("Pause Call");
            });
            timer.Pause();
            
            TimeManager.Call(1.5f, () => {
                Logger.Log("call timer");
            });

            TimeManager.Call(3.0f, () => {
                Logger.Log("Second Call");
                timer.Resume();
            });
            
            TimeManager.PauseAll();
            TimeManager.Call(1.0f, TimeManager.ResumeAll);
        }

        private void TestRepeat() {
            var timer = TimeManager.RepeatCall(0.5f, () => {
                Logger.Log("repeat call");
            });

            TimeManager.Call(4.0f, () => {
                timer.Pause();
                TimeManager.Call(3.0f, () => {
                    timer.Resume();
                    TimeManager.Call(3.0f, timer.Stop);
                });
            });
        }
    }
}