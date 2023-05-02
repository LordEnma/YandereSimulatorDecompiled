using UnityEngine;

public class CalisthenicsRadioScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public GameObject MusicNotes;

	public AudioSource MyAudio;

	private void Start()
	{
		if (!GameGlobals.Eighties)
		{
			base.transform.parent.gameObject.SetActive(value: false);
		}
		else if (DateGlobals.Week != 4)
		{
			base.transform.parent.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (StudentManager.Clock.Period == 6 && StudentManager.Students[StudentManager.RivalID] != null && StudentManager.Students[StudentManager.RivalID].DistanceToDestination < 1f)
		{
			if (!MyAudio.isPlaying)
			{
				MyAudio.Play();
				MusicNotes.SetActive(value: true);
			}
			float num = Vector3.Distance(StudentManager.Yandere.transform.position, base.transform.position);
			if (num < 9f)
			{
				Jukebox.ClubDip = Mathf.MoveTowards(Jukebox.ClubDip, (8f - num) * 0.2f * Jukebox.Volume, Time.deltaTime);
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
			MyAudio.Stop();
			Jukebox.ClubDip = 0f;
			MusicNotes.SetActive(value: false);
		}
	}
}
