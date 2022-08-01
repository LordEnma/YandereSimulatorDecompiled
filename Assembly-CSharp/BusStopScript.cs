// Decompiled with JetBrains decompiler
// Type: BusStopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class BusStopScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public RiggedAccessoryAttacher BakerAttacher;
  public RiggedAccessoryAttacher Attacher;
  public SkinnedMeshRenderer BakerSenpaiRenderer;
  public SkinnedMeshRenderer NewSenpaiRenderer;
  public SkinnedMeshRenderer SenpaiRenderer;
  public CosmeticScript Cosmetic;
  public Texture CasualClothes;
  public MeshRenderer Renderer;
  public Animation SenpaiAnim;
  public AudioSource MeetingJukebox;
  public AudioSource DoomJukebox;
  public UILabel Subtitle;
  public UISprite SkipCircle;
  public UIPanel SkipPanel;
  public Animation BakerySenpai;
  public Animation BakeryAmai;
  public Animation SecondAmai;
  public Animation ThirdAmai;
  public Animation InfoChan;
  public Animation NewSenpaiAnim;
  public Animation NewAmaiAnim;
  public Transform SenpaiLeftHand;
  public Transform AmaiRightHand;
  public Transform AmaiLeftHand;
  public Transform CupcakeBox;
  public Transform DonutLid;
  public Transform Cupcake;
  public Transform Target;
  public Transform Hips;
  public Transform[] SenpaiBrow;
  public Transform[] SenpaiLip;
  public GameObject UtilityPole;
  public GameObject Amai;
  public Mesh CasualMesh;
  public int RivalEliminationID;
  public int ShockPhase;
  public int SpeechID;
  public int Phase = 1;
  public float BakeryFocus;
  public float ExtraTimer;
  public float AnimTimer;
  public float TimeLimit;
  public float SkipTimer;
  public float Rotation;
  public float Alpha;
  public float Speed;
  public float Timer;
  public float DOF;
  public float RotationX;
  public float RotationY;
  public float RotationZ;
  public bool EndEarly;
  public bool InBakery;
  public bool TreeShot;
  public bool CloseUp;
  public bool NoAnim;
  public AudioClip[] OsanaEliminations;
  public AudioClip[] Speech;
  public AudioSource Audio;
  public string[] EliminationDescriptions;
  public string[] Subtitles;
  public bool Smile;
  public float Strength;
  public float LipValue = -0.08f;

  private void Start()
  {
    this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.transform.position = new Vector3(0.375f, 0.5f, 2.5f);
    this.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
    this.SecondAmai.gameObject.SetActive(false);
    this.ThirdAmai.gameObject.SetActive(false);
    this.SenpaiAnim["sadFace_00"].layer = 1;
    this.SenpaiAnim.Play("sadFace_00");
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = 1.2f,
      aperture = 5.6f
    };
    this.Subtitle.text = "";
    if (GameGlobals.RivalEliminationID == 0)
    {
      GameGlobals.RivalEliminationID = 1;
      GameGlobals.SpecificEliminationID = 1;
      GameGlobals.NonlethalElimination = false;
    }
    this.RivalEliminationID = GameGlobals.RivalEliminationID;
    Debug.Log((object) ("GameGlobals.RivalEliminationID is: " + GameGlobals.RivalEliminationID.ToString()));
  }

  private void Update()
  {
    this.SkipTimer += Time.deltaTime;
    if ((double) this.SkipTimer > 5.0)
      this.SkipPanel.alpha -= Time.deltaTime;
    if (this.EndEarly)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
      this.SkipPanel.alpha -= Time.deltaTime;
      this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.Subtitle.text = "";
      if ((double) this.Alpha == 1.0)
        this.ExitCutscene();
    }
    else if (Input.GetButton("X"))
    {
      this.SkipPanel.alpha = 1f;
      this.SkipTimer = 0.0f;
      this.SkipCircle.fillAmount -= Time.deltaTime;
      if ((double) this.SkipCircle.fillAmount == 0.0)
        this.EndEarly = true;
    }
    else
      this.SkipCircle.fillAmount = 1f;
    this.Audio.pitch = Time.timeScale;
    if (this.Phase > 1 && this.Phase < 4)
    {
      this.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
      this.Speed += Time.deltaTime * 0.1f;
      this.Rotation = Mathf.Lerp(this.Rotation, -150f, Time.deltaTime * this.Speed);
      this.transform.eulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
    }
    if (this.Phase > 7 && this.Phase < 11)
      this.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
    if (this.Phase == 1)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.2f);
      this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.MeetingJukebox.volume = (float) ((1.0 - (double) this.Alpha) * 0.100000001490116);
      if ((double) this.Alpha == 0.0)
      {
        if (this.SpeechID == 0)
        {
          this.Subtitle.text = this.Subtitles[0];
          this.Audio.clip = this.Speech[0];
          this.Audio.Play();
          ++this.SpeechID;
        }
        else
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 6.0)
            this.Subtitle.text = "";
        }
      }
      if ((UnityEngine.Object) this.SenpaiRenderer.sharedMesh != (UnityEngine.Object) this.CasualMesh)
      {
        this.SenpaiRenderer.sharedMesh = this.CasualMesh;
        this.SenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
        this.SenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
        this.SenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
      }
      if ((UnityEngine.Object) this.NewSenpaiRenderer.sharedMesh != (UnityEngine.Object) this.CasualMesh)
      {
        this.NewSenpaiRenderer.sharedMesh = this.CasualMesh;
        this.NewSenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
        this.NewSenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
        this.NewSenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
      }
      if ((UnityEngine.Object) this.BakerSenpaiRenderer.sharedMesh != (UnityEngine.Object) this.CasualMesh)
      {
        this.BakerSenpaiRenderer.sharedMesh = this.CasualMesh;
        this.BakerSenpaiRenderer.materials[0].mainTexture = this.CasualClothes;
        this.BakerSenpaiRenderer.materials[1].mainTexture = this.Cosmetic.FaceTextures[this.Cosmetic.SkinColor];
        this.BakerSenpaiRenderer.materials[2].mainTexture = this.Cosmetic.SkinTextures[this.Cosmetic.SkinColor];
      }
      this.transform.position += new Vector3(0.0f, 0.0f, this.Speed * Time.deltaTime);
      this.Amai.transform.position -= new Vector3(1f * Time.deltaTime, 0.0f, 0.0f);
      if ((double) this.Amai.transform.position.x < -2.0)
      {
        this.SecondAmai.gameObject.SetActive(true);
        if ((double) this.SecondAmai["f02_motherRecipe_00"].speed == 1.0)
        {
          this.SecondAmai["f02_motherRecipe_00"].speed = 0.66666f;
          this.SecondAmai["f02_motherRecipe_00"].time = 16f;
          this.SecondAmai["f02_carry_00"].layer = 1;
          this.SecondAmai.Play("f02_carry_00");
        }
      }
      if ((double) this.Amai.transform.position.x < -10.0)
      {
        this.UpdateDOF(1f);
        this.transform.position = new Vector3(0.55f, 1f, 1.55f);
        this.transform.eulerAngles = new Vector3(0.0f, -135f, 0.0f);
        this.SenpaiAnim.transform.parent.gameObject.SetActive(false);
        this.SecondAmai.gameObject.SetActive(false);
        this.NewSenpaiAnim.gameObject.SetActive(true);
        this.NewAmaiAnim.gameObject.SetActive(true);
        this.Amai.gameObject.SetActive(false);
        this.Rotation = -125f;
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 2)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.0 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[1];
        this.Audio.clip = this.Speech[1];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 5.0)
        this.CupcakeBox.transform.localPosition = Vector3.MoveTowards(this.CupcakeBox.transform.localPosition, new Vector3(-0.02f, 0.05f, 0.25f), Time.deltaTime * 0.1f);
      else if ((double) this.Timer > 4.0)
      {
        if ((UnityEngine.Object) this.CupcakeBox.parent != (UnityEngine.Object) this.Hips)
        {
          this.CupcakeBox.parent = this.Hips;
          this.RotationX = this.CupcakeBox.transform.localEulerAngles.x;
          this.RotationY = this.CupcakeBox.transform.localEulerAngles.y;
          this.RotationZ = this.CupcakeBox.transform.localEulerAngles.z;
        }
        this.CupcakeBox.transform.localPosition = Vector3.MoveTowards(this.CupcakeBox.transform.localPosition, new Vector3(-0.05f, 0.05f, 0.25f), Time.deltaTime * 0.25f);
        this.RotationX = Mathf.MoveTowards(this.RotationX, 375f, Time.deltaTime * 90f);
        this.RotationY = Mathf.MoveTowards(this.RotationY, 360f, Time.deltaTime * 90f);
        this.RotationZ = Mathf.MoveTowards(this.RotationZ, 0.0f, Time.deltaTime * 90f);
        this.CupcakeBox.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
      }
      if ((double) this.Timer > 6.0)
      {
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 3)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5)
        this.Subtitle.text = this.Subtitles[2];
      if ((double) this.Timer > 7.5)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, 150f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 4)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[3];
        this.Audio.clip = this.Speech[2];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 6.0)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, -150f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 5)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.0 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[4];
        this.Audio.clip = this.Speech[3];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 2.0 && this.SpeechID == 1)
      {
        this.Subtitle.text = this.Subtitles[5];
        ++this.SpeechID;
      }
      if ((double) this.Timer > 6.75 && this.SpeechID == 2)
      {
        this.Subtitle.text = this.Subtitles[6];
        ++this.SpeechID;
      }
      if ((double) this.Timer > 16.75 && this.SpeechID == 3)
      {
        this.Subtitle.text = this.Subtitles[7];
        ++this.SpeechID;
      }
      if ((double) this.Timer > 20.0)
      {
        this.UpdateDOF(0.75f);
        this.transform.position = new Vector3(0.0f, 1f, 0.0f);
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        this.UtilityPole.SetActive(false);
        this.NewSenpaiAnim["SenpaiMeet_1"].time = this.NewSenpaiAnim["SenpaiMeet_1"].length - 4f;
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Speed = 0.0f;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 6)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 5.0 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.EliminationDescriptions[this.RivalEliminationID];
        this.Audio.clip = this.OsanaEliminations[this.RivalEliminationID];
        this.Audio.Play();
        this.TimeLimit = this.OsanaEliminations[this.RivalEliminationID].length;
        ++this.SpeechID;
      }
      if ((double) this.NewSenpaiAnim["SenpaiMeet_1"].time >= (double) this.NewSenpaiAnim["SenpaiMeet_1"].length)
      {
        this.NewSenpaiAnim.CrossFade("SenpaiMeet_2");
        this.NewAmaiAnim.CrossFade("AmaiMeet_2");
      }
      if (this.ShockPhase == 0)
      {
        if ((double) this.Timer > 9.5)
        {
          this.NewAmaiAnim.CrossFade("AmaiShock_1");
          ++this.ShockPhase;
        }
      }
      else if (this.ShockPhase == 1)
      {
        if ((double) this.NewAmaiAnim["AmaiShock_1"].time >= (double) this.NewAmaiAnim["AmaiShock_1"].length)
        {
          this.NewAmaiAnim.CrossFade("AmaiShock_2");
          this.ShockPhase = 2;
        }
      }
      else if (this.ShockPhase == 2 && (double) this.Timer > (double) this.TimeLimit + 4.0)
      {
        this.NewAmaiAnim["AmaiShock_1"].time = 0.0f;
        this.NewAmaiAnim["AmaiShock_1"].speed = 0.0f;
        this.NewAmaiAnim.CrossFade("AmaiShock_1", 2f);
        this.ShockPhase = 3;
      }
      this.transform.Translate(Vector3.back * Time.deltaTime * 0.01f);
      if ((double) this.Timer > (double) this.TimeLimit + 6.0)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, -150f, 0.0f);
        this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.05f, 0.25f);
        this.CupcakeBox.localEulerAngles = new Vector3(15f, 0.0f, 0.0f);
        this.CupcakeBox.localScale = new Vector3(0.133333f, 0.15f, 0.15f);
        this.NewSenpaiAnim.CrossFade("SenpaiMeet_3");
        this.NewAmaiAnim.CrossFade("AmaiMeet_3");
        this.UtilityPole.SetActive(true);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 7)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[8];
        this.Audio.clip = this.Speech[4];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 13.0)
      {
        this.UpdateDOF(1f);
        this.transform.position = new Vector3(0.0f, 1f, 2f);
        this.transform.eulerAngles = new Vector3(0.0f, 180f, 0.0f);
        this.NewSenpaiAnim.transform.parent.transform.position = new Vector3(-0.1f, 0.0f, 0.0f);
        this.NewSenpaiAnim["SenpaiMeet_3"].time += 0.25f;
        this.NewAmaiAnim["AmaiMeet_3"].time += 0.25f;
        this.Rotation = -90f;
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 8)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[9];
        this.Audio.clip = this.Speech[5];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.NewAmaiAnim["AmaiMeet_3"].time > 15.75)
      {
        this.Rotation = Mathf.MoveTowards(this.Rotation, -20.5f, Time.deltaTime * 100f);
        this.DonutLid.localEulerAngles = new Vector3(this.Rotation, 180f, 180f);
      }
      if ((double) this.Timer > 8.5)
      {
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 9)
    {
      this.transform.Translate(0.0f, 0.0f, Time.deltaTime * -0.01f);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[10];
        this.Audio.clip = this.Speech[6];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 5.0 && this.SpeechID == 1)
      {
        this.Subtitle.text = this.Subtitles[11];
        this.Audio.clip = this.Speech[7];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.NewSenpaiAnim["SenpaiMeet_3"].time > 28.0)
      {
        if ((UnityEngine.Object) this.Cupcake.parent != (UnityEngine.Object) this.SenpaiLeftHand)
          this.Cupcake.parent = this.SenpaiLeftHand;
        this.Cupcake.localPosition = Vector3.MoveTowards(this.Cupcake.localPosition, new Vector3(-0.02f, -0.02f, 0.0f), Time.deltaTime);
        this.Cupcake.transform.localEulerAngles = new Vector3(-15f, -15f, 0.0f);
      }
      if ((double) this.Timer > 8.5)
      {
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 10)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[12];
        this.Audio.clip = this.Speech[8];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 4.5 && this.SpeechID == 1)
      {
        this.Subtitle.text = this.Subtitles[13];
        this.Audio.clip = this.Speech[9];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.NewAmaiAnim["AmaiMeet_3"].time > 35.75)
      {
        this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 100f);
        this.DonutLid.localEulerAngles = new Vector3(this.Rotation, 180f, 180f);
      }
      if ((double) this.Timer > 9.5)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, -150f, 0.0f);
        this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
        this.CupcakeBox.localEulerAngles = new Vector3(15f, 0.0f, 0.0f);
        this.NewSenpaiAnim.transform.parent.transform.position = new Vector3(0.1f, 0.0f, 0.0f);
        this.Subtitle.text = this.Subtitles[14];
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 11)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 9.0)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, 150f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 12)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[15];
        this.Audio.clip = this.Speech[10];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 7.0)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, -150f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 13)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[16];
        this.Audio.clip = this.Speech[11];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 6.5)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, 150f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 14)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 0.5 && this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[17];
        this.Audio.clip = this.Speech[12];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.Timer > 11.5)
      {
        this.UpdateDOF(0.66666f);
        this.transform.position = new Vector3(0.0f, 1f, 1.5f);
        this.transform.eulerAngles = new Vector3(0.0f, -150f, 0.0f);
        this.CupcakeBox.localPosition = new Vector3(-0.025f, 0.0375f, 0.25f);
        this.CupcakeBox.localEulerAngles = new Vector3(15f, 0.0f, 0.0f);
        this.Subtitle.text = "";
        this.SpeechID = 0;
        this.Alpha = 0.0f;
        this.Timer = 0.0f;
        ++this.Phase;
      }
    }
    else if (this.Phase == 15)
    {
      if (this.SpeechID == 0)
      {
        this.Subtitle.text = this.Subtitles[18];
        this.Audio.clip = this.Speech[13];
        this.Audio.Play();
        ++this.SpeechID;
      }
      if ((double) this.NewAmaiAnim["AmaiMeet_3"].time > (double) this.NewAmaiAnim["AmaiMeet_3"].length - 2.0)
      {
        this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
        this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
        this.MeetingJukebox.volume = (float) ((1.0 - (double) this.Alpha) * 0.200000002980232);
        this.Subtitle.text = "";
        if ((double) this.Alpha == 1.0)
        {
          this.Timer += Time.deltaTime;
          if ((double) this.Timer > 1.0)
            this.Phase = 20;
        }
      }
    }
    else if (this.Phase == 20)
    {
      this.transform.position = new Vector3(-0.75f, 1.1f, 7.75f);
      this.transform.eulerAngles = new Vector3(0.0f, 30f, 0.0f);
      this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.Alpha = 1f;
      this.InBakery = true;
      this.BakerySenpai.transform.position = new Vector3(-0.5f, 0.0f, 9f);
      this.BakeryAmai.transform.position = new Vector3(0.5f, 0.0f, 9f);
      this.InfoChan.transform.position = new Vector3(-1.925f, 0.0f, 6.4f);
      this.BakerySenpai.Play();
      this.BakeryAmai.Play();
      this.DoomJukebox.Play();
      this.UpdateDOF(1.2f);
      this.Speed = 0.0f;
      this.Timer = 0.0f;
      ++this.Phase;
    }
    else if (this.Phase == 21)
    {
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 0.5f);
      this.Renderer.material.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 13.5)
      {
        this.LipValue = this.SenpaiLip[0].localPosition.y;
        this.Smile = true;
      }
      if ((double) this.Timer > 15.0)
        this.Speed += Time.deltaTime * 0.1f;
      this.BakeryFocus = Mathf.Lerp(this.BakeryFocus, 1.5f, this.Speed * Time.deltaTime);
      this.UpdateDOF(1.2f);
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(-1.939f, 1.4f, 5.69f), this.Speed * Time.deltaTime);
      if ((double) this.Speed > 1.0)
        this.InfoChan.CrossFade("f02_infoSnapPhoto_00", 1f);
      if ((double) this.Timer > 30.5)
        this.Alpha = 1f;
      if ((double) this.BakerySenpai["bakeryTalk_00"].time >= (double) this.BakerySenpai["bakeryTalk_00"].length - 1.0)
      {
        if ((double) this.Alpha < 1.0)
          this.ExtraTimer += Time.deltaTime;
        this.BakerySenpai.CrossFade("carefreeTalk_02", 1f);
        this.BakeryAmai.CrossFade("f02_carefreeTalk_02", 1f);
        this.BakerySenpai["f02_smile_00"].layer = 1;
        this.BakerySenpai.Play("f02_smile_00");
      }
      if ((double) this.Timer > 35.0)
        this.ExitCutscene();
    }
    this.MeetingJukebox.pitch = Time.timeScale;
    this.DoomJukebox.pitch = Time.timeScale;
  }

  private void LateUpdate()
  {
    this.SenpaiBrow[0].localPosition = new Vector3(-0.025f, 0.025f, 0.0f);
    this.SenpaiBrow[0].localEulerAngles = new Vector3(0.0f, 0.0f, 22.5f);
    this.SenpaiBrow[1].localPosition = new Vector3(0.025f, 0.025f, 0.0f);
    this.SenpaiBrow[1].localEulerAngles = new Vector3(0.0f, 0.0f, -22.5f);
    if (!this.Smile)
      return;
    this.Strength += Time.deltaTime;
    this.LipValue = Mathf.Lerp(this.LipValue, -0.06f, Time.deltaTime * this.Strength);
    this.SenpaiLip[0].localPosition = new Vector3(this.SenpaiLip[0].localPosition.x, this.LipValue, this.SenpaiLip[0].localPosition.z);
    this.SenpaiLip[1].localPosition = new Vector3(this.SenpaiLip[1].localPosition.x, this.LipValue, this.SenpaiLip[1].localPosition.z);
  }

  private void UpdateDOF(float Focus)
  {
    DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings with
    {
      focusDistance = !this.CloseUp ? (!this.TreeShot ? (!this.InBakery ? Focus : Focus) : Focus) : Focus
    };
    settings.focusDistance = Focus;
    this.Profile.depthOfField.settings = settings;
  }

  private void ExitCutscene()
  {
    DateGlobals.Week = 2;
    DateGlobals.PassDays = 0;
    DateGlobals.Weekday = DayOfWeek.Sunday;
    SceneManager.LoadScene("CalendarScene");
  }
}
