using UnityEngine;

public class BloodyScreamScript : MonoBehaviour
{
	public AudioClip[] Screams;

	private void Start()
	{
		AudioSource component = GetComponent<AudioSource>();
		component.clip = Screams[Random.Range(0, Screams.Length)];
		component.Play();
	}
}
