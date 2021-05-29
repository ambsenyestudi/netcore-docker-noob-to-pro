namespace MyBackgroundProcess.Domain.Users
{
    public record UserId
    {
        public static UserId Empty { get; } = new UserId(0);
        public int Value { get; }
        private UserId(int id) => (Value) = (id);

        public static UserId FromInt(int id)
        {
            if (!IsValidId(id))
            {
                return Empty;
            }
            return new UserId(id);
        }

        public static bool IsValidId(int id) =>
            id > 0;
    }
}
