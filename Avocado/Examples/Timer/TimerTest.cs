using UnityEngine;
using Logger = Avocado.Framework.Utilities.Logger;

namespace Avocado.Examples.Timer {
    public class TimerTest : MonoBehaviour {
        void Start() {
            UnityToolbox.Timer.Call(1.5f, () => {
                Logger.Log("call timer");
            });

            UnityToolbox.Timer.Call(3.0f, () => {
                Logger.Log("Second Call");
            });
        }
    }
}