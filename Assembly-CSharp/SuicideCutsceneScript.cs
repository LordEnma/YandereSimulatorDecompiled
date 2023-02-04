using UnityEngine;
using UnityEngine.SceneManagement;

public class SuicideCutsceneScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public AudioClip EightiesMother;

	public Light DirectionalLight;

	public Light PointLight;

	public Transform Door;

	public Animation Mom;

	public float Timer;

	public float Rotation;

	public float Speed;

	public int ID;

	public GameObject[] RivalHair;

	public GameObject[] EightiesHair;

	private void Start()
	{
		PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
		Door.eulerAngles = new Vector3(0f, 0f, 0f);
		if (GameGlobals.Eighties)
		{
			MyAudio.clip = EightiesMother;
			RivalHair[1].SetActive(value: false);
			EightiesHair[DateGlobals.Week].SetActive(value: true);
		}
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (ID == 0)
		{
			if (Timer > 1f)
			{
				MyAudio.Play();
				ID++;
			}
		}
		else
		{
			if (ID != 1)
			{
				return;
			}
			if (Timer > 6f)
			{
				Speed += Time.deltaTime * 0.66666f;
				Rotation = Mathf.Lerp(Rotation, -45f, Time.deltaTime * Speed);
				PointLight.color = new Color(0.1f + Rotation / -45f * 0.9f, 0.1f + Rotation / -45f * 0.9f, 0.1f + Rotation / -45f * 0.9f, 1f);
				Door.eulerAngles = new Vector3(0f, Rotation, 0f);
			}
			if (Timer > 8.5f)
			{
				Mom.CrossFade("f02_shock_00");
			}
			if (Timer > 9.5f)
			{
				DirectionalLight.color = new Color(0f, 0f, 0f);
				PointLight.color = new Color(0f, 0f, 0f);
			}
			if (Timer > 11f)
			{
				GameGlobals.SpecificEliminationID = 19;
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("Suicide", 1);
				}
				if (!GameGlobals.Debug)
				{
					PlayerPrefs.SetInt("a", 1);
				}
				SchoolGlobals.SchoolAtmosphere -= 0.1f;
				GameGlobals.SenpaiMourning = true;
				SceneManager.LoadScene("HomeScene");
			}
		}
	}
}
