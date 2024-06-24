namespace KTNEManual.Domain._Util
{
    public static class DictionaryExtension
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> source, Dictionary<TKey, TValue> collection) where TKey : notnull
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null");
            }

            foreach (var item in collection)
            {
                source.Add(item.Key, item.Value);
            }
        }
    }
}
