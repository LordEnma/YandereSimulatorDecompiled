using UnityEngine;

public class DipJukeboxScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public AudioSource MyAudio;

	public Transform Yandere;

	private void Update()
	{
		if (Yandere.transform.position.y < base.transform.position.y - 1f || Yandere.transform.position.y > base.transform.position.y + 1f)
		{
			MyAudio.volume = 0f;
		}
		else if (MyAudio.isPlaying)
		{
			MyAudio.volume = 1f;
			float num = Vector3.Distance(Yandere.position, base.transform.position);
			if (num < 8f)
			{
				Jukebox.ClubDip = Mathf.MoveTowards(Jukebox.ClubDip, (7f - num) * 0.25f * Jukebox.Volume, Time.deltaTime);
				if (Jukebox.ClubDip < 0f)
				{
					Jukebox.ClubDip = 0f;
				}
				if (Jukebox.ClubDip > Jukebox.Volume)
				{
					Jukebox.ClubDip = Jukebox.Volume;
				}
			}
		}
		else if (MyAudio.isPlaying)
		{
			Jukebox.ClubDip = 0f;
		}
	}
}
