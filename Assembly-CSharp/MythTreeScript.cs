using UnityEngine;

public class MythTreeScript : MonoBehaviour
{
	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public bool Spoken;

	public AudioSource MyAudio;

	private void Start()
	{
		if (SchemeGlobals.GetSchemeStage(2) > 2 || GameGlobals.Eighties)
		{
			Object.Destroy(this);
		}
	}

	private void Update()
	{
		if (!Spoken)
		{
			if (Yandere.Inventory.Ring && Vector3.Distance(Yandere.transform.position, base.transform.position) < 5f)
			{
				EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				EventSubtitle.text = "...that...ring...";
				Jukebox.Dip = 0.5f;
				Spoken = true;
				MyAudio.Play();
			}
		}
		else if (!MyAudio.isPlaying)
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			EventSubtitle.text = string.Empty;
			Jukebox.Dip = 1f;
			Object.Destroy(this);
		}
	}
}
