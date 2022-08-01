// Decompiled with JetBrains decompiler
// Type: BloodyScreamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
