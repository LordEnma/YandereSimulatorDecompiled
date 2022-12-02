using UnityEngine;

public class ClubAmbienceScript : MonoBehaviour
{
	public JukeboxScript Jukebox;

	public Transform Yandere;

	public bool CreateAmbience;

	public bool EffectJukebox;

	public float ClubDip;

	public float MaxVolume;

	private void Update()
	{
		if (Yandere.position.y > base.transform.position.y - 0.1f && Yandere.position.y < base.transform.position.y + 0.1f)
		{
			if (Vector3.Distance(base.transform.position, Yandere.position) < 4f)
			{
				CreateAmbience = true;
				EffectJukebox = true;
			}
			else
			{
				CreateAmbience = false;
			}
		}
		if (!EffectJukebox)
		{
			return;
		}
		AudioSource component = GetComponent<AudioSource>();
		if (CreateAmbience)
		{
			component.volume = Mathf.MoveTowards(component.volume, MaxVolume, Time.deltaTime * 0.1f);
			Jukebox.ClubDip = Mathf.MoveTowards(Jukebox.ClubDip, ClubDip, Time.deltaTime * 0.1f);
			return;
		}
		component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime * 0.1f);
		Jukebox.ClubDip = Mathf.MoveTowards(Jukebox.ClubDip, 0f, Time.deltaTime * 0.1f);
		if (Jukebox.ClubDip == 0f)
		{
			EffectJukebox = false;
		}
	}
}
