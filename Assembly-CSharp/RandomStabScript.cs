using UnityEngine;

public class RandomStabScript : MonoBehaviour
{
	public AudioClip[] Stabs;

	public AudioClip Bite;

	public bool Biting;

	private void Start()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (!Biting)
		{
			component.clip = Stabs[Random.Range(0, Stabs.Length)];
			component.Play();
		}
		else
		{
			component.clip = Bite;
			component.pitch = Random.Range(0.5f, 1f);
			component.Play();
		}
	}
}
