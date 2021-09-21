using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class resimAc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        IList<FileInfo> ResimleriYakala = new List<FileInfo>();

        string[] Uzantilar = { ".jpg", ".gif", ".png", ".jpeg", ".JPG", ".GIF", ".PNG", ".JPEG" };
        string[] ResimKlasor = { "img", "img1", "img2" };
      
            FileInfo[] TumResimleriOku = new DirectoryInfo(HttpContext.Current.Server.MapPath("fotograflar/" + Request.QueryString["yol"])).GetFiles();

            foreach (FileInfo Resimler in TumResimleriOku)
            {
                for (int i = 0; i < Uzantilar.Length; i++)
                {
                    if (Uzantilar[i] == Resimler.Extension)
                    {
                        ResimleriYakala.Add(Resimler);
                    }
                }
            }

            DDResimler.DataSource = ResimleriYakala;
            DDResimler.DataBind();

    }
}