// Decompiled with JetBrains decompiler
// Type: DDRManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    this.minigameCamera.position = this.startPoint.position;
    if (!this.DebugMode)
      return;
    this.BeginMinigame();
  }

  public void Update()
  {
    this.minigameCamera.position = Vector3.Slerp(this.minigameCamera.position, this.target.position, this.transitionSpeed * Time.deltaTime);
    this.minigameCamera.rotation = Quaternion.Slerp(this.minigameCamera.rotation, this.target.rotation, this.transitionSpeed * Time.deltaTime);
    if ((Object) this.target == (Object) null)
      return;
    Vector3 position = this.standPoint.position;
    if ((Object) this.LoadedLevel != (Object) null)
    {
      this.ddrMinigame.UpdateGame(this.audioSource.time);
      this.GameState.Health -= Time.deltaTime;
      this.GameState.Health = Mathf.Clamp(this.GameState.Health, 0.0f, 100f);
      if (this.inputManager.TappedLeft)
      {
        this.yandereAnim["f02_danceLeft_00"].time = 0.0f;
        this.yandereAnim.Play("f02_danceLeft_00");
      }
      else if (this.inputManager.TappedDown)
      {
        this.yandereAnim["f02_danceDown_00"].time = 0.0f;
        this.yandereAnim.Play("f02_danceDown_00");
      }
      if (this.inputManager.TappedRight)
      {
        this.yandereAnim["f02_danceRight_00"].time = 0.0f;
        this.yandereAnim.Play("f02_danceRight_00");
      }
      else if (this.inputManager.TappedUp)
      {
        this.yandereAnim["f02_danceUp_00"].time = 0.0f;
        this.yandereAnim.Play("f02_danceUp_00");
      }
    }
    this.yandereAnim.transform.position = Vector3.Lerp(this.yandereAnim.transform.position, position, 10f * Time.deltaTime);
    if (this.CheckingForEnd && !this.audioSource.isPlaying)
    {
      this.OverlayCanvas.SetActive(false);
      this.GameUI.SetActive(false);
      this.CheckingForEnd = false;
      Debug.Log((object) "End() was called because song ended.");
      this.StartCoroutine(this.End());
    }
    if ((double) this.GameState.Health > 0.0 || (double) this.audioSource.pitch >= 0.0099999997764825821)
      return;
    this.OverlayCanvas.SetActive(false);
    this.GameUI.SetActive(false);
    if (!this.audioSource.isPlaying)
      return;
    Debug.Log((object) "End() was called because we ran out of health.");
    this.StartCoroutine(this.End());
  }

  public void BeginMinigame()
  {
    Debug.Log((object) "BeginMinigame() was called.");
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
    this.StartCoroutine(this.minigameFlow());
    this.YandereListener.enabled = false;
  }

  public void BootOut()
  {
    this.minigameCamera.position = this.startPoint.position;
    this.StartCoroutine(this.fade(true, (MaskableGraphic) this.fadeImage, 5f));
    this.target = this.startPoint;
    this.ddrMinigame.UnloadLevelSelect();
    this.ReturnToNormalGameplay();
  }

  private IEnumerator minigameFlow()
  {
    DDRManager ddrManager = this;
    ddrManager.levelSelect.gameObject.SetActive(true);
    ddrManager.defeatScreen.gameObject.SetActive(false);
    ddrManager.endScreen.gameObject.SetActive(false);
    ddrManager.audioSource.pitch = 1f;
    ddrManager.target = ddrManager.screenPoint;
    if (!ddrManager.booted)
    {
      yield return (object) new WaitForSecondsRealtime(0.2f);
      ddrManager.StartCoroutine(ddrManager.fade(false, (MaskableGraphic) ddrManager.fadeImage));
      while ((double) ddrManager.fadeImage.color.a > 0.40000000596046448)
        yield return (object) null;
      ddrManager.machineScreenAnimation.Play();
      ddrManager.booted = true;
    }
    yield return (object) new WaitForEndOfFrame();
    while ((double) Input.GetAxis("A") != 0.0)
      yield return (object) null;
    while ((Object) ddrManager.LoadedLevel == (Object) null)
    {
      ddrManager.ddrMinigame.UpdateLevelSelect();
      yield return (object) null;
    }
    ddrManager.ddrMinigame.LoadLevel(ddrManager.LoadedLevel);
    ddrManager.GameState = new GameState();
    yield return (object) new WaitForSecondsRealtime(0.2f);
    ddrManager.transitionSpeed *= 2f;
    ddrManager.target = ddrManager.watchPoint;
    ddrManager.backgroundVideo.Play();
    ddrManager.backgroundVideo.playbackSpeed = 0.0f;
    ddrManager.StartCoroutine(ddrManager.fadeGameUI(true));
    ddrManager.backgroundVideo.playbackSpeed = 1f;
    ddrManager.audioSource.clip = ddrManager.LoadedLevel.Song;
    ddrManager.audioSource.time = 0.0f;
    ddrManager.audioSource.Play();
    ddrManager.CheckingForEnd = true;
    while ((double) ddrManager.audioSource.time < (double) ddrManager.audioSource.clip.length)
    {
      if ((double) ddrManager.GameState.Health <= 0.0)
      {
        ddrManager.GameState.FinishStatus = DDRFinishStatus.Failed;
        while ((double) ddrManager.audioSource.pitch > 0.0)
        {
          ddrManager.audioSource.pitch = Mathf.MoveTowards(ddrManager.audioSource.pitch, 0.0f, 0.2f * Time.deltaTime);
          if ((double) ddrManager.audioSource.pitch == 0.0)
          {
            Debug.Log((object) "Pitch reached zero.");
            ddrManager.audioSource.time = ddrManager.audioSource.clip.length;
            ddrManager.OverlayCanvas.SetActive(false);
            ddrManager.GameUI.SetActive(false);
          }
          yield return (object) null;
        }
        break;
      }
      yield return (object) null;
    }
  }

  private IEnumerator End()
  {
    DDRManager ddrManager = this;
    ddrManager.audioSource.Stop();
    ddrManager.levelSelect.gameObject.SetActive(false);
    ddrManager.StopCoroutine(ddrManager.fadeGameUI(true));
    ddrManager.StartCoroutine(ddrManager.fadeGameUI(false));
    if (ddrManager.GameState.FinishStatus == DDRFinishStatus.Complete)
    {
      ddrManager.endScreen.gameObject.SetActive(true);
      ddrManager.ddrMinigame.UpdateEndcard(ddrManager.GameState);
      if ((Object) ddrManager.LoadedLevel != (Object) ddrManager.levels[4] && !GameGlobals.Debug)
      {
        PlayerPrefs.SetInt("Dance", 1);
        PlayerPrefs.SetInt("a", 1);
      }
    }
    else
      ddrManager.defeatScreen.SetActive(true);
    ddrManager.target = ddrManager.screenPoint;
    ddrManager.LoadedLevel = (DDRLevel) null;
    ddrManager.ddrMinigame.UnloadLevelSelect();
    yield return (object) new WaitForSecondsRealtime(2f);
    ddrManager.StartCoroutine(ddrManager.fade(true, (MaskableGraphic) ddrManager.continueText));
    while (!Input.anyKeyDown || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
      yield return (object) null;
    ddrManager.ddrMinigame.Unload();
    ddrManager.onLevelFinish(ddrManager.GameState.FinishStatus);
  }

  private IEnumerator fadeGameUI(bool fadein)
  {
    float destination = fadein ? 1f : 0.0f;
    float amount = fadein ? 0.0f : 1f;
    while ((double) amount != (double) destination)
    {
      amount = Mathf.Lerp(amount, destination, 10f * Time.deltaTime);
      foreach (RawImage overlayImage in this.overlayImages)
      {
        Color color = overlayImage.color with
        {
          a = amount
        };
        overlayImage.color = color;
      }
      yield return (object) null;
    }
  }

  private IEnumerator fade(bool fadein, MaskableGraphic graphic, float speed = 1f)
  {
    float destination = fadein ? 1f : 0.0f;
    float amount = fadein ? 0.0f : 1f;
    while ((double) amount != (double) destination)
    {
      amount = Mathf.Lerp(amount, destination, speed * Time.deltaTime);
      Color color = graphic.color with { a = amount };
      graphic.color = color;
      yield return (object) null;
    }
  }

  private void onLevelFinish(DDRFinishStatus status) => this.BootOut();

  public void ReturnToNormalGameplay()
  {
    for (int index = 0; index < 4; ++index)
    {
      foreach (Transform transform in (Transform) this.ddrMinigame.uiTracks[index])
      {
        if (transform.gameObject.name != "TrackSymbol")
          Object.Destroy((Object) transform.gameObject);
      }
    }
    Debug.Log((object) "ReturnToNormalGameplay() was called.");
    this.yandereAnim["f02_danceMachineIdle_00"].weight = 0.0f;
    this.yandereAnim["f02_danceRight_00"].weight = 0.0f;
    this.yandereAnim["f02_danceLeft_00"].weight = 0.0f;
    this.yandereAnim["f02_danceUp_00"].weight = 0.0f;
    this.yandereAnim["f02_danceDown_00"].weight = 0.0f;
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
    this.transform.parent.gameObject.SetActive(false);
    this.YandereListener.enabled = true;
    this.continueText.color = new Color(1f, 1f, 1f, 0.0f);
  }
}
