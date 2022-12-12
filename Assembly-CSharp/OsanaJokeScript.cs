using UnityEngine;
using UnityEngine.SceneManagement;

public class OsanaJokeScript : MonoBehaviour
{
	public ConstantRandomRotation[] Rotation;

	public GameObject BloodSplatterEffect;

	public GameObject ReturnLabel;

	public AudioClip BloodSplatterSFX;

	public AudioClip VictoryMusic;

	public AudioSource Jukebox;

	public Transform Head;

	public UILabel Label;

	public bool Advance;

	public float Timer;

	public int ID;

	private void Start()
	{
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Alphabet", 1);
			PlayerPrefs.SetInt("a", 1);
		}
	}

	private void Update()
	{
		if (Advance)
		{
			Timer += Time.deltaTime;
			if (Timer > 6.75f)
			{
				ReturnLabel.SetActive(true);
				if (Input.GetKeyDown("e"))
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
			else if (Timer > 3f)
			{
				Label.text = "Congratulations! You have beaten Yandere Simulator!";
				if (!Jukebox.isPlaying)
				{
					Jukebox.clip = VictoryMusic;
					Jukebox.Play();
				}
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			Rotation[0].enabled = false;
			Rotation[1].enabled = false;
			Rotation[2].enabled = false;
			Rotation[3].enabled = false;
			Rotation[4].enabled = false;
			Rotation[5].enabled = false;
			Rotation[6].enabled = false;
			Rotation[7].enabled = false;
			Object.Instantiate(BloodSplatterEffect, Head.position, Quaternion.identity);
			Head.localScale = new Vector3(0f, 0f, 0f);
			Jukebox.clip = BloodSplatterSFX;
			Jukebox.Play();
			Label.text = "";
			Advance = true;
		}
	}
}
