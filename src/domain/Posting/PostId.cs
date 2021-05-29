namespace MyBackgroundProcess.Domain.Posting
{
    public record PostId
    {
        public static PostId Empty { get; } = new PostId(0);
        public int Value { get; }
        private PostId(int id) => (Value) = (id);

        public static PostId FromInt(int id)
        {
            if (!IsValidId(id))
            {
                return Empty;
            }
            return new PostId(id);
        }

        public static bool IsValidId(int id) =>
            id > 0;
    }
}
