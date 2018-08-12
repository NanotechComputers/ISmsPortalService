namespace SmsPortal.Extensions
{
    public static class StringExtensions
    {
        internal static string ToBase64(this string input)
        {
            var toEncodeAsBytes = System.Text.Encoding.ASCII.GetBytes(input);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}