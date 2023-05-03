using System.Media;
using H1_ERP_System.ui;

namespace H1_ERP_System.util;

/// <summary>
///     Utility class for playing music.
/// </summary>
/// <seealso cref="PlaySound" />
public static class Music
{
	/// <summary>
	///     Plays a sound from a path on a new thread.
	/// </summary>
	/// <param name="path">The path to the sound file.</param>
	/// <param name="isLooping">Whether or not the sound should loop.</param>
	public static void PlaySound(string path, bool isLooping = false)
	{
		// Check if the file exists.
		if (!File.Exists(path))
		{
			new ErrorScreen("The music file does not exist!");
			
			return;
		}
		
		var musicPlayer = new SoundPlayer();

		musicPlayer.SoundLocation = path;
		
		// Play the sound on a loop if the isLooping parameter is true.
		if (isLooping)
		{
			musicPlayer.PlayLooping();
		}
		else
		{
			musicPlayer.Play();
		}
	}
}
