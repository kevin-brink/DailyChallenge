namespace Shared
{
    public static class ListExtension
    {
        public static List<T> RemoveCopy<T>(this List<T> input, int index)
        {
            var listCopy = input.ToList();
            listCopy.RemoveAt(index);
            return listCopy;
        }
    }
}