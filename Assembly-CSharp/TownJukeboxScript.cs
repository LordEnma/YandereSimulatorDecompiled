using UnityEngine;

public class TownJukeboxScript : MonoBehaviour
{
	public enum Region
	{
		Residential = 0,
		Commercial = 1,
		Graveyard = 2,
		Industry = 3,
		Asylum = 4,
		Shrine = 5,
		Beach = 6
	}

	public StalkerYandereScript Yandere;

	public Region CurrentRegion;

	public AudioSource[] Track;

	public float Volume = 1f;

	public int Frame;

	private void Update()
	{
		Frame++;
		if (Frame == 1)
		{
			for (int i = 0; i < Track.Length; i++)
			{
				Track[i].Play();
			}
		}
		if (Yandere.transform.position.x > -393f && Yandere.transform.position.z > 183f)
		{
			CurrentRegion = Region.Beach;
		}
		else if (Yandere.transform.position.x > -393f && Yandere.transform.position.z > -6f)
		{
			CurrentRegion = Region.Commercial;
		}
		else if (Yandere.transform.position.x < -393f && Yandere.transform.position.z > -14f)
		{
			CurrentRegion = Region.Industry;
		}
		else if (Yandere.transform.position.x < -705f && Yandere.transform.position.z < -245.66666f)
		{
			CurrentRegion = Region.Graveyard;
		}
		else if ((double)Yandere.transform.position.x < -666.5 && Yandere.transform.position.z < -101f)
		{
			CurrentRegion = Region.Shrine;
		}
		else if (Yandere.transform.position.x > 425f && Yandere.transform.position.z < -294f)
		{
			CurrentRegion = Region.Asylum;
		}
		else
		{
			CurrentRegion = Region.Residential;
		}
		for (int j = 0; j < Track.Length; j++)
		{
			if (j == (int)CurrentRegion)
			{
				Track[j].volume = Mathf.MoveTowards(Track[j].volume, Volume, Time.deltaTime * 0.2f);
			}
			else
			{
				Track[j].volume = Mathf.MoveTowards(Track[j].volume, 0f, Time.deltaTime * 0.2f);
			}
		}
		if (Input.GetKeyDown("m"))
		{
			if (Volume == 1f)
			{
				Volume = 0f;
			}
			else
			{
				Volume = 1f;
			}
		}
	}
}
