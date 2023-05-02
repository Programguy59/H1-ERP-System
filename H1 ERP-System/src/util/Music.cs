using System.Media;

namespace H1_ERP_System.util;

public class Music
{
    public static void playSound(string filepath)
    {
        SoundPlayer musicPlayer = new SoundPlayer();
        musicPlayer.SoundLocation = filepath;
        musicPlayer.Play();
    }
}