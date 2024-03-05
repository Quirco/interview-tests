using System.Collections;

namespace Interview.Tests.Implementations;

public static class Chunker
{
    public static IEnumerable<IEnumerable<T>> SplitByChunks<T>(this IEnumerable<T> source, int chunkSize)
    {
        var enumerator = source.GetEnumerator();
        bool endReached = false;
        while (endReached is false)
        {
            yield return new EnumWrapper<T>(enumerator, chunkSize, () => endReached = true);
        }
    }

    public class EnumWrapper<T> : IEnumerable<T>
    {
        private readonly IEnumerator<T> _source;
        private readonly int _size;
        private readonly Action _onEnd;

        public EnumWrapper(IEnumerator<T> source, int size, Action onEnd)
        {
            _source = source;
            _size = size;
            _onEnd = onEnd;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeratorWrapper<T>(_source, _size, _onEnd);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class EnumeratorWrapper<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _source;
        private readonly int _size;
        private readonly Action _onEnd;

        public EnumeratorWrapper(IEnumerator<T> source, int size, Action onEnd)
        {
            _source = source;
            _size = size;
            _onEnd = onEnd;
        }

        private int _counter;

        public bool MoveNext()
        {
            if (_counter >= _size)
            {
                return false;
            }

            var result = _source.MoveNext();
            if (result is false)
            {
                _onEnd();
                return false;
            }

            _counter++;
            return true;
        }

        public void Reset()
        {
            _source.Reset();
            _counter = 0;
        }

        public T Current => _source.Current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _source.Dispose();
        }
    }
}