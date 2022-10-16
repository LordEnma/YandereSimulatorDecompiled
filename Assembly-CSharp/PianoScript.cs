// Decompiled with JetBrains decompiler
// Type: PianoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PianoScript : MonoBehaviour
{
  public PromptScript Prompt;
  public AudioSource[] Notes;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount >= 1.0 || (double) this.Prompt.Circle[0].fillAmount <= 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 0.0f;
    this.Notes[this.ID].Play();
    ++this.ID;
    if (this.ID != this.Notes.Length)
      return;
    this.ID = 0;
  }
}
