using UnityEngine;

public class RandomSoundScript : MonoBehaviour
{
	public AudioClip[] Clips;

	private void Start()
	{
		AudioSource component = GetComponent<AudioSource>();
		component.clip = Clips[Random.Range(1, Clips.Length)];
		component.Play();
	}
}
