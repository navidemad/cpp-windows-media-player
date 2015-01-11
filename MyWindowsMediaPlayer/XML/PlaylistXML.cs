using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.XML
{
    class PlaylistXML
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
                xelement = new System.Xml.Linq.XElement("Playlists");
            }
        }

        public bool HasMedia(String playlistName, Model.Media media)
        {
            try
            {
                if (string.IsNullOrEmpty(playlistName) || media == null || string.IsNullOrEmpty(media.Path))
                    return false;
                if (xelement.Elements("Playlist").Any(row => (row != null && row.Attribute("name") != null && 

                         row.Element("Element") != null && 
                         row.Element("Element").Element("Path") != null &&
                         row.Element("Element").Element("Element") != null &&
                         row.Element("Element").Element("Type") != null &&

                         row.Attribute("name").Value == playlistName && 
                         row.Element("Element").Element("Path").Value == media.Path &&
                         Boolean.Parse(row.Element("Element").Element("Stream").Value) == media.Stream &&

                         (Model.Media.MediaType)Enum.Parse(typeof(Model.Media.MediaType), row.Element("Element").Element("Type").Value) == media.Type
                    )))
                    return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("FAILED HasMedia catch: '{0}'", e);
                return false;
            }
        }

        public bool HasPlaylist(String playlistName)
        {
            try
            {
                IEnumerable<System.Xml.Linq.XElement> playlists = xelement.Elements("Playlist");
                foreach (var playlist in playlists)
                    if (playlist.Attribute("name") != null && playlist.Attribute("name").Value == playlistName)
                        return true;
                return false;
            }
            catch
            {
                Console.WriteLine("FAILED HasPlaylist catch");
                return false;
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<Model.Playlist> GetPlaylists()
        {
            System.Collections.ObjectModel.ObservableCollection<Model.Playlist> playlistsCollection = new System.Collections.ObjectModel.ObservableCollection<Model.Playlist>();

            try
            {
                IEnumerable<System.Xml.Linq.XElement> playlists = xelement.Elements("Playlist");
                foreach (var playlist in playlists)
                {
                    System.Collections.ObjectModel.ObservableCollection<Model.Media> medias = new System.Collections.ObjectModel.ObservableCollection<Model.Media>();
                    IEnumerable<System.Xml.Linq.XElement> elements = playlist.Elements("Element");
                    foreach (var elem in elements)
                    {
                        if ( elem != null && 
                             elem.Element("Path") != null &&
                             elem.Element("Stream") != null &&
                             elem.Element("Type") != null)
                        {
                            Model.Media media = new Model.Media(elem.Element("Path").Value, Boolean.Parse(elem.Element("Stream").Value));
                            media.Type = (Model.Media.MediaType)Enum.Parse(typeof(Model.Media.MediaType), elem.Element("Type").Value);
                            medias.Add(media);
                        }
                    }
                    playlistsCollection.Add(new Model.Playlist()
                    {
                        Name = playlist.Attribute("name").Value,
                        Medias = medias
                    });
                }
            }
            catch { Console.WriteLine("FAILED GetPlaylists catch"); }

            return playlistsCollection;
        }

        public void AddPlaylist(String playlistName)
        {
            try
            {
                System.Xml.Linq.XElement newTag =
                    new System.Xml.Linq.XElement("Playlist", new System.Xml.Linq.XAttribute("name", playlistName));
                xelement.Add(newTag);
            }
            catch { Console.WriteLine("FAILED AddPlaylist catch"); }
        }

        public void AddPlaylistItem(String playlistName, Model.Media media)
        {
            try
            {
                foreach (var playlist in xelement.Elements("Playlist"))
                {
                    if (playlist.Attribute("name") != null && playlist.Attribute("name").Value == playlistName)
                    {
                        System.Xml.Linq.XElement newTag =
                            new System.Xml.Linq.XElement("Element",
                                new System.Xml.Linq.XElement("Path", media.Path),
                                new System.Xml.Linq.XElement("Stream", media.Stream),
                                new System.Xml.Linq.XElement("Type", media.Type)
                            );
                        playlist.Add(newTag);
                    }
                }
            }
            catch { Console.WriteLine("FAILED AddPlaylistItem catch"); }
        }

        public void RemovePlaylist(String playlistName)
        {
            try
            {
                foreach (var playlist in xelement.Elements("Playlist"))
                    if (playlist.Attribute("name") != null && playlist.Attribute("name").Value == playlistName)
                        foreach (var elem in playlist.Elements("Element"))
                           elem.Remove();
            }
            catch { Console.WriteLine("FAILED RemovePlaylist catch"); }
        }

        public void RemovePlaylistItem(String playlistName, Model.Media media)
        {
            try
            {
                foreach (var playlist in xelement.Elements("Playlist"))
                    foreach (var elem in playlist.Elements("Element"))
                        if (elem.Element("Path") != null &&
                            elem.Element("Stream") != null &&
                            elem.Element("Type") != null &&
                            elem.Element("Path").Value == media.Path &&
                            Boolean.Parse(elem.Element("Stream").Value) == media.Stream &&
                            (Model.Media.MediaType)Enum.Parse(typeof(Model.Media.MediaType), elem.Element("Type").Value) == media.Type)
                            elem.Remove();
            }
            catch { Console.WriteLine("FAILED RemovePlaylistItem catch"); }
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
            catch { Console.WriteLine("FAILED WriteInFile catch"); }
        }

    }
}
