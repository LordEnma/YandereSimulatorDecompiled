// Decompiled with JetBrains decompiler
// Type: OsanaWarningScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

public class OsanaWarningScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public Transform RightHand;
  public UISprite Darkness;
  public float Alpha = 1f;
  public bool FadeOut;

  private void Start()
  {
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, 1f);
    ColorGradingModel.Settings settings1 = this.Profile.colorGrading.settings;
    settings1.basic.saturation = 1f;
    settings1.channelMixer.red = new Vector3(1f, 0.0f, 0.0f);
    settings1.channelMixer.green = new Vector3(0.0f, 1f, 0.0f);
    settings1.channelMixer.blue = new Vector3(0.0f, 0.0f, 1f);
    this.Profile.colorGrading.settings = settings1;
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = 10f,
      aperture = 11.2f
    };
    BloomModel.Settings settings2 = this.Profile.bloom.settings;
    settings2.bloom.intensity = 1f;
    this.Profile.bloom.settings = settings2;
  }

  private void Update()
  {
    this.Alpha = !this.FadeOut ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
    this.Darkness.color = new Color(0.0f, 0.0f, 0.0f, this.Alpha);
    if ((double) this.Alpha == 0.0)
    {
      if (!Input.GetButtonDown("A"))
        return;
      this.FadeOut = true;
    }
    else
    {
      if ((double) this.Alpha != 1.0)
        return;
      SceneManager.LoadScene("CalendarScene");
    }
  }

  private void LateUpdate() => this.RightHand.localEulerAngles += new Vector3(Random.Range(1f, -1f), Random.Range(1f, -1f), Random.Range(1f, -1f));
}
