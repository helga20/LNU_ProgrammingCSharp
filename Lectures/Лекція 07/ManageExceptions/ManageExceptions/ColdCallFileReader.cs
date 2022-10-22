using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageExceptions
{
    class ColdCallFileReader: IDisposable
    {
        FileStream fs;
        StreamReader sr;
        uint nPeopleToRing;
        bool isDisposed = false;
        bool isOpen = false;
        public void Open(string fileName)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");
            }
            fs = new FileStream(fileName, FileMode.Open);
            sr = new StreamReader(fs);
            try
            {
                string firstLine = sr.ReadLine();
                nPeopleToRing = uint.Parse(firstLine);
                isOpen = true;
            }
            catch (FormatException ex)
            {
                throw new ColdCallFileFormatException("Перший рядок не мiстить число", ex);
            }
        }
        public void ProcessNextPerson()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");
            }
            if (!isOpen)
            {
                throw new ApplicationException("Спроба звернутися до невідкритого файла");
            }
            try
            {
                string name;
                name = sr.ReadLine();
                if (name == null)
                {
                    throw new ColdCallFileFormatException("Недостатня кiлькiсть iмен");
                }
                if (name[0] == 'B')
                {
                    throw new SalesSpyFoundException(name);
                }
                Console.WriteLine(name);
            }
            catch (SalesSpyFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public uint NPeopleToRing
        {
            get
            {
                if (isDisposed)
                {
                    throw new ObjectDisposedException("peopleToRing");
                }
                if (!isOpen)
                {
                    throw new ApplicationException("Спроба звернутися до невідкритого файла");
                }
                return nPeopleToRing;
            }
        }
        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            isDisposed = true;
            isOpen = false;
            if (fs != null)
            {
                fs.Close();
                fs = null;
            }
        } 
    }
    class SalesSpyFoundException : ApplicationException
    {
        public SalesSpyFoundException(string spyName)
            : base("Виявлено шпiона на iм'я " + spyName) { }
        public SalesSpyFoundException(
        string spyName, Exception innerException)
            : base("Виявлено шпiона на iм'я " + spyName, innerException) { }
    }
    class ColdCallFileFormatException : ApplicationException
    {
        public ColdCallFileFormatException(string message)
            : base(message) { }
        public ColdCallFileFormatException(string message, Exception innerException)
            : base(message, innerException) { }
    } 
}
