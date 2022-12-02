using UnityEngine;

public class FootstepScript : MonoBehaviour
{
	public StudentScript Student;

	public AudioSource MyAudio;

	public AudioClip[] WalkFootsteps;

	public AudioClip[] RunFootsteps;

	public float DownThreshold = 0.02f;

	public float UpThreshold = 0.025f;

	public bool FootUp;

	private void Start()
	{
		if (!Student.Nemesis)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!FootUp)
		{
			if (base.transform.position.y > Student.transform.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else
		{
			if (!(base.transform.position.y < Student.transform.position.y + DownThreshold))
			{
				return;
			}
			if (FootUp)
			{
				if (Student.Pathfinding.speed > 1f)
				{
					MyAudio.clip = RunFootsteps[Random.Range(0, RunFootsteps.Length)];
					MyAudio.volume = 0.2f;
				}
				else
				{
					MyAudio.clip = WalkFootsteps[Random.Range(0, WalkFootsteps.Length)];
					MyAudio.volume = 0.1f;
				}
				MyAudio.Play();
			}
			FootUp = false;
		}
	}
}
