using UnityEngine;

public class RandomCameraFlashScript : MonoBehaviour
{
	public AudioSource audioSource;

	public float interval = 0.1f;

	[Range(0f, 1f)]
	public float playChance = 0.5f;

	private float timer;

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= interval)
		{
			timer = 0f;
			if (Random.value < playChance)
			{
				audioSource.Play();
			}
		}
	}
}
