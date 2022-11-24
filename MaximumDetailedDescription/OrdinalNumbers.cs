namespace MaximumDetailedDescription;

public static class OrdinalNumbers
{
    static string GetOrdinalNumberTenth(int n) => n switch
    {
        1 => "первый",
        2 => "второй",
        3 => "третий",
        4 => "четвёртый",
        5 => "пятый",
        6 => "шестой",
        7 => "седьмой",
        8 => "восьмой",
        9 => "девятый",
        _ => throw new ArgumentOutOfRangeException(nameof(n), n, null)
    };

    static string GetOrdinalNumberHundredths(int n) => n switch
    {
        >= 1 and <= 9 => GetOrdinalNumberTenth(n),
        10 => "десятый",
        11 => "одиннадцатый",
        12 => "двенадцатый",
        13 => "тринадцатый",
        14 => "четырнадцатый",
        15 => "пятнадцатый",
        16 => "шестнадцатый",
        17 => "семнадцатый",
        18 => "восемнадцатый",
        19 => "девятнадцатый",
        20 => "двадцатый",
        >= 21 and <= 29 => "двадцать " + GetOrdinalNumberTenth(n % 10),
        30 => "тридцатый",
        >= 31 and <= 39 => "тридцать " + GetOrdinalNumberTenth(n % 10),
        40 => "сороковой",
        >= 41 and <= 49 => "сорок " + GetOrdinalNumberTenth(n % 10),
        50 => "пятидесятый",
        >= 51 and <= 59 => "пятьдесят " + GetOrdinalNumberTenth(n % 10),
        60 => "шестидесятый",
        >= 61 and <= 69 => "шестьдесят " + GetOrdinalNumberTenth(n % 10),
        70 => "семидесятый",
        >= 71 and <= 79 => "семьдесят " + GetOrdinalNumberTenth(n % 10),
        80 => "восьмидесятый",
        >= 81 and <= 89 => "восемьдесят " + GetOrdinalNumberTenth(n % 10),
        90 => "девяностый",
        >= 91 and <= 99 => "девяносто " + GetOrdinalNumberTenth(n % 10),
        _ => throw new ArgumentOutOfRangeException(nameof(n), n, null)
    };

    static string GetOrdinalNumberBasePrefixGenitiveCase(int n) => n switch
    {
        2 => "двух",
        3 => "трёх",
        4 => "четырёх",
        5 => "пяти",
        6 => "шести",
        7 => "семи",
        8 => "восьми",
        9 => "девяти",
        _ => throw new ArgumentOutOfRangeException(nameof(n), n, null)
    };

    public static string GetOrdinalNumber(int n)
    {
        if (n < 0) throw new ArgumentOutOfRangeException(nameof(n), n, "The number cannot be negative");

        int digits = (int)Math.Log10(n) + 1;

        if (n == 0) return "нулевой";
        if (digits == 1) return GetOrdinalNumberTenth(n);
        if (digits == 2) return GetOrdinalNumberHundredths(n);

        List<string> resultParts = new();

        void Handle3(int ln)
        {
            if (ln == 0)
            {
                resultParts.Add("сотый");
                return;
            }

            int remains = n % 100;
            int @base = n / 100;

            if (remains == 0)
            {
                resultParts.Add(@base == 1 ? "сотый" : GetOrdinalNumberBasePrefixGenitiveCase(@base) + "сотый");
            }
            else
            {
                resultParts.Add(
                    @base switch
                    {
                        1 => "сто",
                        2 => "двести",
                        3 => "триста",
                        4 => "четыреста",
                        5 => "пятьсот",
                        6 => "шестьсот",
                        7 => "семьсот",
                        8 => "восемьсот",
                        9 => "девятьсот",
                        _ => throw new ArgumentOutOfRangeException(nameof(n), n, null)
                    }
                );
                resultParts.Add(GetOrdinalNumberHundredths(remains));
            }
        }

        if (digits == 3) Handle3(n);
        else throw new ArgumentOutOfRangeException(nameof(n), n, "Too big number");

        return string.Join(' ', resultParts);
    }
}