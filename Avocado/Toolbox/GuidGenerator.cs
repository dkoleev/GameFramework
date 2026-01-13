namespace Avocado.Toolbox {
    public static class GuidGenerator {
        public static string GenerateGuid() {
            return System.Guid.NewGuid().ToString("N");
        }
    }
}
