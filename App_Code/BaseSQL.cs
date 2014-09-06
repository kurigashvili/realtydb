using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
using System.Web.WebPages.Html;

public  abstract class BaseSQL
{
    private static  string dbname="DB_9B16E6_realty";

    public static dynamic getSingleData(string sql,params Object[] args){
        var db = Database.Open(dbname);
        var result = db.QuerySingle(sql,args);
        return result;
    }

    public static int getLastId(){
        var db = Database.Open(dbname);
        return db.GetLastInsertId();
    }

    public static void execSql(string sql,params Object[] args){  
        var db = Database.Open(dbname);
        db.Execute(sql,args);
    }

    public static IEnumerable<dynamic> getDbIEnumerable(string sql,params Object[] args){
        var db = Database.Open(dbname);
        var result = db.Query(sql,args);
        return result;
    }

    public static List<SelectListItem> getDbList(string query,
    int selectedId=1){
    var result = getDbIEnumerable(query);
    List<SelectListItem> myList=new List<SelectListItem>(); 

    bool isSelected = false;
    foreach(var item in result)
    {
    if(item.Id==selectedId) {isSelected=true;} else {isSelected=false;}
    myList.Add(new SelectListItem 
    {Value = item[0].ToString(), Text = item[1].ToString(), Selected=isSelected});
    }
        return myList;
    }

    public static List<SelectListItem> getDbList(string query,string defaultValue)
    {

    var result = getDbIEnumerable(query);
    List<SelectListItem> myList=new List<SelectListItem>(); 
    myList.Add (new SelectListItem 
        { Value = "-1" ,Text = defaultValue });
    foreach(var item in result){
    myList.Add(new SelectListItem 
    {Value = item[0].ToString(), Text = item[1].ToString()});
    }
    return myList;
    }
}



