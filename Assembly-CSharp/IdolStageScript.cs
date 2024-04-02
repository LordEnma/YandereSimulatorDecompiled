using UnityEngine;

public class IdolStageScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public AudioSource[] Music;

	public Transform[] Spot;

	public Transform Yandere;

	public bool RestoreVolume;

	private void Update()
	{
		for (int i = 1; i < 5; i++)
		{
			if (StudentManager.Students[51 + i] != null)
			{
				if (Vector3.Distance(StudentManager.Students[51 + i].transform.position, Spot[i].position) < 1f && StudentManager.Students[51 + i].Routine && !StudentManager.Students[51 + i].Alarmed)
				{
					Music[i].volume = Mathf.MoveTowards(Music[i].volume, 1f, Time.deltaTime);
				}
				else
				{
					Music[i].volume = Mathf.MoveTowards(Music[i].volume, 0f, Time.deltaTime);
				}
			}
		}
		if (StudentManager.Students[16] != null)
		{
			if (Vector3.Distance(StudentManager.Students[16].transform.position, Spot[5].position) < 1f && StudentManager.Students[16].Routine && !StudentManager.Students[16].Alarmed && StudentManager.Students[16].Alive)
			{
				Music[5].volume = Mathf.MoveTowards(Music[5].volume, 1f, Time.deltaTime);
			}
			else
			{
				Music[5].volume = Mathf.MoveTowards(Music[5].volume, 0f, Time.deltaTime);
			}
		}
		if (Vector3.Distance(Yandere.position, base.transform.position) < 10f)
		{
			Jukebox.Dip = Mathf.MoveTowards(Jukebox.Dip, 0f, Time.deltaTime);
			RestoreVolume = true;
		}
		else if (RestoreVolume)
		{
			Jukebox.Dip = Mathf.MoveTowards(Jukebox.Dip, 1f, Time.deltaTime);
			if (Jukebox.Dip == 0f)
			{
				RestoreVolume = false;
			}
		}
	}
}
