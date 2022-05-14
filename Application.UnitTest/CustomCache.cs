using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.UnitTest
{
    class CacheModel<TKey, TValue>
    {
        public TValue Value { get; set; }
        public LinkedListNode<TKey> Node { get; set; }
    }

    class CustomCache<TKey, TValue>
    {
        readonly int _maxLength;
        readonly Dictionary<TKey, CacheModel<TKey, TValue>> _cache;
        readonly LinkedList<TKey> _lru;

        CustomCache(int cacheSize)
        {
            _maxLength = cacheSize;
            _cache = new Dictionary<TKey, CacheModel<TKey, TValue>>();
            _lru = new LinkedList<TKey>();
        }

        void Add(TKey key, TValue value)
        {
            var keyExists = _cache.ContainsKey(key);
            if (keyExists)
            {
                // shift / remove node from LinkedList and dispose the object
                var currentKeyNode = _cache[key].Node;
                if (currentKeyNode.Previous != null)
                {
                    currentKeyNode.Previous.Next = currentKeyNode.Next;
                }
                currentKeyNode.Dispose();
            }
            else
            {
                var isMaxLength = (_cache.Count() > _maxLength);
                if (isMaxLength)
                {
                    _lru.RemoveFirst();
                    _cache.Remove(key);
                }
            }

            var lastNode = _lru.AddLast(key);
            var model = new CacheModel<TKey, TValue>
            {
                Value = value,
                Node = lastNode
            };
            _cache[key] = model;
        }

        TValue Get(TKey key)
        {
            if (_cache.TryGetValue(key, out var model))
            {
                return model.Value;
            }
            return default(TValue);
        }
    }
}
