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

            if (stream == false)
                extractMp3Info();
        }

        public void extractMp3Info()
        {
            Id3.Mp3File mp3File = new Id3.Mp3File(Path);
            Id3.Id3Tag tag = mp3File.GetTag(Id3.Id3TagFamily.FileStartTag);

            Artists = tag.Artists.Value;
            Title = tag.Title.Value;
            Album = tag.Album.Value;
        }

        public String Artists { get; set; }
        public String Title { get; set; }
        public String Album { get; set; }

    }
}
