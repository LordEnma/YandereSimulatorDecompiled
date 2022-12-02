using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiCheatScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public GameObject Jukebox;

	public bool Check;

	private void Start()
	{
		MyAudio = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (Check && !MyAudio.isPlaying)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			Jukebox.SetActive(false);
			Check = true;
			MyAudio.Play();
		}
	}
}
