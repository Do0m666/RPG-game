
using System;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;

namespace CGAME
{
    public static class MusicManager
    {


        public static Stream backgroundMusic = Sounds.simple_piano_improvisation;
        public static Stream test_sfx = Sounds.Yamaha_EX5_Stereo_Grand_C4;

        private static SoundPlayer sfx_player;
        private static SoundPlayer music_player;

        static MusicManager()
        {
            sfx_player = new SoundPlayer();
            music_player = new SoundPlayer();
        }

        public static void PlayMusic(Stream _music, bool _loop = false)
        {
            _music.Position = 0;

            music_player.Stream = null;

            music_player.Stream = _music;

            if (_loop)
            {
                music_player.PlayLooping();
            }
            else
            {
                music_player.Play();
            }
        }

        public static void StopMusic()
        {
            music_player.Stop();
        }

        public static void PlaySFX(Stream _sfx)
        {
            if (test_sfx.Position != 0) return;

            test_sfx.Position = 0;

            sfx_player.Stream = null;

            sfx_player.Stream = test_sfx;

            sfx_player.Play();
        }
    }
}
