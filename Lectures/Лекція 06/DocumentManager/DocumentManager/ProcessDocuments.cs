using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DocumentManager
{
    public class ProcessDocuments<TDocument, TDocumentManager>
        where TDocument : IDocument
        where TDocumentManager : IDocumentManager<TDocument>
    {
        // DocumentManager<TDocument> documentManager;
        TDocumentManager documentManager;

        // public static void Start(DocumentManager<TDocument> dm)
        public static void Start(TDocumentManager dm)
        {
            new Thread(
                new ProcessDocuments<TDocument, TDocumentManager>(dm).Run).Start();
        }
//        protected ProcessDocuments(DocumentManager<TDocument> dm)
        protected ProcessDocuments(TDocumentManager dm)
        {
            documentManager = dm;
        }

        protected void Run()
        {
            while (documentManager.IsDocumentAvailable)
            {
                TDocument doc = documentManager.GetDocument();
                Console.WriteLine("Processing document {0} : \n   {1}", doc.Title, doc.Content);
                Thread.Sleep(new Random().Next(300));
            }
        }
    }
}
