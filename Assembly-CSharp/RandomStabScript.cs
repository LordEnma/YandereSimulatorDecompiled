// Decompiled with JetBrains decompiler
// Type: RandomStabScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RandomStabScript : MonoBehaviour
{
  public AudioClip[] Stabs;
  public AudioClip Bite;
  public bool Biting;

  private void Start()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if (!this.Biting)
    {
      component.clip = this.Stabs[Random.Range(0, this.Stabs.Length)];
      component.Play();
    }
    else
    {
      component.clip = this.Bite;
      component.pitch = Random.Range(0.5f, 1f);
      component.Play();
    }
  }
}
