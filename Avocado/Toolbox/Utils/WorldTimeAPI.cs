using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Avocado.Toolbox.Utils {
    public class WorldTimeAPI {
        private const string API_URL = "http://worldtimeapi.org/api/ip";

        struct TimeData {
            public long unixtime;
        }

        public static void GetServerUnixTime(Action<long> onLoaded) {
            var webRequest = UnityWebRequest.Get(API_URL);

            var request = webRequest.SendWebRequest();
            request.completed += operation => {
                if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                    webRequest.result == UnityWebRequest.Result.ProtocolError) {
                    Debug.Log("Error: " + webRequest.error);
                    onLoaded.Invoke(-1);
                } else {
                    TimeData timeData = JsonUtility.FromJson<TimeData>(webRequest.downloadHandler.text);
                    onLoaded.Invoke(timeData.unixtime);
                }
            };
        }
    }
}
