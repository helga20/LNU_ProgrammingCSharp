using System;
using System.Collections.Generic;

namespace DocumentManager
{
    public class DocumentManager<TDocument> : IDocumentManager<TDocument>
        where TDocument: IDocument
    {
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();

        public void AddDocument(TDocument doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);

            lock (this)
            {
                doc = documentQueue.Dequeue();
            }

            return doc;
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }

        public void DisplayAllDocuments()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }
    }
}
