// Decompiled with JetBrains decompiler
// Type: BloodyScreamScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
