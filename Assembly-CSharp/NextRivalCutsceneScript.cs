using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRivalCutsceneScript : MonoBehaviour
{
	public AudioHandler_AmaiEndOfTheWeek AudioHandler;

	public FixedFrameAnimation Cutscene;

	public GameObject[] ObjectsToDisable;

	public GameObject InfoTextConvo;

	public Renderer SenpaiRenderer;

	public float LastInputTimer;

	public float LowestPoint;

	public float Intensity;

	public float Timer;

	public Transform RightHand;

	public Transform Camera;

	public Transform Book;

	public UISprite SkipCircle;

	public UISprite Darkness;

	public AudioSource[] Audio;

	public Texture TestTexture;

	public UIPanel SkipPanel;

	public UILabel Subtitle;

	public string[] Lines;

	public float[] Times;

	public int SubtitleID;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			_ = GameGlobals.CustomMode;
		}
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/SenpaiPortrait.png");
		TestTexture = wWW.texture;
		SenpaiRenderer.materials[0].mainTexture = wWW.texture;
		if (DateGlobals.Week < 3 || DateGlobals.Weekday != DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Sunday;
			DateGlobals.Week = 3;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		Debug.Log("It's Week 3.");
		Darkness.alpha = 1f;
	}

	private void LateUpdate()
	{
		if (!Cutscene.isPlaying)
		{
			SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 0f, Time.deltaTime);
			InfoTextConvo.SetActive(value: true);
			return;
		}
		Timer += Time.deltaTime;
		if (Timer > Times[SubtitleID])
		{
			Subtitle.text = Lines[SubtitleID];
			SubtitleID++;
		}
		if (Timer > 1f)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 0.2f);
		}
		if (Timer > 42f)
		{
			Intensity += Time.deltaTime * 0.0001f;
			if (Camera.localEulerAngles.y < 334f || Camera.localEulerAngles.y > 335f)
			{
				Camera.position += new Vector3(UnityEngine.Random.Range(Intensity * -1f, Intensity * 1f), UnityEngine.Random.Range(Intensity * -1f, Intensity * 1f), UnityEngine.Random.Range(Intensity * -1f, Intensity * 1f));
				Audio[1].volume -= Time.deltaTime * 0.05f;
				Audio[2].volume -= Time.deltaTime * 0.05f;
				Audio[3].volume -= Time.deltaTime * 0.005f;
				Audio[4].volume -= Time.deltaTime * 0.005f;
				Audio[5].volume += Time.deltaTime * 0.0265f;
			}
			else if (Audio[5].volume > 0f)
			{
				Debug.Log("Snap back to reality, oh, there goes gravity.");
				Audio[3].volume = 0.05f;
				Audio[4].volume = 0.05f;
				Audio[5].volume = 0f;
			}
		}
		if (Timer > 26.66666f)
		{
			Book.GetComponent<Animation>().Stop();
			Book.parent = RightHand;
		}
		LastInputTimer += Time.deltaTime;
		if (Input.anyKeyDown)
		{
			LastInputTimer = 0f;
		}
		if (LastInputTimer > 5f)
		{
			SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 0f, Time.deltaTime * 0.2f);
			return;
		}
		SkipPanel.alpha = Mathf.MoveTowards(SkipPanel.alpha, 1f, Time.deltaTime);
		if (Input.GetButton(InputNames.Xbox_X))
		{
			SkipCircle.fillAmount -= Time.deltaTime;
			if (SkipCircle.fillAmount == 0f)
			{
				Debug.Log("Skipping, now, from here.");
				ObjectsToDisable[0].SetActive(value: false);
				Cutscene.animationComponent.Stop();
				Cutscene.isPlaying = false;
				Cutscene.enabled = false;
				AudioHandler.ShutUp();
				Audio[1].Stop();
				Audio[1].enabled = false;
				Audio[1].volume = 0f;
				Audio[1].pitch = 0f;
				Audio[1].gameObject.SetActive(value: false);
				Subtitle.text = "";
			}
		}
		else
		{
			SkipCircle.fillAmount = 1f;
		}
	}

	public void ShutUp()
	{
		for (int i = 1; i < Audio.Length; i++)
		{
			Audio[i].Stop();
		}
	}
}
