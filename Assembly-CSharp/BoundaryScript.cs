// Decompiled with JetBrains decompiler
// Type: BoundaryScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
  public TextureCycleScript TextureCycle;
  public Transform Yandere;
  public UITexture Static;
  public UILabel Label;
  public float Intensity;

  private void Start()
  {
    if (!MissionModeGlobals.MissionMode)
      return;
    this.Label.text = "No...I must complete my mission.";
  }

  private void Update()
  {
    float z = this.Yandere.position.z;
    if ((double) z < -94.0)
    {
      this.Intensity = Mathf.Abs(z) - 95f;
      this.TextureCycle.gameObject.SetActive(true);
      this.TextureCycle.Sprite.enabled = true;
      this.TextureCycle.enabled = true;
      Color color1 = this.Static.color + new Color(0.0001f, 0.0001f, 0.0001f, 0.0001f);
      Color color2 = this.Label.color;
      color1.a = this.Intensity / 5f;
      color2.a = this.Intensity / 5f;
      this.Static.color = color1;
      this.Label.color = color2;
      this.GetComponent<AudioSource>().volume = (float) ((double) this.Intensity / 5.0 * 0.10000000149011612);
      this.Label.transform.localPosition = this.Label.transform.localPosition with
      {
        x = Random.Range(-10f, 10f),
        y = Random.Range(-10f, 10f)
      };
    }
    else
    {
      if (!this.TextureCycle.enabled)
        return;
      this.TextureCycle.gameObject.SetActive(false);
      this.TextureCycle.Sprite.enabled = false;
      this.TextureCycle.enabled = false;
      Color color3 = this.Static.color;
      Color color4 = this.Label.color;
      color3.a = 0.0f;
      color4.a = 0.0f;
      this.Static.color = color3;
      this.Label.color = color4;
      this.GetComponent<AudioSource>().volume = 0.0f;
    }
  }
}
