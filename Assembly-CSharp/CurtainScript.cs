// Decompiled with JetBrains decompiler
// Type: CurtainScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CurtainScript : MonoBehaviour
{
  public SkinnedMeshRenderer[] Curtains;
  public PromptScript Prompt;
  public AudioSource MyAudio;
  public bool Animate;
  public bool Open;
  public float Weight;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount < 1.0 && (double) this.Prompt.Circle[0].fillAmount > 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 0.0f;
      this.MyAudio.Play();
      this.Animate = true;
      this.Open = !this.Open;
    }
    if (!this.Animate)
      return;
    if (!this.Open)
    {
      this.Weight = Mathf.Lerp(this.Weight, 0.0f, Time.deltaTime * 10f);
      if ((double) this.Weight < 0.0099999997764825821)
      {
        this.Animate = false;
        this.Weight = 0.0f;
      }
    }
    else
    {
      this.Weight = Mathf.Lerp(this.Weight, 100f, Time.deltaTime * 10f);
      if ((double) this.Weight > 99.989997863769531)
      {
        this.Animate = false;
        this.Weight = 100f;
      }
    }
    this.Curtains[0].SetBlendShapeWeight(0, this.Weight);
    this.Curtains[1].SetBlendShapeWeight(0, this.Weight);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 13 && other.gameObject.layer != 9 || this.Open)
      return;
    this.MyAudio.Play();
    this.Animate = true;
    this.Open = true;
  }
}
