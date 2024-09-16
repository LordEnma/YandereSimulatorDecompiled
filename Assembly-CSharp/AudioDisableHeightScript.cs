using UnityEngine;

public class AudioDisableHeightScript : MonoBehaviour
{
	public StudentScript Student;

	public Transform Player;

	public AudioSource MyAudio;

	private void Start()
	{
		if (Student != null && Student.Yandere != null)
		{
			Player = Student.Yandere.transform;
		}
	}

	private void Update()
	{
		if (MyAudio.isPlaying)
		{
			if (Player.position.y > base.transform.position.y + 2f)
			{
				MyAudio.volume = 0f;
			}
			else if (Player.position.y < base.transform.position.y - 2f)
			{
				MyAudio.volume = 0f;
			}
			else
			{
				MyAudio.volume = 1f;
			}
		}
	}
}
