﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GopherServer.Core.Models;

namespace GopherServer.Core.Results
{
    public class DirectoryResult : BaseResult
    {
        public List<DirectoryItem> Items { get; internal set; }

        public DirectoryResult()
        {
            this.ItemType = ItemType.DIRECTORY;
            this.Items = new List<DirectoryItem>();
        }

        public DirectoryResult(List<DirectoryItem> list)
        {
            this.Items = list;
            this.ItemType = ItemType.DIRECTORY;
        }

        public override void WriteResult(Stream stream)
        {
            var itemsString = this.ToString();
            using (var streamWriter = new StreamWriter(stream, Encoding.ASCII))
            {
                streamWriter.Write(itemsString);
                // Period on a line by itself
                streamWriter.WriteLine(".");
                // Server should close connection after this point.
            }
            itemsString = null;
        }


        /// <summary>
        /// Returns a the directory listing as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Join("\r\n", this.Items.Select(i => i.ToString()));
    }
}
