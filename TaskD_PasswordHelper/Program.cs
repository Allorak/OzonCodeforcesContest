using System;
using System.Collections.Generic;
using System.Linq;

var passwordAmount = int.Parse(Console.ReadLine());
const string vowels = "aeouyi";
const string uppercaseVowels = "AEOUIY";
const string consonants = "qwrtpsdfghjklzxcvbnm";
const string uppercaseConsonants = "QWRTPSDFGHJKLZXCVBNM";
for (var i = 0; i < passwordAmount; i++)
{
    var password = Console.ReadLine();
    var hasUpperCase = false;
    var hasLowerCase = false;
    var hasVowel = false;
    var hasConsonant = false;
    var hasNumber = false;

    foreach (var letter in password)
    {
        switch (letter)
        {
            case >= 'a' and <= 'z':
                hasLowerCase = true;
                break;
            case >= 'A' and <= 'Z':
                hasUpperCase = true;
                break;
            case >= '0' and <= '9':
                hasNumber = true;
                break;
        }

        if (vowels.Contains(letter) || uppercaseVowels.Contains(letter))
            hasVowel = true;
        else if (consonants.Contains(letter) || uppercaseConsonants.Contains(letter))
            hasConsonant = true;
    }

    if (!hasNumber)
        password += '0';
    if (!hasVowel && !hasConsonant)
    {
        password += "aB";
    }
    else if (!hasVowel)
    {
        if (!hasLowerCase)
            password += 'a';
        else
            password += 'A';
    }
    else if (!hasConsonant)
    {
        if (!hasLowerCase)
            password += 'b';
        else
            password += 'B';
    }
    else if(!hasLowerCase)
    {
        password += 'a';
    }
    else if (!hasUpperCase)
    {
        password += 'A';
    }

    Console.WriteLine(password);
}