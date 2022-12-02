using UnityEngine;

public class FountainScript : MonoBehaviour
{
	public ParticleSystem Splashes;

	public UILabel EventSubtitle;

	public Collider[] Colliders;

	public bool Drowning;

	public AudioSource SpraySFX;

	public AudioSource DropsSFX;

	public float StartTimer;

	public float Timer;

	private void Start()
	{
		SpraySFX.volume = 0.1f;
		DropsSFX.volume = 0.1f;
	}

	private void Update()
	{
		if (StartTimer < 1f)
		{
			StartTimer += Time.deltaTime;
			if (StartTimer > 1f)
			{
				SpraySFX.gameObject.SetActive(true);
				DropsSFX.gameObject.SetActive(true);
			}
		}
		if (Drowning)
		{
			if (Timer == 0f && EventSubtitle.transform.localScale.x < 1f)
			{
				EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				EventSubtitle.text = "Hey, what are you -";
				GetComponent<AudioSource>().Play();
			}
			Timer += Time.deltaTime;
			if (Timer > 3f && EventSubtitle.transform.localScale.x > 0f)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
				EventSubtitle.text = string.Empty;
				Splashes.Play();
			}
			if (Timer > 9f)
			{
				Drowning = false;
				Splashes.Stop();
				Timer = 0f;
			}
		}
	}
}
