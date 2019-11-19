using System;

namespace DEV_4
{
    public static class StringExtention
    {
        /// <summary>
        /// Extention method for all string objects.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>ID</returns>
        public static string GetId(this string str)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
