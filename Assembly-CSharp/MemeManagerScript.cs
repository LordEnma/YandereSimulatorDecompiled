// Decompiled with JetBrains decompiler
// Type: MemeManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MemeManagerScript : MonoBehaviour
{
  [SerializeField]
  private GameObject[] Memes;

  private void Start()
  {
    if (!GameGlobals.LoveSick)
      return;
    foreach (GameObject meme in this.Memes)
      meme.SetActive(false);
  }
}
