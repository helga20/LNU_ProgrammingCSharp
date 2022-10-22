using System;
namespace DocumentManager
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }
}
