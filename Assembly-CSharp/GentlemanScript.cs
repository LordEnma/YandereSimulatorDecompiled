using UnityEngine;

public class GentlemanScript : MonoBehaviour
{
	public YandereScript Yandere;

	public AudioClip[] Clips;

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_RB))
		{
			AudioSource component = GetComponent<AudioSource>();
			if (!component.isPlaying)
			{
				component.clip = Clips[Random.Range(0, Clips.Length)];
				component.Play();
				Yandere.Sanity += 10f;
			}
		}
	}
}
