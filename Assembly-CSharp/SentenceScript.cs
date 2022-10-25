// Decompiled with JetBrains decompiler
// Type: SentenceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
