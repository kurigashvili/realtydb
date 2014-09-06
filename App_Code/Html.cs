using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
using System.Web.WebPages.Html;


namespace Realty{
public class Html
{
  
    public static List<SelectListItem> getDropDownList(int min, int max, int increment, string text, int selectedId=0){
    List<SelectListItem> myList=new List<SelectListItem>();  
     bool isSelected = false;
    for (int i=min;i<=max;i=i+increment){
     if(i==selectedId) {isSelected=true;} else {isSelected=false;}  
    myList.Add(new SelectListItem 
     { Value = i.ToString(), Text = i.ToString() + " " + text, Selected=isSelected });

    }
    return myList;
    }

    public static string PhoneNumber(string phone){
    if(phone.Length==10)
    return phone.Substring(0,3)+"-"+ phone.Substring(3,3) + "-"+phone.Substring(6);
    else
    return phone;
    }
   public static IHtmlString ConfirmationMessage(string confirmMessage,
   string linkMessage, int PropertyId){

   return new HtmlString(
   "<div><table ><tr><td>" +
   confirmMessage +
   "</td></tr><tr><td><a href='../Search/PropertyDetails?PropertyId="+
   PropertyId+
   "')>" +

   linkMessage +

   "</a></td></tr></table></div>");
   }


    public static IHtmlString ConfirmationMessage(string confirmMessage){

   return new HtmlString(
   "<div><table ><tr><td>" +
   confirmMessage +
   "</td></tr></table></div>");
   }

   public static String Currency(dynamic price){
       
       return price.ToString("C0",System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
       
   }
}
}
