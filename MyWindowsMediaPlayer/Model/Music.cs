using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWindowsMediaPlayer.Model
{
    class Music : Media
    {
        public Music(String path, bool stream = false) : base(path, stream) {
            Type = Media.MediaType.MUSIC;

            Title = "";
            Artists = "";
            Album = "";

            if (stream == false)
                extractMp3Info();
        }

        public void extractMp3Info()
        {
            if (System.IO.File.Exists(Path))
            { 
                using (System.IO.FileStream fs = new System.IO.FileStream(Path, System.IO.FileMode.Open))
                {
                    byte[] b = new byte[128];

                    fs.Seek(-128, System.IO.SeekOrigin.End);
                    fs.Read(b, 0, 128);

                    if (System.Text.Encoding.Default.GetString(b, 0, 3).CompareTo("TAG") == 0)
                    {
                        Title = System.Text.Encoding.Default.GetString(b, 3, 3).TrimEnd('\0');
                        Artists = System.Text.Encoding.Default.GetString(b, 33, 30).TrimEnd('\0');
                        Album = System.Text.Encoding.Default.GetString(b, 63, 30).TrimEnd('\0');
                    }
                    fs.Close();
                }
            }
        }

        public String Artists { get; set; }
        public String Title { get; set; }
        public String Album { get; set; }

    }
}
