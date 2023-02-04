using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DDRManager : MonoBehaviour
{
	public GameState GameState;

	public YandereScript Yandere;

	public Transform FinishLocation;

	public Renderer OriginalRenderer;

	public AudioListener YandereListener;

	public GameObject OverlayCanvas;

	public GameObject GameUI;

	[Header("General")]
	public DDRLevel LoadedLevel;

	[SerializeField]
	private DDRLevel[] levels;

	[SerializeField]
	private InputManagerScript inputManager;

	[SerializeField]
	private DDRMinigame ddrMinigame;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private Transform standPoint;

	[SerializeField]
	private float transitionSpeed = 2f;

	[Header("Camera")]
	[SerializeField]
	private Transform minigameCamera;

	[SerializeField]
	private Transform startPoint;

	[SerializeField]
	private Transform screenPoint;

	[SerializeField]
	private Transform watchPoint;

	[Header("Animation")]
	[SerializeField]
	private Animation machineScreenAnimation;

	[SerializeField]
	private Animation yandereAnim;

	[Header("UI")]
	[SerializeField]
	private Image fadeImage;

	[SerializeField]
	private RawImage[] overlayImages;

	[SerializeField]
	private VideoPlayer backgroundVideo;

	[SerializeField]
	private Transform levelSelect;

	[SerializeField]
	private GameObject endScreen;

	[SerializeField]
	private GameObject defeatScreen;

	[SerializeField]
	private Text continueText;

	[SerializeField]
	private ColorCorrectionCurves gameplayColorCorrection;

	private Transform target;

	private bool booted;

	public bool DebugMode;

	public bool CheckingForEnd;

	private void Start()
	{
		minigameCamera.position = startPoint.position;
		if (DebugMode)
		{
			BeginMinigame();
		}
	}

	public void Update()
	{
		minigameCamera.position = Vector3.Slerp(minigameCamera.position, target.position, transitionSpeed * Time.deltaTime);
		minigameCamera.rotation = Quaternion.Slerp(minigameCamera.rotation, target.rotation, transitionSpeed * Time.deltaTime);
		if (target == null)
		{
			return;
		}
		Vector3 position = standPoint.position;
		if (LoadedLevel != null)
		{
			ddrMinigame.UpdateGame(audioSource.time);
			GameState.Health -= Time.deltaTime;
			GameState.Health = Mathf.Clamp(GameState.Health, 0f, 100f);
			if (inputManager.TappedLeft)
			{
				yandereAnim["f02_danceLeft_00"].time = 0f;
				yandereAnim.Play("f02_danceLeft_00");
			}
			else if (inputManager.TappedDown)
			{
				yandereAnim["f02_danceDown_00"].time = 0f;
				yandereAnim.Play("f02_danceDown_00");
			}
			if (inputManager.TappedRight)
			{
				yandereAnim["f02_danceRight_00"].time = 0f;
				yandereAnim.Play("f02_danceRight_00");
			}
			else if (inputManager.TappedUp)
			{
				yandereAnim["f02_danceUp_00"].time = 0f;
				yandereAnim.Play("f02_danceUp_00");
			}
		}
		yandereAnim.transform.position = Vector3.Lerp(yandereAnim.transform.position, position, 10f * Time.deltaTime);
		if (CheckingForEnd && !audioSource.isPlaying)
		{
			OverlayCanvas.SetActive(value: false);
			GameUI.SetActive(value: false);
			CheckingForEnd = false;
			Debug.Log("End() was called because song ended.");
			StartCoroutine(End());
		}
		if (GameState.Health <= 0f && audioSource.pitch < 0.01f)
		{
			OverlayCanvas.SetActive(value: false);
			GameUI.SetActive(value: false);
			if (audioSource.isPlaying)
			{
				Debug.Log("End() was called because we ran out of health.");
				StartCoroutine(End());
			}
		}
	}

	public void BeginMinigame()
	{
		Debug.Log("BeginMinigame() was called.");
		yandereAnim["f02_danceMachineIdle_00"].layer = 0;
		yandereAnim["f02_danceRight_00"].layer = 1;
		yandereAnim["f02_danceLeft_00"].layer = 2;
		yandereAnim["f02_danceUp_00"].layer = 1;
		yandereAnim["f02_danceDown_00"].layer = 2;
		yandereAnim["f02_danceMachineIdle_00"].weight = 1f;
		yandereAnim["f02_danceRight_00"].weight = 1f;
		yandereAnim["f02_danceLeft_00"].weight = 1f;
		yandereAnim["f02_danceUp_00"].weight = 1f;
		yandereAnim["f02_danceDown_00"].weight = 1f;
		OverlayCanvas.SetActive(value: true);
		GameUI.SetActive(value: true);
		ddrMinigame.LoadLevelSelect(levels);
		StartCoroutine(minigameFlow());
		YandereListener.enabled = false;
	}

	public void BootOut()
	{
		minigameCamera.position = startPoint.position;
		StartCoroutine(fade(fadein: true, fadeImage, 5f));
		target = startPoint;
		ddrMinigame.UnloadLevelSelect();
		ReturnToNormalGameplay();
	}

	private IEnumerator minigameFlow()
	{
		levelSelect.gameObject.SetActive(value: true);
		defeatScreen.gameObject.SetActive(value: false);
		endScreen.gameObject.SetActive(value: false);
		audioSource.pitch = 1f;
		target = screenPoint;
		if (!booted)
		{
			yield return new WaitForSecondsRealtime(0.2f);
			StartCoroutine(fade(fadein: false, fadeImage));
			while (fadeImage.color.a > 0.4f)
			{
				yield return null;
			}
			machineScreenAnimation.Play();
			booted = true;
		}
		yield return new WaitForEndOfFrame();
		while (Input.GetAxis("A") != 0f)
		{
			yield return null;
		}
		while (LoadedLevel == null)
		{
			ddrMinigame.UpdateLevelSelect();
			yield return null;
		}
		ddrMinigame.LoadLevel(LoadedLevel);
		GameState = new GameState();
		yield return new WaitForSecondsRealtime(0.2f);
		transitionSpeed *= 2f;
		target = watchPoint;
		backgroundVideo.Play();
		backgroundVideo.playbackSpeed = 0f;
		StartCoroutine(fadeGameUI(fadein: true));
		backgroundVideo.playbackSpeed = 1f;
		audioSource.clip = LoadedLevel.Song;
		audioSource.time = 0f;
		audioSource.Play();
		CheckingForEnd = true;
		while (audioSource.time < audioSource.clip.length)
		{
			if (GameState.Health <= 0f)
			{
				GameState.FinishStatus = DDRFinishStatus.Failed;
				while (audioSource.pitch > 0f)
				{
					audioSource.pitch = Mathf.MoveTowards(audioSource.pitch, 0f, 0.2f * Time.deltaTime);
					if (audioSource.pitch == 0f)
					{
						Debug.Log("Pitch reached zero.");
						audioSource.time = audioSource.clip.length;
						OverlayCanvas.SetActive(value: false);
						GameUI.SetActive(value: false);
					}
					yield return null;
				}
				break;
			}
			yield return null;
		}
	}

	private IEnumerator End()
	{
		audioSource.Stop();
		levelSelect.gameObject.SetActive(value: false);
		StopCoroutine(fadeGameUI(fadein: true));
		StartCoroutine(fadeGameUI(fadein: false));
		if (GameState.FinishStatus == DDRFinishStatus.Complete)
		{
			endScreen.gameObject.SetActive(value: true);
			ddrMinigame.UpdateEndcard(GameState);
			if (LoadedLevel != levels[4] && !GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("Dance", 1);
				PlayerPrefs.SetInt("a", 1);
			}
		}
		else
		{
			defeatScreen.SetActive(value: true);
		}
		target = screenPoint;
		LoadedLevel = null;
		ddrMinigame.UnloadLevelSelect();
		yield return new WaitForSecondsRealtime(2f);
		StartCoroutine(fade(fadein: true, continueText));
		while (!Input.anyKeyDown || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
		{
			yield return null;
		}
		ddrMinigame.Unload();
		onLevelFinish(GameState.FinishStatus);
	}

	private IEnumerator fadeGameUI(bool fadein)
	{
		float destination = (fadein ? 1 : 0);
		float amount = ((!fadein) ? 1 : 0);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, 10f * Time.deltaTime);
			RawImage[] array = overlayImages;
			foreach (RawImage obj in array)
			{
				Color color = obj.color;
				color.a = amount;
				obj.color = color;
			}
			yield return null;
		}
	}

	private IEnumerator fade(bool fadein, MaskableGraphic graphic, float speed = 1f)
	{
		float destination = (fadein ? 1 : 0);
		float amount = ((!fadein) ? 1 : 0);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, speed * Time.deltaTime);
			Color color = graphic.color;
			color.a = amount;
			graphic.color = color;
			yield return null;
		}
	}

	private void onLevelFinish(DDRFinishStatus status)
	{
		BootOut();
	}

	public void ReturnToNormalGameplay()
	{
		for (int i = 0; i < 4; i++)
		{
			foreach (Transform item in ddrMinigame.uiTracks[i])
			{
				if (item.gameObject.name != "TrackSymbol")
				{
					Object.Destroy(item.gameObject);
				}
			}
		}
		Debug.Log("ReturnToNormalGameplay() was called.");
		yandereAnim["f02_danceMachineIdle_00"].weight = 0f;
		yandereAnim["f02_danceRight_00"].weight = 0f;
		yandereAnim["f02_danceLeft_00"].weight = 0f;
		yandereAnim["f02_danceUp_00"].weight = 0f;
		yandereAnim["f02_danceDown_00"].weight = 0f;
		Yandere.transform.position = FinishLocation.position;
		Yandere.transform.rotation = FinishLocation.rotation;
		Yandere.StudentManager.Clock.StopTime = false;
		Yandere.MyController.enabled = true;
		Yandere.StudentManager.ComeBack();
		Yandere.CanMove = true;
		Yandere.enabled = true;
		Yandere.HeartCamera.enabled = true;
		Yandere.HUD.enabled = true;
		Yandere.HUD.transform.parent.gameObject.SetActive(value: true);
		Yandere.MainCamera.gameObject.SetActive(value: true);
		Yandere.Jukebox.Volume = Yandere.Jukebox.LastVolume;
		OriginalRenderer.enabled = true;
		Physics.SyncTransforms();
		base.transform.parent.gameObject.SetActive(value: false);
		YandereListener.enabled = true;
		continueText.color = new Color(1f, 1f, 1f, 0f);
	}
}
