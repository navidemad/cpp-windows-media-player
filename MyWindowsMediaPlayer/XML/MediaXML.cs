using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.XML
{
    class MediaXML
    {
        System.Xml.Linq.XElement xelement;

        public void Load(String filename)
        {
            try
            {
                xelement = System.Xml.Linq.XElement.Load(filename);
            }
            catch (Exception)
            {
                xelement =  new System.Xml.Linq.XElement("Medias");
            }
        }

        public bool HasMedia(String path)
        {
            try
            {
                var medias = from media in xelement.Elements() where (string)media.Element("Path").Value == path select media;

                foreach (var media in medias)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Tuple<String, Boolean>> GetMedias()
        {
            IEnumerable<System.Xml.Linq.XElement> medias = xelement.Elements();
            List<Tuple<String, Boolean>> mediasList = new List<Tuple<String, Boolean>>();

            try
            {
                foreach (var media in medias)
                    mediasList.Add(new Tuple<String, Boolean>(media.Element("Path").Value, Boolean.Parse(media.Element("Stream").Value)));
            }
            catch { }
            
            return mediasList;
        }

        public void Add(String filename, Boolean stream)
        {
            try
            {
                xelement.Add(new System.Xml.Linq.XElement("Media", new System.Xml.Linq.XElement("Path", filename), new System.Xml.Linq.XElement("Stream", stream)));
            }
            catch { }
        }

        public void Remove(String filename)
        {
            try
            {
                var medias = from media in xelement.Elements() where (string)media.Element("Path").Value == filename select media;

                foreach (var media in medias)
                    media.Remove();
            }
            catch { }
        }

        public void WriteInFile(String filename)
        {
            try
            {
                System.Xml.Linq.XDocument xDoc = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "UTF-16", null), xelement);

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Xml.XmlWriter xWrite = System.Xml.XmlWriter.Create(sw);
                xDoc.Save(xWrite);
                xWrite.Close();
                xDoc.Save(filename);
            }
            catch { }
        }

    }
}
