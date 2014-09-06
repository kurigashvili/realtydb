using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Helpers;
using Microsoft.Web.Helpers;
using System.IO;
namespace Realty{
public class Media : BaseSQL
{
    private const int imageWidth = 550;
    private const int imageHeight = 365;

  
    public static void uploadImage(dynamic uploadedFile,ref String guids){
    var fileSavePath = "";
    BinaryReader b = new BinaryReader(uploadedFile.InputStream);
              byte[] binData = b.ReadBytes(uploadedFile.ContentLength);
              WebImage img= new WebImage(binData);
              var guid=Guid.NewGuid().ToString();
              guids = guids +""+guid+",";
              fileSavePath = System.Web.HttpContext.Current.Server.MapPath("~/images/property/" +
                guid);
              img.Resize(imageWidth,imageHeight,true);  
              img.Save(fileSavePath,"jpg",true);
} 


        public static void uploadImages(string imageGUIDS,int PropertyId){
        execSql("EXEC procUploadImages "+ imageGUIDS+","+PropertyId);
        }
}

}