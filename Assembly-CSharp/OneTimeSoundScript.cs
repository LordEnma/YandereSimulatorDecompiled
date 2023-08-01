using UnityEngine;

public class OneTimeSoundScript : MonoBehaviour
{
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.SetActive(value: false);
		audioSource.Play();
		base.enabled = false;
	}
}
