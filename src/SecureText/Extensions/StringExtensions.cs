namespace SecureText;

/// <summary>
/// The string extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Compares two strings, ignoring case.
    /// </summary>
    /// <param name="left">The first string.</param>
    /// <param name="right">The second string.</param>
    /// <returns><c>true</c> if the strings are equal, ignoring case; otherwise, <c>false</c>.</returns>
    public static bool EqualsIgnoreCase(this string? left, object? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return string.Equals(left, right.ToString(), StringComparison.OrdinalIgnoreCase);
    }
}