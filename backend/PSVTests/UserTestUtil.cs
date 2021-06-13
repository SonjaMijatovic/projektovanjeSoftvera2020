using System;
using System.Linq;

namespace PSVTests
{
    public class UserTestUtil
    {
        public static string GenerateRandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var chars = Enumerable.Range(0, length)
                .Select(x => pool[new Random().Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }
}