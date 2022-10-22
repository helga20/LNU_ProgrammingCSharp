using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManager
{
    public class Document : IDocument
    {
        public Document()
        {
            this.Title = String.Empty;
            this.Content = String.Empty;
        }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }


        public string Title {get; set;}


        public string Content {get; set;}

    }
}
