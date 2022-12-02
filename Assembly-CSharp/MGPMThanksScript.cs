using UnityEngine;
using UnityEngine.SceneManagement;

public class MGPMThanksScript : MonoBehaviour
{
	public AudioClip ThanksMusic;

	public AudioSource Jukebox;

	public Renderer Black;

	public int Phase = 1;

	private void Start()
	{
		Black.material.color = new Color(0f, 0f, 0f, 1f);
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Miyuki", 1);
			PlayerPrefs.SetInt("a", 1);
		}
	}

	private void Update()
	{
		if (Phase == 1)
		{
			Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.material.color.a, 0f, Time.deltaTime));
			if (Black.material.color.a == 0f)
			{
				Jukebox.Play();
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (!Jukebox.isPlaying)
			{
				Jukebox.clip = ThanksMusic;
				Jukebox.loop = true;
				Jukebox.Play();
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Input.anyKeyDown)
			{
				Phase++;
			}
		}
		else
		{
			Black.material.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(Black.material.color.a, 1f, Time.deltaTime));
			Jukebox.volume = 1f - Black.material.color.a;
			if (Black.material.color.a == 1f)
			{
				HomeGlobals.MiyukiDefeated = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}
}
