using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Media
    {
        // NAME
        public String Name { get; set; }

        // PATH
        private String _Path;
        public String Path
        {
            get { return _Path; }
            set
            {
                _Path = value;

                if (System.IO.File.Exists(Path))
                {
                    Name = System.IO.Path.GetFileName(value);
                    ModificationDate = System.IO.File.GetLastWriteTime(value);
                }
                else
                {
                    Name = Path;
                    ModificationDate = new DateTime();
                }
            }
        }

        // Modification date
        public DateTime ModificationDate { get; set; }

        // TYPE
        public enum MediaType { MUSIC, VIDEO, PICTURE };
        public MediaType Type { get; set; }

        // IS STREAM
        public bool Stream { get; set; }

        // CTOR
        public Media(String path, bool stream)
        {
            Stream = stream;
            Path = path;
        }

    }
}
