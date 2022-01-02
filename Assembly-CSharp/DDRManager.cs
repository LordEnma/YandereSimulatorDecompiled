using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

// Token: 0x02000003 RID: 3
public class DDRManager : MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	private void Start()
	{
		this.minigameCamera.position = this.startPoint.position;
		if (this.DebugMode)
		{
			this.BeginMinigame();
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002080 File Offset: 0x00000280
	public void Update()
	{
		this.minigameCamera.position = Vector3.Slerp(this.minigameCamera.position, this.target.position, this.transitionSpeed * Time.deltaTime);
		this.minigameCamera.rotation = Quaternion.Slerp(this.minigameCamera.rotation, this.target.rotation, this.transitionSpeed * Time.deltaTime);
		if (this.target == null)
		{
			return;
		}
		Vector3 position = this.standPoint.position;
		if (this.LoadedLevel != null)
		{
			this.ddrMinigame.UpdateGame(this.audioSource.time);
			this.GameState.Health -= Time.deltaTime;
			this.GameState.Health = Mathf.Clamp(this.GameState.Health, 0f, 100f);
			if (this.inputManager.TappedLeft)
			{
				this.yandereAnim["f02_danceLeft_00"].time = 0f;
				this.yandereAnim.Play("f02_danceLeft_00");
			}
			else if (this.inputManager.TappedDown)
			{
				this.yandereAnim["f02_danceDown_00"].time = 0f;
				this.yandereAnim.Play("f02_danceDown_00");
			}
			if (this.inputManager.TappedRight)
			{
				this.yandereAnim["f02_danceRight_00"].time = 0f;
				this.yandereAnim.Play("f02_danceRight_00");
			}
			else if (this.inputManager.TappedUp)
			{
				this.yandereAnim["f02_danceUp_00"].time = 0f;
				this.yandereAnim.Play("f02_danceUp_00");
			}
		}
		this.yandereAnim.transform.position = Vector3.Lerp(this.yandereAnim.transform.position, position, 10f * Time.deltaTime);
		if (this.CheckingForEnd && !this.audioSource.isPlaying)
		{
			this.OverlayCanvas.SetActive(false);
			this.GameUI.SetActive(false);
			this.CheckingForEnd = false;
			Debug.Log("End() was called because song ended.");
			base.StartCoroutine(this.End());
		}
		if (this.GameState.Health <= 0f && this.audioSource.pitch < 0.01f)
		{
			this.OverlayCanvas.SetActive(false);
			this.GameUI.SetActive(false);
			if (this.audioSource.isPlaying)
			{
				Debug.Log("End() was called because we ranout of health.");
				base.StartCoroutine(this.End());
			}
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002330 File Offset: 0x00000530
	public void BeginMinigame()
	{
		Debug.Log("BeginMinigame() was called.");
		this.yandereAnim["f02_danceMachineIdle_00"].layer = 0;
		this.yandereAnim["f02_danceRight_00"].layer = 1;
		this.yandereAnim["f02_danceLeft_00"].layer = 2;
		this.yandereAnim["f02_danceUp_00"].layer = 1;
		this.yandereAnim["f02_danceDown_00"].layer = 2;
		this.yandereAnim["f02_danceMachineIdle_00"].weight = 1f;
		this.yandereAnim["f02_danceRight_00"].weight = 1f;
		this.yandereAnim["f02_danceLeft_00"].weight = 1f;
		this.yandereAnim["f02_danceUp_00"].weight = 1f;
		this.yandereAnim["f02_danceDown_00"].weight = 1f;
		this.OverlayCanvas.SetActive(true);
		this.GameUI.SetActive(true);
		this.ddrMinigame.LoadLevelSelect(this.levels);
		base.StartCoroutine(this.minigameFlow());
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002470 File Offset: 0x00000670
	public void BootOut()
	{
		this.minigameCamera.position = this.startPoint.position;
		base.StartCoroutine(this.fade(true, this.fadeImage, 5f));
		this.target = this.startPoint;
		this.ddrMinigame.UnloadLevelSelect();
		this.ReturnToNormalGameplay();
	}

	// Token: 0x06000006 RID: 6 RVA: 0x000024C9 File Offset: 0x000006C9
	private IEnumerator minigameFlow()
	{
		this.levelSelect.gameObject.SetActive(true);
		this.defeatScreen.gameObject.SetActive(false);
		this.endScreen.gameObject.SetActive(false);
		this.audioSource.pitch = 1f;
		this.target = this.screenPoint;
		if (!this.booted)
		{
			yield return new WaitForSecondsRealtime(0.2f);
			base.StartCoroutine(this.fade(false, this.fadeImage, 1f));
			while (this.fadeImage.color.a > 0.4f)
			{
				yield return null;
			}
			this.machineScreenAnimation.Play();
			this.booted = true;
		}
		yield return new WaitForEndOfFrame();
		while (Input.GetAxis("A") != 0f)
		{
			yield return null;
		}
		while (this.LoadedLevel == null)
		{
			this.ddrMinigame.UpdateLevelSelect();
			yield return null;
		}
		this.ddrMinigame.LoadLevel(this.LoadedLevel);
		this.GameState = new GameState();
		yield return new WaitForSecondsRealtime(0.2f);
		this.transitionSpeed *= 2f;
		this.target = this.watchPoint;
		this.backgroundVideo.Play();
		this.backgroundVideo.playbackSpeed = 0f;
		base.StartCoroutine(this.fadeGameUI(true));
		this.backgroundVideo.playbackSpeed = 1f;
		this.audioSource.clip = this.LoadedLevel.Song;
		this.audioSource.Play();
		this.CheckingForEnd = true;
		while (this.audioSource.time < this.audioSource.clip.length)
		{
			if (this.GameState.Health <= 0f)
			{
				this.GameState.FinishStatus = DDRFinishStatus.Failed;
				while (this.audioSource.pitch > 0f)
				{
					this.audioSource.pitch = Mathf.MoveTowards(this.audioSource.pitch, 0f, 0.2f * Time.deltaTime);
					if (this.audioSource.pitch == 0f)
					{
						Debug.Log("Pitch reached zero.");
						this.audioSource.time = this.audioSource.clip.length;
						this.OverlayCanvas.SetActive(false);
						this.GameUI.SetActive(false);
					}
					yield return null;
				}
				break;
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000024D8 File Offset: 0x000006D8
	private IEnumerator End()
	{
		this.audioSource.Stop();
		this.levelSelect.gameObject.SetActive(false);
		base.StopCoroutine(this.fadeGameUI(true));
		base.StartCoroutine(this.fadeGameUI(false));
		if (this.GameState.FinishStatus == DDRFinishStatus.Complete)
		{
			this.endScreen.gameObject.SetActive(true);
			this.ddrMinigame.UpdateEndcard(this.GameState);
		}
		else
		{
			this.defeatScreen.SetActive(true);
		}
		this.target = this.screenPoint;
		this.LoadedLevel = null;
		this.ddrMinigame.UnloadLevelSelect();
		yield return new WaitForSecondsRealtime(2f);
		base.StartCoroutine(this.fade(true, this.continueText, 1f));
		while (!Input.anyKeyDown || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
		{
			yield return null;
		}
		this.ddrMinigame.Unload();
		this.onLevelFinish(this.GameState.FinishStatus);
		yield break;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000024E7 File Offset: 0x000006E7
	private IEnumerator fadeGameUI(bool fadein)
	{
		float destination = (float)(fadein ? 1 : 0);
		float amount = (float)(fadein ? 0 : 1);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, 10f * Time.deltaTime);
			foreach (RawImage rawImage in this.overlayImages)
			{
				Color color = rawImage.color;
				color.a = amount;
				rawImage.color = color;
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000024FD File Offset: 0x000006FD
	private IEnumerator fade(bool fadein, MaskableGraphic graphic, float speed = 1f)
	{
		float destination = (float)(fadein ? 1 : 0);
		float amount = (float)(fadein ? 0 : 1);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, speed * Time.deltaTime);
			Color color = graphic.color;
			color.a = amount;
			graphic.color = color;
			yield return null;
		}
		yield break;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000251A File Offset: 0x0000071A
	private void onLevelFinish(DDRFinishStatus status)
	{
		this.BootOut();
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002524 File Offset: 0x00000724
	public void ReturnToNormalGameplay()
	{
		Debug.Log("ReturnToNormalGameplay() was called.");
		this.yandereAnim["f02_danceMachineIdle_00"].weight = 0f;
		this.yandereAnim["f02_danceRight_00"].weight = 0f;
		this.yandereAnim["f02_danceLeft_00"].weight = 0f;
		this.yandereAnim["f02_danceUp_00"].weight = 0f;
		this.yandereAnim["f02_danceDown_00"].weight = 0f;
		this.Yandere.transform.position = this.FinishLocation.position;
		this.Yandere.transform.rotation = this.FinishLocation.rotation;
		this.Yandere.StudentManager.Clock.StopTime = false;
		this.Yandere.MyController.enabled = true;
		this.Yandere.StudentManager.ComeBack();
		this.Yandere.CanMove = true;
		this.Yandere.enabled = true;
		this.Yandere.HeartCamera.enabled = true;
		this.Yandere.HUD.enabled = true;
		this.Yandere.HUD.transform.parent.gameObject.SetActive(true);
		this.Yandere.MainCamera.gameObject.SetActive(true);
		this.Yandere.Jukebox.Volume = this.Yandere.Jukebox.LastVolume;
		this.OriginalRenderer.enabled = true;
		Physics.SyncTransforms();
		base.transform.parent.gameObject.SetActive(false);
	}

	// Token: 0x0400000B RID: 11
	public GameState GameState;

	// Token: 0x0400000C RID: 12
	public YandereScript Yandere;

	// Token: 0x0400000D RID: 13
	public Transform FinishLocation;

	// Token: 0x0400000E RID: 14
	public Renderer OriginalRenderer;

	// Token: 0x0400000F RID: 15
	public GameObject OverlayCanvas;

	// Token: 0x04000010 RID: 16
	public GameObject GameUI;

	// Token: 0x04000011 RID: 17
	[Header("General")]
	public DDRLevel LoadedLevel;

	// Token: 0x04000012 RID: 18
	[SerializeField]
	private DDRLevel[] levels;

	// Token: 0x04000013 RID: 19
	[SerializeField]
	private InputManagerScript inputManager;

	// Token: 0x04000014 RID: 20
	[SerializeField]
	private DDRMinigame ddrMinigame;

	// Token: 0x04000015 RID: 21
	[SerializeField]
	private AudioSource audioSource;

	// Token: 0x04000016 RID: 22
	[SerializeField]
	private Transform standPoint;

	// Token: 0x04000017 RID: 23
	[SerializeField]
	private float transitionSpeed = 2f;

	// Token: 0x04000018 RID: 24
	[Header("Camera")]
	[SerializeField]
	private Transform minigameCamera;

	// Token: 0x04000019 RID: 25
	[SerializeField]
	private Transform startPoint;

	// Token: 0x0400001A RID: 26
	[SerializeField]
	private Transform screenPoint;

	// Token: 0x0400001B RID: 27
	[SerializeField]
	private Transform watchPoint;

	// Token: 0x0400001C RID: 28
	[Header("Animation")]
	[SerializeField]
	private Animation machineScreenAnimation;

	// Token: 0x0400001D RID: 29
	[SerializeField]
	private Animation yandereAnim;

	// Token: 0x0400001E RID: 30
	[Header("UI")]
	[SerializeField]
	private Image fadeImage;

	// Token: 0x0400001F RID: 31
	[SerializeField]
	private RawImage[] overlayImages;

	// Token: 0x04000020 RID: 32
	[SerializeField]
	private VideoPlayer backgroundVideo;

	// Token: 0x04000021 RID: 33
	[SerializeField]
	private Transform levelSelect;

	// Token: 0x04000022 RID: 34
	[SerializeField]
	private GameObject endScreen;

	// Token: 0x04000023 RID: 35
	[SerializeField]
	private GameObject defeatScreen;

	// Token: 0x04000024 RID: 36
	[SerializeField]
	private Text continueText;

	// Token: 0x04000025 RID: 37
	[SerializeField]
	private ColorCorrectionCurves gameplayColorCorrection;

	// Token: 0x04000026 RID: 38
	private Transform target;

	// Token: 0x04000027 RID: 39
	private bool booted;

	// Token: 0x04000028 RID: 40
	public bool DebugMode;

	// Token: 0x04000029 RID: 41
	public bool CheckingForEnd;
}
