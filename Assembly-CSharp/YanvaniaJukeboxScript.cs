using UnityEngine;

public class YanvaniaJukeboxScript : MonoBehaviour
{
	public AudioClip BossIntro;

	public AudioClip BossMain;

	public AudioClip ApproachIntro;

	public AudioClip ApproachMain;

	public bool Boss;

	private void Update()
	{
		AudioSource component = GetComponent<AudioSource>();
		if (component.time + Time.deltaTime > component.clip.length || !component.isPlaying)
		{
			component.clip = (Boss ? BossMain : ApproachMain);
			component.loop = true;
			component.Play();
		}
	}

	public void BossBattle()
	{
		AudioSource component = GetComponent<AudioSource>();
		component.clip = BossIntro;
		component.loop = false;
		component.volume = 0.25f;
		component.Play();
		Boss = true;
	}
}
