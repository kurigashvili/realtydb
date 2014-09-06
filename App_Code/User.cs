using System;
using System.Collections.Generic;
using System.Web;

namespace Realty{
public class User : BaseSQL
{
    public User()
    {
    }

    public static string PreferedLanguage(int UserId){
        
       return getSingleData("EXEC procPreferredLanguage @0",UserId).Culture;
    }

    public static dynamic getUserProfile(int UserId){
 return getSingleData("EXEC procGetUserProfile @UserId=" + UserId);
}

public static void setUserProfile(string UserName, string FirstName,
string LastName, string PhoneNumber, int LanguageId, int UserId){
execSql("EXEC procUpdateUserProfile "+
"@UserName='" + UserName +"'"+
",@FirstName='" + FirstName +"'"+
",@LastName='" + LastName +"'"+
",@PhoneNumber='" + PhoneNumber +"'"+
",@LanguageId=" + LanguageId +
",@UserId=" + UserId); 
}
}
}