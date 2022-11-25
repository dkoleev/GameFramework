using UnityEngine;

namespace Avocado.Toolbox.Utils {
    public class TargetFrameRate : MonoBehaviour {
        [SerializeField] int targetFrameRate = 60;

        void Start() {
            SetTargetFrameRate();
        }

        private void SetTargetFrameRate() {
            Application.targetFrameRate = targetFrameRate;
        }
    }
}
