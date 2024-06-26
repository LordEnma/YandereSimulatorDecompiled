using UnityEngine;

public class YakuzaMusicScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public AudioSource[] BGM;

	public int NearestStudent;

	public int Frame;

	public int Phase;

	private void Update()
	{
		if (NearestStudent != 0)
		{
			Phase = 2;
		}
		else
		{
			Phase = 1;
		}
		int i = 2;
		if (StudentManager.Yandere.Chased || StudentManager.Yandere.Chasers > 0)
		{
			Phase = 6;
		}
		else
		{
			for (; i < 98; i++)
			{
				if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && (StudentManager.Students[i].Chasing || StudentManager.Students[i].Pursuing || (StudentManager.Students[i].Persona == PersonaType.Heroic && StudentManager.Students[i].SpottedYakuza)))
				{
					Phase = 6;
				}
			}
		}
		if (Phase < 3)
		{
			for (i = 86; i < 98; i++)
			{
				if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && StudentManager.Students[i].Fleeing)
				{
					Phase = 5;
				}
			}
		}
		if (Phase < 3)
		{
			for (i = 2; i < 86; i++)
			{
				if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && StudentManager.Students[i].Fleeing && StudentManager.Students[i].ReportPhase < 3)
				{
					Phase = 4;
				}
			}
		}
		if (Phase < 3)
		{
			for (i = 2; i < 86; i++)
			{
				if (StudentManager.Students[i] != null && StudentManager.Students[i].Alive && StudentManager.Students[i].Alarmed)
				{
					Phase = 3;
				}
			}
		}
		if (Phase == 2 && Vector3.Distance(StudentManager.Yandere.transform.position, StudentManager.Students[NearestStudent].transform.position) > 5f)
		{
			NearestStudent = 0;
			Phase = 1;
		}
		if (Phase == 1)
		{
			Frame++;
			if (Frame > 97)
			{
				Frame = 2;
			}
			if (StudentManager.Students[Frame] != null && Vector3.Distance(StudentManager.Yandere.transform.position, StudentManager.Students[Frame].transform.position) <= 5f)
			{
				NearestStudent = Frame;
				Phase = 2;
			}
		}
		for (i = 1; i < 7; i++)
		{
			if (i == Phase)
			{
				BGM[Phase].volume = Mathf.MoveTowards(BGM[Phase].volume, 1f, Time.deltaTime);
			}
			else
			{
				BGM[i].volume = Mathf.MoveTowards(BGM[i].volume, 0f, Time.deltaTime);
			}
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			StartStopMusic();
		}
	}

	private void StartStopMusic()
	{
		for (int i = 1; i < 7; i++)
		{
			if (BGM[i].enabled)
			{
				BGM[i].enabled = false;
				continue;
			}
			BGM[i].enabled = true;
			BGM[i].Play();
		}
	}
}
