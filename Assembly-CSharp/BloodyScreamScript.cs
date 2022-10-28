// Decompiled with JetBrains decompiler
// Type: BloodyScreamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BloodyScreamScript : MonoBehaviour
{
  public AudioClip[] Screams;

  private void Start()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.Screams[Random.Range(0, this.Screams.Length)];
    component.Play();
  }
}
