using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PictureFeed
{
    public class UploadedItem
    {
        public static int intItemId;
        public int intItem_Id { get; private set; }
        public string ItemMessage { get; set; }
        public string ItemPath { get; set; }
        public string Filename { get; set; }
        public static List<UploadedItem> ItemsArray = new List<UploadedItem>();

        public UploadedItem(string ItemMessage, string ItemPath, string Filename)
        {
            intItem_Id = Interlocked.Increment(ref intItemId);
            this.intItem_Id = intItem_Id;
            this.ItemMessage = ItemMessage;
            this.ItemPath = ItemPath;
            this.Filename = Filename;
        }
    }
}