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
                Name = System.IO.Path.GetFileName(value);
                ModificationDate = System.IO.File.GetLastWriteTime(value);
            }
        }

        // Modification date
        public DateTime ModificationDate { get; set; }

        // TYPE
        public enum MediaType { MUSIC, VIDEO, PICTURE };
        public MediaType Type { get; set; }

        // CTOR
        public Media(String path)
        {
            Path = path;
        }

    }
}
