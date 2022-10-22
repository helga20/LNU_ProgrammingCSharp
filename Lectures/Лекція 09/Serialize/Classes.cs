using System;
using System.Xml.Serialization;

namespace Serialize
{
    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
        public UserPrefs(string color, int size)
        {
            WindowColor = color;
            FontSize = size;
        }
        public override string ToString()
        {
            return String.Format("UserPrefs: color = {0}, size = {1}", WindowColor, FontSize);
        }
    }
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;
        [NonSerialized]
        public string radioID = "XF-552RR6";
        public override string ToString()
        {
            return String.Format("Radio {0} hasTweeters:{1} hasSubWoofers:{2} count of stations:{3} first of them:{4}",
                radioID, hasTweeters, hasSubWoofers, stationPresets.Length, stationPresets[0]);
        }
    }
    // XmlInclude потрібен для серіалізації поліморфного списку авт
    [Serializable]
    [XmlInclude(typeof(JamesBondCar))]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
        public override string ToString()
        {
            return String.Format("Car isHatchBack:{0} with\n   {1}", isHatchBack, theRadio);
        }
    }
    // Радіо в XML-форматі буде збережено, як піделемент, а поля canFly, canSubmerge - як атрибути
    [Serializable]
    public class JamesBondCar : Car
    {
        [XmlAttribute]
        public bool canFly;
        [XmlAttribute]
        public bool canSubmerge;
        public override string ToString()
        {
            return "JamesBond" + base.ToString() + String.Format("\n   canFly:{0}, canSubmerge:{1}\n", canFly, canSubmerge);
        }
    }
}