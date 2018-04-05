using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Collections.Generic;


namespace PictureFeed
{
    public partial class Default : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
            protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;

            private void Page_Load(object sender, System.EventArgs e)
            {
                int i = 0;
                if (i < 1)
                {
                    LoadItemsinFolder();
                    i++;
                }
            }

            #region Web Form Designer generated code
            override protected void OnInit(EventArgs e)
            {
                InitializeComponent();
                base.OnInit(e);
            }

            private void InitializeComponent()
            {
                this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
                this.Load += new System.EventHandler(this.Page_Load);

            }
            #endregion

            private void Submit1_ServerClick(object sender, System.EventArgs e)
            {
                //brUploadItem.Visible = false;
                headUploadItem.Visible = false;
                if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string thisdate = System.DateTime.Today.ToString();
                    string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/UploadedFiles/"));
                    string SaveLocation = Server.MapPath("~/UploadedFiles/") + (filesindirectory.Count() + 1) + Path.GetExtension(fn);
                    string MsgSaveLocation = Server.MapPath("~/Messages/") + (filesindirectory.Count() + 1)
                        + "_Msg.txt";
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                        UploadedItem thisItem = new UploadedItem(TextBox1.Text, SaveLocation, Path.GetFileName(fn));
                        UploadedItem.ItemsArray.Add(thisItem);
                        if (!File.Exists(MsgSaveLocation))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(MsgSaveLocation))
                            {
                                //TextWriter tr = sw;
                                //int numberOfDataLines = Convert.ToInt32(tr.());
                                //File.WriteAllLines(MsgSaveLocation, TextBox1.Text);
                                string s = TextBox1.Text.Replace(Environment.NewLine, @" <br> ");
                                sw.WriteLine(s);
                            }
                        }
                        StreamReader sr = File.OpenText(MsgSaveLocation);
                        //Response.Write("Message: " + filesindirectory.Count());
                        //Response.Write("Location: " + UploadedItem.ItemsArray.Count());
                        //Response.Write(Path.GetFileNameWithoutExtension(fn));
                        //Response.Write("The file has been uploaded.");
                        Response.Redirect("ImageFeed.aspx", false);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);

                    }

                    //Response.Write("~\\UploadedFiles\\" + Path.GetExtension(fn));
                    //File.Move("~\\UploadedFiles\\" + Path.GetExtension(fn),
                    //    "~\\UploadedFiles\\" + 1);
                }
                else
                {
                    //Response.Write("Please select a file to upload.");
                    //brUploadItem.Visible = true;
                    headerMess.InnerText = "Please select file to Upload!";
                    headUploadItem.Visible = true;
                }
                if (TextBox1.Text == "")
                {
                    headerMess.InnerText = "Please enter a message.";
                    headUploadItem.Visible = true;
                }
            }

            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                Response.Redirect("ImageFeed.aspx", false);
            }

            private void LoadItemsinFolder()
            {
                //brUploadItem.Visible = false;
                headUploadItem.Visible = false;
                string[] filesindirectory = Directory.GetFiles(Server.MapPath("~/UploadedFiles/"));
                List<UploadedItem> thisList = new List<UploadedItem>(filesindirectory.Count());
                foreach (string item in filesindirectory)
                {
                    thisList.Add(new UploadedItem(("~/Messages/" +
                        System.IO.Path.GetFileNameWithoutExtension(item) + "_Msg.txt"),
                        System.IO.Path.GetFullPath(item), System.IO.Path.GetFileName(item)));
                    //Response.Write(UploadedItem.ItemsArray.Count().ToString() + "\n");
                    //Response.Write((Server.MapPath("~/Messages/") +
                    //    System.IO.Path.GetFileNameWithoutExtension(item) + "_Msg.txt"));
                    //Response.Write(System.IO.Path.GetFileName(item) + "<br>");
                }
                foreach (UploadedItem thisItem in thisList)
                {
                    UploadedItem.ItemsArray.Add(thisItem);
                }
            }
        }
    }