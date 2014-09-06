﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.WebPages.Html;
 String City,String State,String ZipCode,String Country,Decimal Price,Int32 Bedrooms,Int32 Bathrooms,
 Int32 LivingArea , Int32 PropertyTypeId ,  Int32 PropertyStatusId , Int32 PostedById ){
 this.StreetNumber=StreetNumber;this.StreetName=StreetName;this.AddressLine2=AddressLine2;this.City=City;
 }
    
}
    
 var rs = getSingleData("SELECT * FROM Property WHERE Id=@0",ProperyId);
 this.Id=rs.Id;
 this.StreetNumber=rs.StreetNumber;this.StreetName=rs.StreetName;

}
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
}
{
return getSingleData("EXEC procInsertProperty "+
   
    "@StreetNumber=@0,@StreetName=@1,@AddressLine2=@2,@City=@3,@State=@4,@ZipCode=@5,@Country=@6"+
",@Price=@7 ,@Bedrooms=@8,@Bathrooms=@9,@LivingArea=@10,@PropertyTypeId=@11,@PropertyStatusId=@12,@PostedById=@13"
  ,StreetNumber,StreetName,AddressLine2,City,State,ZipCode,Country,Price,
  Bedrooms,Bathrooms,LivingArea,PropertyTypeId,PropertyStatusId,PostedById
 );
}

{
execSql("EXEC procUpdateProperty "+
   
    "@StreetNumber=@0,@StreetName=@1,@AddressLine2=@2,@City=@3,@State=@4,@ZipCode=@5,@Country=@6"+
",@Price=@7 ,@Bedrooms=@8,@Bathrooms=@9,@LivingArea=@10,@PropertyTypeId=@11,@PropertyStatusId=@12,@PropertyId=@13"
  ,StreetNumber,StreetName,AddressLine2,City,State,ZipCode,Country,Price,
  Bedrooms,Bathrooms,LivingArea,PropertyTypeId,PropertyStatusId,Id
 );
}
    
    return getSingleData("EXEC procPropertyDetails @Culture='"+lang+"',@PropertyId="+PropertyId);
}

public static IEnumerable<dynamic> getPropertyPictures(int PropertyId){
return getDbIEnumerable("EXEC procPropertyPictures @Propertyid= " + PropertyId);
}
return getDbIEnumerable("EXEC procPriceHistory @Propertyid= " + PropertyId);
}
