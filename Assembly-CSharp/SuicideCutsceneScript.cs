// Decompiled with JetBrains decompiler
// Type: SuicideCutsceneScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
    this.PointLight.color = new Color(0.1f, 0.1f, 0.1f, 1f);
    this.Door.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    if (!GameGlobals.Eighties)
      return;
    this.MyAudio.clip = this.EightiesMother;
    this.RivalHair[1].SetActive(false);
    this.EightiesHair[DateGlobals.Week].SetActive(true);
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (this.ID == 0)
    {
      if ((double) this.Timer <= 1.0)
        return;
      this.MyAudio.Play();
      ++this.ID;
    }
    else
    {
      if (this.ID != 1)
        return;
      if ((double) this.Timer > 6.0)
      {
        this.Speed += Time.deltaTime * 0.66666f;
        this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
        this.PointLight.color = new Color((float) (0.100000001490116 + (double) this.Rotation / -45.0 * 0.899999976158142), (float) (0.100000001490116 + (double) this.Rotation / -45.0 * 0.899999976158142), (float) (0.100000001490116 + (double) this.Rotation / -45.0 * 0.899999976158142), 1f);
        this.Door.eulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
      }
      if ((double) this.Timer > 8.5)
        this.Mom.CrossFade("f02_shock_00");
      if ((double) this.Timer > 9.5)
      {
        this.DirectionalLight.color = new Color(0.0f, 0.0f, 0.0f);
        this.PointLight.color = new Color(0.0f, 0.0f, 0.0f);
      }
      if ((double) this.Timer <= 11.0)
        return;
      GameGlobals.SpecificEliminationID = 19;
      if (!GameGlobals.Debug)
        PlayerPrefs.SetInt("Suicide", 1);
      SchoolGlobals.SchoolAtmosphere -= 0.1f;
      GameGlobals.SenpaiMourning = true;
      SceneManager.LoadScene("HomeScene");
    }
  }
}
