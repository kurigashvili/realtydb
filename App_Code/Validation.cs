﻿using System;
using System.Collections.Generic;
using System.Web;

namespace Realty{
public class Validation
{
    
public static bool IsEqualTo<T>(T value, T comparator) where T : IComparable
{
return value.Equals(comparator);
}
public static bool IsGreaterThan<T>(T value, T comparator) where T : IComparable
{
return value.CompareTo(comparator) > 0;
}
public static bool IsLessThan<T>(T value, T comparator) where T : IComparable
{
return value.CompareTo(comparator) < 0;
}
public static bool IsGreaterThanOrEqualTo<T>(T value, T comparator) where T : IComparable
{
return value.CompareTo(comparator) >= 0;
}
public static bool IsLessThanOrEqualTo<T>(T value, T comparator) where T : IComparable
{
return value.CompareTo(comparator) <= 0;
}
/* Range Validation */
public static bool IsBetween<T>(T value, T minValue, T maxValue) where T : IComparable
{
return (value.CompareTo(minValue) >= 0 && value.CompareTo(maxValue) <= 0);
}
/* Pattern Matching */
public static bool IsNumbersOnly(string value)
{
string expression = @"^[0-9]+$";
return System.Text.RegularExpressions.Regex.IsMatch(value, expression);
}
public static bool IsLettersOnly(string value)
{
string expression = @"^[A-Za-z]+$";
return System.Text.RegularExpressions.Regex.IsMatch(value, expression);
}
public static bool IsAlphaNumeric(string value)
{
string expression = @"^[A-Za-z0-9]+$";
return System.Text.RegularExpressions.Regex.IsMatch(value, expression);
}
public static bool IsValidEmail(string value)
{
string expression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
return System.Text.RegularExpressions.Regex.IsMatch(value, expression);
}


}
}