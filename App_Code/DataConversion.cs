using System;
using System.Collections.Generic;
using System.Web;
using System.Linq.Expressions;
using WebMatrix.Data;
using System.Web.WebPages.Html;

namespace Realty{
public class DataConversion
{

public static int tryCastInt(int myVar, string requestString){
int result;
return (Int32.TryParse(HttpContext.Current.Request[requestString],out result)) ? result : myVar;
}
public static double tryCastDouble(double myVar, string requestString){
double result;
return (Double.TryParse(HttpContext.Current.Request[requestString],out result)) ? result : myVar;
}

public static decimal tryCastDecimal(decimal myVar, string requestString){
decimal result;
return (Decimal.TryParse(HttpContext.Current.Request[requestString],out result)) ? result : myVar;
}

public static string getNumericOnly(string oldString){
return System.Text.RegularExpressions.Regex.Replace(oldString, "[^.0-9]", "");    

}
 
}
}