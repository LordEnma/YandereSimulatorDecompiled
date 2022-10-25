// Decompiled with JetBrains decompiler
// Type: HeartbrokenCursorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartbrokenCursorScript : MonoBehaviour
{
  public SnappedYandereScript SnappedYandere;
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public HeartbrokenScript Heartbroken;
  public VibrateScript[] Vibrations;
  public UISprite CursorSprite;
  public UISprite Darkness;
  public AudioClip SelectSound;
  public AudioClip MoveSound;
  public AudioSource MyAudio;
  public UILabel Continue;
  public UILabel MyLabel;
  public GameObject FPS;
  public bool LoveSick;
  public bool FadeOut;
  public bool Nudge;
  public int CracksSpawned;
  public int Selected = 1;
  public int Options = 5;
  public int LastRandomCrack;
  public int RandomCrack;
  public CameraFilterPack_Gradients_FireGradient HeartbrokenFilter;
  public CameraFilterPack_Gradients_FireGradient MainFilter;
  public Camera HeartbrokenCamera;
  public AudioSource GameOverMusic;
  public AudioSource SnapStatic;
  public AudioSource SnapMusic;
  public AudioClip GlassShatter;
  public AudioClip ReverseHit;
  public AudioClip[] CrackSound;
  public GameObject ShatterPrefab;
  public GameObject SNAPLetters;
  public GameObject SnapUICamera;
  public UIPanel SNAPPanel;
  public GameObject[] Background;
  public GameObject[] CrackMeshes;
  public GameObject[] Cracks;
  public AudioClip[] CracksTier1;
  public AudioClip[] CracksTier2;
  public AudioClip[] CracksTier3;
  public AudioClip[] CracksTier4;
  public Texture BlackTexture;
  public Transform SnapDestination;
  public Transform SnapFocus;
  public Transform SnapPOV;
  public bool BefriendBetrayMission;
  public bool SnapSequence;
  public bool ReloadScene;
  public bool NeverSnap;
  public float SnapTimer;
  public float Speed;
  public int TwitchID;

  private void Start()
  {
    this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, 0.0f);
    if (!((Object) this.StudentManager != (Object) null))
      return;
    this.StudentManager.Yandere.Jukebox.gameObject.SetActive(false);
    if ((Object) this.StudentManager.Yandere.Weapon[1] != (Object) null && this.StudentManager.Yandere.Weapon[1].Type == WeaponType.Knife)
      this.StudentManager.Yandere.Weapon[1].Drop();
    if ((Object) this.StudentManager.Yandere.Weapon[2] != (Object) null && this.StudentManager.Yandere.Weapon[2].Type == WeaponType.Knife)
      this.StudentManager.Yandere.Weapon[2].Drop();
    this.StudentManager.Journalist.SetActive(false);
  }

  private void Update()
  {
    this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.Lerp(this.transform.localPosition.y, (float) ((double) byte.MaxValue - (double) this.Selected * 50.0), Time.deltaTime * 10f), this.transform.localPosition.z);
    this.GameOverMusic.volume = this.Selected != 5 ? Mathf.MoveTowards(this.GameOverMusic.volume, 1f, Time.deltaTime * 0.5f) : Mathf.MoveTowards(this.GameOverMusic.volume, 0.0f, Time.deltaTime * 0.5f);
    if (!this.FadeOut)
    {
      if ((double) this.MyLabel.color.a >= 1.0)
      {
        if (this.InputManager.TappedDown)
        {
          ++this.Selected;
          if (this.Selected > this.Options)
            this.Selected = 1;
          this.MyAudio.clip = this.MoveSound;
          this.MyAudio.Play();
        }
        if (this.InputManager.TappedUp)
        {
          --this.Selected;
          if (this.Selected < 1)
            this.Selected = this.Options;
          this.MyAudio.clip = this.MoveSound;
          this.MyAudio.Play();
        }
        this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, this.Selected != 5 ? 1f : 0.0f);
        if (Input.GetButtonDown("A"))
        {
          this.Nudge = true;
          if (this.Selected != 5)
          {
            this.MyAudio.clip = this.SelectSound;
            this.MyAudio.Play();
            if (this.Selected == 1 || this.Selected == 2 && (double) this.Heartbroken.Options[1].alpha == 1.0 || this.Selected == 3 && GameGlobals.MostRecentSlot > 0 || this.Selected == 4)
              this.FadeOut = true;
          }
          else
          {
            this.HeartbrokenCamera.nearClipPlane -= 0.1f;
            if ((double) this.HeartbrokenCamera.nearClipPlane <= 0.0)
              this.HeartbrokenCamera.nearClipPlane = 0.01f;
            this.StudentManager.Yandere.ShoulderCamera.enabled = false;
            if (this.CracksSpawned == 0)
            {
              GameObjectUtils.SetLayerRecursively(this.StudentManager.Yandere.gameObject, 5);
              this.Cracks[1].transform.parent.position = this.StudentManager.Yandere.Head.position;
              this.Cracks[1].transform.parent.position = Vector3.MoveTowards(this.Cracks[1].transform.parent.position, this.Heartbroken.transform.parent.position, -1f);
              foreach (Behaviour vibration in this.Vibrations)
                vibration.enabled = false;
              this.Heartbroken.Freeze = true;
            }
            if (this.CracksSpawned < 17)
            {
              this.Heartbroken.Darken();
              while (this.RandomCrack == this.LastRandomCrack)
                this.RandomCrack = Random.Range(0, 3);
              this.LastRandomCrack = this.RandomCrack;
              this.MyAudio.clip = this.CrackSound[this.RandomCrack];
              this.MyAudio.Play();
              ++this.TwitchID;
              if (this.TwitchID > 5)
                this.TwitchID = 0;
              this.StudentManager.Yandere.CharacterAnimation["f02_snapTwitch_0" + this.TwitchID.ToString()].time = 0.1f;
              this.StudentManager.Yandere.CharacterAnimation.Play("f02_snapTwitch_0" + this.TwitchID.ToString());
              this.StudentManager.MainCamera.Translate(this.StudentManager.MainCamera.forward * 0.1f, Space.World);
              this.StudentManager.MainCamera.position = new Vector3(this.StudentManager.MainCamera.position.x, this.StudentManager.MainCamera.position.y - 0.01f, this.StudentManager.MainCamera.position.z);
              int cracksSpawned = this.CracksSpawned;
              while (cracksSpawned == this.CracksSpawned)
              {
                int index = Random.Range(1, this.Cracks.Length);
                if (!this.Cracks[index].activeInHierarchy)
                {
                  this.Cracks[index].SetActive(true);
                  ++this.CracksSpawned;
                }
              }
              if (this.NeverSnap && this.CracksSpawned == 16)
              {
                for (; this.CracksSpawned > 0; --this.CracksSpawned)
                  this.Cracks[this.CracksSpawned].SetActive(false);
              }
              this.StudentManager.SnapSomeStudents();
              this.StudentManager.OpenSomeDoors();
            }
            else
            {
              for (int index = 1; index < this.Cracks.Length; ++index)
              {
                this.Cracks[index].GetComponent<UITexture>().fillAmount = 0.425f;
                this.Cracks[index].SetActive(false);
              }
              this.CracksSpawned = 0;
              this.StudentManager.SelectiveGreyscale.enabled = false;
              this.StudentManager.Yandere.RPGCamera.mouseSpeed = 8f;
              this.StudentManager.Yandere.RPGCamera.distance = 0.566666f;
              this.StudentManager.Yandere.RPGCamera.distanceMax = 0.666666f;
              this.StudentManager.Yandere.RPGCamera.distanceMin = 0.666666f;
              this.StudentManager.Yandere.RPGCamera.desiredDistance = 0.666666f;
              this.StudentManager.Yandere.RPGCamera.mouseX = this.StudentManager.Yandere.transform.eulerAngles.y;
              this.StudentManager.Yandere.RPGCamera.mouseXSmooth = this.StudentManager.Yandere.transform.eulerAngles.y;
              this.StudentManager.Yandere.RPGCamera.mouseY = 15f;
              this.StudentManager.Yandere.RPGCamera.mouseY = 15f;
              this.StudentManager.Yandere.Zoom.OverShoulder = true;
              this.StudentManager.Yandere.Zoom.TargetZoom = 0.4f;
              this.StudentManager.Yandere.Zoom.Zoom = 0.4f;
              this.StudentManager.Yandere.Zoom.enabled = false;
              this.StudentManager.Yandere.RightYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
              this.StudentManager.Yandere.LeftYandereEye.material.color = new Color(1f, 1f, 1f, 1f);
              this.SnapPOV.localPosition = new Vector3(1.25f, 1.546664f, -0.5473595f);
              this.SnapFocus.parent = (Transform) null;
              this.StudentManager.Yandere.MainCamera.enabled = true;
              this.Continue.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              this.MyLabel.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
              this.CursorSprite.enabled = false;
              this.MainFilter.enabled = true;
              this.FPS.SetActive(false);
              this.SnapSequence = true;
              this.MyAudio.clip = this.GlassShatter;
              this.MyAudio.volume = 1f;
              this.MyAudio.Play();
              this.Background[0].SetActive(false);
              this.Background[1].SetActive(false);
              this.SNAPLetters.SetActive(false);
              Time.timeScale = 0.5f;
              ShatterSpawner component = Object.Instantiate<GameObject>(this.ShatterPrefab).GetComponent<ShatterSpawner>();
              component.ScreenMaterial.mainTexture = this.BlackTexture;
              component.ShatterOrigin = new Vector2((float) Screen.width * 0.5f, (float) Screen.height * 0.5f);
              this.StudentManager.Yandere.CharacterAnimation["f02_snapRise_00"].speed = 2f;
              this.StudentManager.Yandere.CharacterAnimation.CrossFade("f02_snapRise_00");
              this.StudentManager.Yandere.enabled = false;
              this.StudentManager.Students[1].Character.SetActive(true);
              this.SnapUICamera.SetActive(true);
              this.StudentManager.SnapSomeStudents();
              this.StudentManager.OpenSomeDoors();
              this.StudentManager.DarkenAllStudents();
              this.StudentManager.Headmaster.gameObject.SetActive(false);
              this.HeartbrokenCamera.nearClipPlane = 0.01f;
            }
          }
        }
      }
      if (this.SnapSequence)
      {
        this.SnapTimer += Time.deltaTime;
        if ((double) this.SnapTimer > 9.0)
        {
          GameObjectUtils.SetLayerRecursively(this.StudentManager.Yandere.gameObject, 13);
          this.StudentManager.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 0.0f;
          this.HeartbrokenCamera.cullingMask = this.StudentManager.Yandere.MainCamera.cullingMask;
          this.HeartbrokenCamera.clearFlags = this.StudentManager.Yandere.MainCamera.clearFlags;
          this.HeartbrokenCamera.farClipPlane = this.StudentManager.Yandere.MainCamera.farClipPlane;
          this.Heartbroken.MainCamera.enabled = false;
          this.StudentManager.Yandere.RPGCamera.transform.parent = this.StudentManager.Yandere.transform;
          this.SnappedYandere.enabled = true;
          this.SnappedYandere.CanMove = true;
          this.SnapStatic.Play();
          this.SnapMusic.Play();
          this.enabled = false;
          this.MyAudio.Stop();
          Debug.Log((object) "The player now has control over Yandere-chan again.");
        }
        else if ((double) this.SnapTimer > 2.0)
        {
          if ((Object) this.MyAudio.clip != (Object) this.ReverseHit)
          {
            this.MyAudio.clip = this.ReverseHit;
            this.MyAudio.time = 1f;
            this.MyAudio.Play();
          }
          Time.timeScale = 1f;
          this.Speed += Time.deltaTime * 0.5f;
          this.SnapPOV.localPosition = Vector3.Lerp(this.SnapPOV.localPosition, new Vector3(0.25f, 1.546664f, -0.5473595f), Time.deltaTime * this.Speed);
          this.StudentManager.MainCamera.position = Vector3.Lerp(this.StudentManager.MainCamera.position, this.SnapPOV.position, Time.deltaTime * this.Speed);
          this.SnapFocus.position = Vector3.Lerp(this.SnapFocus.position, this.SnapDestination.position, Time.deltaTime * this.Speed);
          this.StudentManager.MainCamera.LookAt(this.SnapFocus);
          this.MainFilter.Fade = Mathf.MoveTowards(this.MainFilter.Fade, 0.0f, Time.deltaTime * 0.142857149f);
          this.HeartbrokenFilter.Fade = Mathf.MoveTowards(this.HeartbrokenFilter.Fade, 1f, Time.deltaTime * 0.142857149f);
          this.SnappedYandere.CompressionFX.Parasite = Mathf.MoveTowards(this.SnappedYandere.CompressionFX.Parasite, 1f, Time.deltaTime * 0.142857149f);
          this.SnappedYandere.TiltShift.Size = Mathf.MoveTowards(this.SnappedYandere.TiltShift.Size, 0.75f, Time.deltaTime * 0.142857149f);
          this.SnappedYandere.TiltShiftV.Size = Mathf.MoveTowards(this.SnappedYandere.TiltShiftV.Size, 0.75f, Time.deltaTime * 0.142857149f);
        }
      }
    }
    else
    {
      this.Heartbroken.GetComponent<AudioSource>().volume -= Time.deltaTime;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if ((double) this.Darkness.color.a >= 1.0)
      {
        if (this.Selected == 1)
        {
          if (this.ReloadScene)
          {
            GameGlobals.Debug = false;
            SceneManager.LoadScene(Application.loadedLevel);
          }
          else
          {
            for (int studentID = 0; studentID < this.StudentManager.NPCsTotal; ++studentID)
            {
              if (StudentGlobals.GetStudentDying(studentID))
                StudentGlobals.SetStudentDying(studentID, false);
            }
            SceneManager.LoadScene("LoadingScene");
          }
        }
        else if (this.Selected == 2)
        {
          if (this.ReloadScene)
          {
            SceneManager.LoadScene("HomeScene");
          }
          else
          {
            int profile = GameGlobals.Profile;
            int num = 11;
            int femaleUniform = StudentGlobals.FemaleUniform;
            int maleUniform = StudentGlobals.MaleUniform;
            if (File.Exists(Application.streamingAssetsPath + "/SaveFiles/Profile_" + profile.ToString() + "_Slot_" + num.ToString() + ".yansave"))
            {
              YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
              YanSave.LoadPrefs("Profile_" + profile.ToString() + "_Slot_" + num.ToString());
              Debug.Log((object) ("Successfully loaded the save in Slot #" + num.ToString()));
            }
            else
              Debug.Log((object) ("Attempted to load a save from Slot #" + num.ToString() + ", but apparently it didn't exist."));
            StudentGlobals.SetStudentDead(10 + DateGlobals.Week, false);
            StudentGlobals.SetStudentDying(10 + DateGlobals.Week, false);
            StudentGlobals.FemaleUniform = femaleUniform;
            StudentGlobals.MaleUniform = maleUniform;
            SceneManager.LoadScene("CalendarScene");
          }
        }
        else if (this.Selected == 3)
        {
          if (this.BefriendBetrayMission)
          {
            SceneManager.LoadScene("NewTitleScene");
          }
          else
          {
            PlayerPrefs.SetInt("LoadingSave", 1);
            PlayerPrefs.SetInt("SaveSlot", GameGlobals.MostRecentSlot);
            for (int studentID = 0; studentID < this.StudentManager.NPCsTotal; ++studentID)
            {
              if (StudentGlobals.GetStudentDying(studentID))
                StudentGlobals.SetStudentDying(studentID, false);
            }
            SceneManager.LoadScene("LoadingScene");
          }
        }
        else if (this.Selected == 4)
          SceneManager.LoadScene("NewTitleScene");
      }
    }
    if (this.Nudge)
    {
      this.transform.localPosition = new Vector3(this.transform.localPosition.x + Time.deltaTime * 250f, this.transform.localPosition.y, this.transform.localPosition.z);
      if ((double) this.transform.localPosition.x <= -225.0)
        return;
      this.transform.localPosition = new Vector3(-225f, this.transform.localPosition.y, this.transform.localPosition.z);
      this.Nudge = false;
    }
    else
    {
      this.transform.localPosition = new Vector3(this.transform.localPosition.x - Time.deltaTime * 250f, this.transform.localPosition.y, this.transform.localPosition.z);
      if ((double) this.transform.localPosition.x >= -250.0)
        return;
      this.transform.localPosition = new Vector3(-250f, this.transform.localPosition.y, this.transform.localPosition.z);
    }
  }
}
