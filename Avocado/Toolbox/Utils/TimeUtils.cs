using System;

namespace Avocado.Toolbox.Utils {
    public static class TimeUtils {
        public static long CurrentUnixTime => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - _serverUnixTimeOffset;
        private static long _serverUnixTimeOffset = 0;

        public static DateTimeOffset ToDateTimeOffsetFromUnixTimeMilliseconds(this long unixTime) {
            return unixTime == -1
                ? DateTimeOffset.FromUnixTimeMilliseconds(CurrentUnixTime)
                : DateTimeOffset.FromUnixTimeMilliseconds(unixTime - _serverUnixTimeOffset);
        }

        public static DateTimeOffset ToDateTimeOffsetFromUnixTimeSeconds(this long unixTime) {
            return unixTime == -1
                ? DateTimeOffset.FromUnixTimeSeconds(CurrentUnixTime)
                : DateTimeOffset.FromUnixTimeSeconds(unixTime - _serverUnixTimeOffset);
        }

        public static void SetUnixTimeOffset(long serverUnixTimeMilliseconds) {
            _serverUnixTimeOffset = CurrentUnixTime - serverUnixTimeMilliseconds;
        }

        public static TimeSpan GetTimePassed(long unixTimeInSeconds) {
            return CurrentUnixTime.ToDateTimeOffsetFromUnixTimeMilliseconds() -
                   unixTimeInSeconds.ToDateTimeOffsetFromUnixTimeMilliseconds();
        }

        public static TimeSpan GetTimePassed(long startTime, long pausedTime) {
            return pausedTime.ToDateTimeOffsetFromUnixTimeMilliseconds() -
                   startTime.ToDateTimeOffsetFromUnixTimeMilliseconds();
        }
    }
}
