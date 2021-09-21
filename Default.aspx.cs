using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
 

    protected void Page_Load(object sender, EventArgs e)
    {
        
        string Path = HttpContext.Current.Request.PhysicalApplicationPath + "/fotograflar/"; 
        string Pattern = @"*";
       // Response.Write("<p>" + Path + "</p>");
        Response.Write("  FOTOĞRAFLAR KLASÖRÜNE OLUŞTURACAĞINIZ <br />              YENİ HER KLASÖR BURADA GÖRÜNTÜLECEKTİR.<br />              KLASÖR ADLARINDA LÜTFEN BOŞLUK BIRAKMAYINIZ.<br />");
        DirectoryInfo DInfo = new DirectoryInfo(Path);
        DirectoryInfo[] DirectoryL = DInfo.GetDirectories(Pattern, SearchOption.TopDirectoryOnly);
        foreach (DirectoryInfo Directory in DirectoryL)
        {
            Response.Write("<li><a href=resimAc.aspx?yol=" + Directory.Name + ">" + Directory.Name + "</a></li>");
            string SubPath = Directory.FullName;
            List<string> Dr = GetDirectory(SubPath, Pattern);
            foreach (string s in Dr)
            {
                Response.Write("<li>-" + s + "</li>");
            }
        }
        #region eski
        

       // IList<FileInfo> ResimleriYakala = new List<FileInfo>();

        //string[] Uzantilar = { ".jpg", ".gif", ".png", ".jpeg" };
        //string[] ResimKlasor = { "img", "img1", "img2" };
        //for (int x = 0; x < 3; x++)
        //{
        //    FileInfo[] TumResimleriOku = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/fotograflar/" + ResimKlasor[x])).GetFiles();

        //    foreach (FileInfo Resimler in TumResimleriOku)
        //    {
        //        for (int i = 0; i < Uzantilar.Length; i++)
        //        {
        //            if (Uzantilar[i] == Resimler.Extension)
        //            {
        //                ResimleriYakala.Add(Resimler);
        //            }
        //        }
        //    }
        //}
        //DDResimler.DataSource = ResimleriYakala;
        //DDResimler.DataBind();
        #endregion      
    }

    public List<string> GetDirectory(string Path, string Pattern)
    {
        List<string> Files = new List<string>();

        DirectoryInfo DInfo = new DirectoryInfo(Path);

        DirectoryInfo[] DirectoryL = DInfo.GetDirectories(Pattern, SearchOption.TopDirectoryOnly);

        foreach (DirectoryInfo Directory in DirectoryL)
        {
            if (DirectoryL.Length > 0)
            {
                Files.Add(Directory.Name);
            }
        }

        return Files;
    }
  
}