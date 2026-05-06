using System;
using System.Text;

public class SimpleCipher
{
    public SimpleCipher() => Key = GenerateKey();

    public SimpleCipher(string key) => Key = key;

    public string Key { get; init; }

    public string Encode(string plaintext) => Transform(plaintext, true);

    public string Decode(string ciphertext) => Transform(ciphertext, false);

    private string Transform(string text, bool encode)
    {
        var result = new StringBuilder();

        for (var i = 0; i < text.Length; i++)
        {
            var textOffset = text[i] - 'a';
            var keyOffset = Key[i % Key.Length] - 'a';

            var shifted = encode
                ? (textOffset + keyOffset) % 26
                : (textOffset - keyOffset + 26) % 26;

            result.Append((char)(shifted + 'a'));
        }

        return result.ToString();
    }

    private static string GenerateKey(int length = 100)
    {
        var rnd = new Random();
        var key = new StringBuilder();

        for (int i = 0; i < 100; i++)
        {
            key.Append((char)('a' + rnd.Next(26)));
        }

        return key.ToString();
    }
}