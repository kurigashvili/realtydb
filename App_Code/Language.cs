using System;
using System.Collections.Generic;
using System.Web;
using WebMatrix.Data;
using System.Web.WebPages.Html;

namespace Realty{
public class Language : BaseSQL
{
    

    public static List<SelectListItem> LanguageList(int selectedId=1){
    return getDbList("SELECT Id, NativeName from Language;",selectedId);

}

public static List<SelectListItem> getLanguage(int selectedId){
return getDbList("EXEC procGetLanguage",selectedId);
}

public static List<SelectListItem> getLanguage(){
return getDbList("EXEC procGetLanguage",1);
}
    

}
}