using UnityEngine;

namespace Avocado.Toolbox.Utils {
    public class AndroidMemoryInfo
    {
#if UNITY_ANDROID
        const uint kMegabyte = 1048576u;

        private AndroidJavaObject getMemoryInfo() {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject systemService = currentActivity.Call<AndroidJavaObject>("getSystemService", "activity");
            AndroidJavaObject memoryInfo = new AndroidJavaObject("android.app.ActivityManager$MemoryInfo");
            systemService.Call("getMemoryInfo", memoryInfo);

            return memoryInfo;
        }

        public int GetAvailMemory() {
            using (var memInfo = getMemoryInfo()) {
                return (int) (memInfo.Get<long>("availMem") / kMegabyte);
            }
        }

        public int GetTotalMemory() {
            using (var memInfo = getMemoryInfo()) {
                return (int) (memInfo.Get<long>("totalMem") / kMegabyte);
            }
        }
#endif
    }
}
