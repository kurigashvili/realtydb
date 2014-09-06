using System;
using System.Collections.Generic;
using System.Web;

public class Search : BaseSQL
{   public String route {get; set;}
    public String locality {get; set;} 
    public String administrative_area_level_1 {get; set;}
    public String postal_code {get; set;}
    public Int32 bedroom {get; set;}
    public Int32 bathroom {get; set;}
    public Int32 livingarea {get; set;}
    public Double minprice {get; set;}
    public Double maxprice {get; set;}
    public Int32 propertytype {get; set;}
    public Int32 propertystatus {get; set;}

    public Search(
    String route,String locality,String administrative_area_level_1,
    String postal_code,Int32 bedroom,Int32 bathroom,Int32 livingarea,
    Double minprice,Double maxprice,Int32 propertytype,Int32 propertystatus
    )
    {
       this.route=route;
       this.locality=locality;
       this.administrative_area_level_1=administrative_area_level_1;
       this.postal_code=postal_code;
       this.bedroom=bedroom;
       this.bathroom=bathroom;
       this.livingarea=livingarea;
       this.minprice=minprice;
       this.maxprice=maxprice;
       this.propertytype=propertytype;
       this.propertystatus=propertystatus;
    }

    public Search()
    {
       route="";
       locality="";
       administrative_area_level_1="";
       postal_code="";
       bedroom=0;
       bathroom=0;
       livingarea=0;
       minprice=0.0;
       maxprice=10000000.0;
       propertytype=0;
       propertystatus=0;
    }


  

    public Search(
    dynamic route, dynamic locality, dynamic administrative_area_level_1,
    dynamic postal_code,dynamic bedroom,dynamic bathroom,dynamic livingarea,
    dynamic minprice, dynamic maxprice,dynamic propertytype,dynamic propertystatus
    
    
    )
    {
       this.route=route;
       this.locality=locality;
       this.administrative_area_level_1=administrative_area_level_1;
       this.postal_code=postal_code;
       this.bedroom=bedroom;
       this.bathroom=bathroom;
       this.livingarea=livingarea;
       this.minprice=minprice;
       this.maxprice=maxprice;
       this.propertytype=propertytype;
       this.propertystatus=propertystatus;
    }

    
    public dynamic getSearchResults(string Culture)
    {
    return getDbIEnumerable("EXEC procSearchResult "
    + "@Culture=@0,@StreetName=@1,@City=@2,@State=@3,@ZipCode=@4,"
    +"@Bedrooms=@5,@Bathrooms=@6,@LivingArea=@7,@minPrice=@8,@maxPrice=@9,"
    +"@PropertyTypeId=@10,@PropertyStatusId=@11",
    Culture,route,locality,administrative_area_level_1,postal_code,
    bedroom,bathroom,livingarea,minprice,maxprice,
    propertytype,propertystatus);
}

   public dynamic getSearchResults(string Culture,string Query)
{
return getDbIEnumerable("EXEC procQuickSearchResult "+
"@Culture='" + Culture + "'"+
",@Query=N'" + Query + "'"
);
}


public static dynamic getUserProperty(
string Culture,
int UserId
)
{
return getDbIEnumerable("EXEC procSearchUserProperty "+
"@Culture='" + Culture + "'"+
",@UserId='" + UserId + "'"
);
}
}
