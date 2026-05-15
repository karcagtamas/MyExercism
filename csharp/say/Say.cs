public static class Say
{
    private static readonly List<string> small = [
        "zero",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "ten",
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen",
    ];
    private static readonly List<string> tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
    private static readonly List<string> scales = ["", "thousand", "million", "billion"];

    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999_999_999_999) throw new ArgumentOutOfRangeException();

        if (number == 0) return "zero";

        var num = number;
        var scaleIndex = 0;
        List<string> parts = [];

        while (num > 0)
        {
            var chunk = (int)(num % 1000);

            if (chunk != 0)
            {
                var chunkText = SayUnder1000(chunk);
                var scale = scales[scaleIndex];

                parts.Add(scale == "" ? chunkText : $"{chunkText} {scale}");
            }

            num /= 1000;
            scaleIndex++;
        }

        parts.Reverse();

        return string.Join(" ", parts);
    }

    private static string SayUnder1000(int num)
    {
        List<string> parts = [];

        var hundreds = num / 100;
        var remainder = num % 100;

        if (hundreds > 0)
        {
            parts.Add($"{small[hundreds]} hundred");
        }

        if (remainder > 0)
        {
            if (remainder < 20)
            {
                parts.Add(small[remainder]);
            }
            else if (remainder % 10 == 0)
            {
                parts.Add(tens[remainder / 10]);
            }
            else
            {
                parts.Add($"{tens[remainder / 10]}-{small[remainder % 10]}");
            }
        }

        return string.Join(" ", parts);
    }
}