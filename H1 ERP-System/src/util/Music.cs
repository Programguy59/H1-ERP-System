using System.Media;

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
		var musicPlayer = new SoundPlayer();

		musicPlayer.SoundLocation = path;

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
