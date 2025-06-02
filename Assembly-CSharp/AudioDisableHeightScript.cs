using UnityEngine;

public class AudioDisableHeightScript : MonoBehaviour
{
	public StudentScript Student;

	public Transform Player;

	public AudioSource MyAudio;

	public float Timer;

	private void Start()
	{
		if (Student != null && Student.Yandere != null)
		{
			Player = Student.Yandere.transform;
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!(Timer >= 1f))
		{
			return;
		}
		Timer = 0f;
		if (!MyAudio.isPlaying)
		{
			return;
		}
		if (Mathf.Abs(Player.position.y - base.transform.position.y) > 2f)
		{
			if (MyAudio.volume != 0f)
			{
				MyAudio.volume = 0f;
			}
		}
		else if (MyAudio.volume != 1f)
		{
			MyAudio.volume = 1f;
		}
	}
}
