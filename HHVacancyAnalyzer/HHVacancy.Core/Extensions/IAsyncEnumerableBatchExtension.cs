namespace HHVacancy.Core
{
    public static class IAsyncEnumerableBatchExtension
    {
        public static async IAsyncEnumerable<List<T>> Buffer<T>(this IAsyncEnumerable<T> source, int bufferSize)
        {
            if (bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Buffer size must be greater than zero.");
            }

            List<T> buffer = new List<T>(bufferSize);

            await foreach (var item in source)
            {
                buffer.Add(item);
                if (buffer.Count >= bufferSize)
                {
                    yield return buffer;
                    buffer = new List<T>(bufferSize);
                }
            }

            // Возвращаем оставшиеся элементы, если они есть
            if (buffer.Count > 0)
            {
                yield return buffer;
            }
        }
    }
}
