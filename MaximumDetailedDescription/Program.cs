﻿using System.Text;
using MaximumDetailedDescription;

// code here
string code = """
string[] lines = theText.Split(
    new string[] { "\r\n", "\r", "\n" },
    StringSplitOptions.None
);
""";

// string code = File.ReadAllText("somefile.txt");

string GetCodeVeryDetailedDescription(string code)
{
    StringBuilder sb = new();
    
    string[] lines = code.Split(
        new string[] { "\r\n", "\r", "\n" },
        StringSplitOptions.None
    );

    for (var lineNumber = 0; lineNumber < lines.Length; lineNumber++)
    {
        string line = lines[lineNumber];
        int indent = line.TakeWhile(Char.IsWhiteSpace).Count();

        sb.Append($"Строка {lineNumber + 1}: длина - {line.Length}, отступ - {indent}");

        int charIndex = 1;
        foreach (char c in line.SkipWhile(Char.IsWhiteSpace))
        {
            sb.Append($", {OrdinalNumbers.GetOrdinalNumber(charIndex)} символ - \"{c}\"");
            charIndex++;
        }

        sb.AppendLine(".");
    }

    return sb.ToString();
};

string result = GetCodeVeryDetailedDescription(code);

Console.WriteLine(result);
File.WriteAllText("out.txt", result);

// Result
/*
Строка 1: длина - 31, отступ - 0, первый символ - "s", второй символ - "t", третий символ - "r", четвёртый символ - "i", пятый символ - "n", шестой символ - "g", седьмой символ - "[", восьмой символ - "]", девятый символ - " ", десятый символ - "l", одиннадцатый символ - "i", двенадцатый символ - "n", тринадцатый символ - "e", четырнадцатый символ - "s", пятнадцатый символ - " ", шестнадцатый символ - "=", семнадцатый символ - " ", восемнадцатый символ - "t", девятнадцатый символ - "h", двадцатый символ - "e", двадцать первый символ - "T", двадцать второй символ - "e", двадцать третий символ - "x", двадцать четвёртый символ - "t", двадцать пятый символ - ".", двадцать шестой символ - "S", двадцать седьмой символ - "p", двадцать восьмой символ - "l", двадцать девятый символ - "i", тридцатый символ - "t", тридцать первый символ - "(".
Строка 2: длина - 40, отступ - 4, первый символ - "n", второй символ - "e", третий символ - "w", четвёртый символ - " ", пятый символ - "s", шестой символ - "t", седьмой символ - "r", восьмой символ - "i", девятый символ - "n", десятый символ - "g", одиннадцатый символ - "[", двенадцатый символ - "]", тринадцатый символ - " ", четырнадцатый символ - "{", пятнадцатый символ - " ", шестнадцатый символ - """, семнадцатый символ - "\", восемнадцатый символ - "r", девятнадцатый символ - "\", двадцатый символ - "n", двадцать первый символ - """, двадцать второй символ - ",", двадцать третий символ - " ", двадцать четвёртый символ - """, двадцать пятый символ - "\", двадцать шестой символ - "r", двадцать седьмой символ - """, двадцать восьмой символ - ",", двадцать девятый символ - " ", тридцатый символ - """, тридцать первый символ - "\", тридцать второй символ - "n", тридцать третий символ - """, тридцать четвёртый символ - " ", тридцать пятый символ - "}", тридцать шестой символ - ",".
Строка 3: длина - 27, отступ - 4, первый символ - "S", второй символ - "t", третий символ - "r", четвёртый символ - "i", пятый символ - "n", шестой символ - "g", седьмой символ - "S", восьмой символ - "p", девятый символ - "l", десятый символ - "i", одиннадцатый символ - "t", двенадцатый символ - "O", тринадцатый символ - "p", четырнадцатый символ - "t", пятнадцатый символ - "i", шестнадцатый символ - "o", семнадцатый символ - "n", восемнадцатый символ - "s", девятнадцатый символ - ".", двадцатый символ - "N", двадцать первый символ - "o", двадцать второй символ - "n", двадцать третий символ - "e".
Строка 4: длина - 2, отступ - 0, первый символ - ")", второй символ - ";".
*/