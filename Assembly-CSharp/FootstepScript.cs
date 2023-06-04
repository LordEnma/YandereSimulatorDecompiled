using UnityEngine;

public class FootstepScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public AudioSource MyAudio;

	public AudioClip[] WalkFootsteps;

	public AudioClip[] RunFootsteps;

	public float DownThreshold = 0.02f;

	public float UpThreshold = 0.025f;

	public bool Debugging;

	public bool FootUp;

	private void Update()
	{
		if (Debugging)
		{
			Debug.Log("UpThreshold: " + (HomeYandere.transform.position.y + UpThreshold) + " | DownThreshold: " + (HomeYandere.transform.position.y + DownThreshold) + " | CurrentHeight: " + base.transform.position.y);
		}
		if (!FootUp)
		{
			if (base.transform.position.y > HomeYandere.transform.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else
		{
			if (!(base.transform.position.y < HomeYandere.transform.position.y + DownThreshold))
			{
				return;
			}
			if (FootUp)
			{
				if (HomeYandere.Running)
				{
					MyAudio.clip = RunFootsteps[Random.Range(0, RunFootsteps.Length)];
					MyAudio.volume = 0.4f;
				}
				else
				{
					MyAudio.clip = WalkFootsteps[Random.Range(0, WalkFootsteps.Length)];
					MyAudio.volume = 0.2f;
				}
				MyAudio.Play();
			}
			FootUp = false;
		}
	}
}
