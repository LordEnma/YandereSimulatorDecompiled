// Decompiled with JetBrains decompiler
// Type: SentenceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SentenceScript : MonoBehaviour
{
  public UILabel Sentence;
  public string[] Words;
  public int ID;

  private void Update()
  {
    if (!Input.GetButtonDown("A"))
      return;
    this.Sentence.text = this.Words[this.ID];
    ++this.ID;
  }
}
