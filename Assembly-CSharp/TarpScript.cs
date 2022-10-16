// Decompiled with JetBrains decompiler
// Type: TarpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TarpScript : MonoBehaviour
{
  public PromptScript Prompt;
  public MechaScript Mecha;
  public AudioClip Tarp;
  public float PreviousSpeed;
  public float Speed;
  public bool Unwrap;

  private void Start() => this.transform.localScale = new Vector3(1f, 1f, 1f);

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      AudioSource.PlayClipAtPoint(this.Tarp, this.transform.position);
      this.Unwrap = true;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Mecha.enabled = true;
      this.Mecha.Prompt.enabled = true;
    }
    if (!this.Unwrap)
      return;
    this.Speed += Time.deltaTime * 10f;
    this.transform.localEulerAngles = Vector3.Lerp(this.transform.localEulerAngles, new Vector3(90f, 90f, 0.0f), Time.deltaTime * this.Speed);
    if ((double) this.transform.localEulerAngles.x <= 45.0)
      return;
    if ((double) this.PreviousSpeed == 0.0)
      this.PreviousSpeed = this.Speed;
    this.Speed += Time.deltaTime * 10f;
    this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 0.0001f), (this.Speed - this.PreviousSpeed) * Time.deltaTime);
  }
}
