using System;
using System.Collections.Generic;
using System.Web;using WebMatrix.Data;
using System.Web.WebPages.Html;using Realty;namespace Realty{public class Property : BaseSQL{#region Instance Properties  public Int32 Id { get; set; }  public String StreetNumber { get; set; }  public String StreetName { get; set; }  public String AddressLine2 { get; set; }  public String City { get; set; }  public String State { get; set; }  public String ZipCode { get; set; }  public String Country { get; set; }  public Decimal Price { get; set; }  public Int32 Bedrooms { get; set; }  public Int32 Bathrooms { get; set; }  public Int32 LivingArea { get; set; }  public Int32 PropertyTypeId { get; set; }  public Int32 PropertyStatusId { get; set; }  public Int32 PostedById { get; set; } // public virtual ICollection<PropertyType> PropertyType { get; set; }#endregion Instance Propertiespublic Property(String StreetNumber,String StreetName,String AdddressLine2,
 String City,String State,String ZipCode,String Country,Decimal Price,Int32 Bedrooms,Int32 Bathrooms,
 Int32 LivingArea , Int32 PropertyTypeId ,  Int32 PropertyStatusId , Int32 PostedById ){
 this.StreetNumber=StreetNumber;this.StreetName=StreetName;this.AddressLine2=AddressLine2;this.City=City; this.State=State;this.ZipCode=ZipCode;this.Country=Country;this.Price=Price;this.Bedrooms=Bedrooms; this.Bathrooms=Bathrooms;this.LivingArea=LivingArea;this.PropertyTypeId=PropertyTypeId;this.PropertyStatusId=PropertyStatusId; this.PostedById=PostedById;   
 }public Property(){
    
}public Property(int ProperyId){
    
 var rs = getSingleData("SELECT * FROM Property WHERE Id=@0",ProperyId);
 this.Id=rs.Id;
 this.StreetNumber=rs.StreetNumber;this.StreetName=rs.StreetName; this.AddressLine2=rs.AddressLine2;this.City=rs.City; this.State=rs.State;this.ZipCode=rs.ZipCode;this.Country=rs.Country; this.Price=rs.Price;this.Bedrooms=rs.Bedrooms; this.Bathrooms=rs.Bathrooms;this.LivingArea=rs.LivingArea; this.PropertyTypeId=rs.PropertyTypeId;this.PropertyStatusId=rs.PropertyStatusId; this.PostedById=rs.PostedById;

} public static List<SelectListItem> BedroomList(){
        return Html.getDropDownList(0,5,1,"+"); 
  }


 public static List<SelectListItem> BathroomList(){
        return Html.getDropDownList(0,5,1,"+");
  }


 public static List<SelectListItem> LivigArea(){
        return Html.getDropDownList(0,10000,250,"+");
 }


 public static List<SelectListItem> BedroomList(int d){
        return Html.getDropDownList(0,5,1,"+",d); 
  }


 public static List<SelectListItem> BathroomList(int d){
        return Html.getDropDownList(0,5,1,"+",d);
  }


 public static List<SelectListItem> LivigArea(int d){
        return Html.getDropDownList(0,10000,250,"+",d);
 }

 public static List<SelectListItem> PropertyType(string culture){
    return getDbList("EXEC procGetPropertyType '" + culture+"'" );
}

public static List<SelectListItem> PropertyStatus(string culture){
    return getDbList("EXEC procGetPropertyStatus '" + culture+"'" );
}


public static List<SelectListItem> PropertyType(string culture,int selectedId=1,bool IncAll=true){
    if(IncAll){
    return getDbList("EXEC procGetPropertyType '" + culture+"'" ,selectedId);
    }else{
     List<SelectListItem> myList=getDbList("EXEC procGetPropertyType '" + culture+"'" ,selectedId);
     myList.RemoveAll(i => i.Value == "0");
     return myList;
    }
}

public static List<SelectListItem> PropertyStatus(string culture,int selectedId=1,bool IncAll=true){
    if(IncAll){
    return getDbList("EXEC procGetPropertyStatus '" + culture+"'" ,selectedId);
    }else{
     List<SelectListItem> myList=getDbList("EXEC procGetPropertyStatus '" + culture+"'" ,selectedId);
     myList.RemoveAll(i => i.Value == "0");
     return myList;
    }
}public dynamic Add()
{
return getSingleData("EXEC procInsertProperty "+
   
    "@StreetNumber=@0,@StreetName=@1,@AddressLine2=@2,@City=@3,@State=@4,@ZipCode=@5,@Country=@6"+
",@Price=@7 ,@Bedrooms=@8,@Bathrooms=@9,@LivingArea=@10,@PropertyTypeId=@11,@PropertyStatusId=@12,@PostedById=@13"
  ,StreetNumber,StreetName,AddressLine2,City,State,ZipCode,Country,Price,
  Bedrooms,Bathrooms,LivingArea,PropertyTypeId,PropertyStatusId,PostedById
 );
}
public void Update()
{
execSql("EXEC procUpdateProperty "+
   
    "@StreetNumber=@0,@StreetName=@1,@AddressLine2=@2,@City=@3,@State=@4,@ZipCode=@5,@Country=@6"+
",@Price=@7 ,@Bedrooms=@8,@Bathrooms=@9,@LivingArea=@10,@PropertyTypeId=@11,@PropertyStatusId=@12,@PropertyId=@13"
  ,StreetNumber,StreetName,AddressLine2,City,State,ZipCode,Country,Price,
  Bedrooms,Bathrooms,LivingArea,PropertyTypeId,PropertyStatusId,Id
 );
}public static dynamic getPropertyDetails(string lang, int PropertyId){
    
    return getSingleData("EXEC procPropertyDetails @Culture='"+lang+"',@PropertyId="+PropertyId);
}

public static IEnumerable<dynamic> getPropertyPictures(int PropertyId){
return getDbIEnumerable("EXEC procPropertyPictures @Propertyid= " + PropertyId);
}public static IEnumerable<dynamic> getPriceHistory(int PropertyId){
return getDbIEnumerable("EXEC procPriceHistory @Propertyid= " + PropertyId);
}}}

