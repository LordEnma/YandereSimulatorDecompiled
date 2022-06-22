// Decompiled with JetBrains decompiler
// Type: BloodyScreamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
