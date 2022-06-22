// Decompiled with JetBrains decompiler
// Type: LaptopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LaptopScript : MonoBehaviour
{
  public SkinnedMeshRenderer SCPRenderer;
  public Camera LaptopCamera;
  public JukeboxScript Jukebox;
  public YandereScript Yandere;
  public AudioSource MyAudio;
  public DynamicBone Hair;
  public Transform LaptopScreen;
  public AudioClip ShutDown;
  public GameObject SCP;
  public bool React;
  public bool Off;
  public float[] Cues;
  public string[] Subs;
  public Mesh[] Uniforms;
  public int FirstFrame;
  public float Timer;
  public UILabel EventSubtitle;

  private void Start()
  {
    if (SchoolGlobals.SCP || GameGlobals.AlphabetMode)
    {
      this.LaptopScreen.localScale = Vector3.zero;
      this.LaptopCamera.enabled = false;
      this.SCP.SetActive(false);
      this.enabled = false;
    }
    else
    {
      this.SCPRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
      Animation component = this.SCP.GetComponent<Animation>();
      component["f02_scp_00"].speed = 0.0f;
      component["f02_scp_00"].time = 0.0f;
      this.MyAudio = this.GetComponent<AudioSource>();
    }
  }

  private void Update()
  {
    if (this.FirstFrame == 2)
      this.LaptopCamera.enabled = false;
    ++this.FirstFrame;
    if (!this.Off)
    {
      Animation component = this.SCP.GetComponent<Animation>();
      if (!this.React)
      {
        if ((double) this.Yandere.transform.position.x > (double) this.transform.position.x + 1.0 && (double) Vector3.Distance(this.Yandere.transform.position, new Vector3(this.transform.position.x, 4f, this.transform.position.z)) < 2.0 && this.Yandere.Followers == 0)
        {
          this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
          component["f02_scp_00"].time = 0.0f;
          this.LaptopCamera.enabled = true;
          component.Play();
          this.Hair.enabled = true;
          this.Jukebox.Dip = 0.5f;
          this.MyAudio.Play();
          this.React = true;
        }
      }
      else
      {
        this.MyAudio.pitch = Time.timeScale;
        this.MyAudio.volume = 1f;
        if ((double) this.Yandere.transform.position.y > (double) this.transform.position.y + 3.0 || (double) this.Yandere.transform.position.y < (double) this.transform.position.y - 3.0)
          this.MyAudio.volume = 0.0f;
        for (int index = 0; index < this.Cues.Length; ++index)
        {
          if ((double) this.MyAudio.time > (double) this.Cues[index])
            this.EventSubtitle.text = this.Subs[index];
        }
        if ((double) this.MyAudio.time >= (double) this.MyAudio.clip.length - 1.0 || (double) this.MyAudio.time == 0.0)
        {
          component["f02_scp_00"].speed = 1f;
          this.Timer += Time.deltaTime;
        }
        else
          component["f02_scp_00"].time = this.MyAudio.time;
        if ((double) this.Timer > 1.0 || (double) Vector3.Distance(this.Yandere.transform.position, new Vector3(this.transform.position.x, 4f, this.transform.position.z)) > 5.0)
          this.TurnOff();
      }
      if ((double) this.Yandere.StudentManager.Clock.HourTime <= 16.0 && !this.Yandere.Police.FadeOut)
        return;
      this.TurnOff();
    }
    else if ((double) this.LaptopScreen.localScale.x > 0.100000001490116)
    {
      this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else
    {
      if (!this.enabled)
        return;
      this.LaptopScreen.localScale = Vector3.zero;
      this.Hair.enabled = false;
      this.enabled = false;
    }
  }

  private void TurnOff()
  {
    this.MyAudio.clip = this.ShutDown;
    this.MyAudio.Play();
    this.EventSubtitle.text = string.Empty;
    SchoolGlobals.SCP = true;
    this.LaptopCamera.enabled = false;
    this.Jukebox.Dip = 1f;
    this.React = false;
    this.Off = true;
  }
}
