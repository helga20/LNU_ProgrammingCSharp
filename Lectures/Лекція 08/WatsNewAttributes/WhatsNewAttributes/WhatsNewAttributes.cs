using System;

namespace Wrox.ProCSharp.WhatsNewAttributes
{
// клас атрибутів, якими можна позначати класи та методи з метою документування змін
// екземпляри зберігають:
//      - дату модифікації
//      - стислий опис зроблених змін
//      - [необов'язковий параметр] наслідки зроблених змін

    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true, Inherited = false)]
    public class LastModifiedAttribute : Attribute
    {
        private readonly DateTime dateModified;
        private readonly string changes;
        private string issues;

        public LastModifiedAttribute(string dateModified, string changes)
        {
            this.dateModified = DateTime.Parse(dateModified);
            this.changes = changes;
        }

        public DateTime DateModified
        {
            get { return dateModified; }
        }

        public string Changes
        {
            get { return changes; }
        }

        public string Issues
        {
            get { return issues; }
            set { issues = value; }
        }
    }

// атрибути цього класу використовують для позначення тих збірок,
// у яких є атрибути класу LastModifiedAttribyte

    [AttributeUsage(AttributeTargets.Assembly)]
    public class SupportsWhatsNewAttribute : Attribute
    {
    }
}