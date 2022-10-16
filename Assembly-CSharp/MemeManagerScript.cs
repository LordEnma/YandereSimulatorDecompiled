// Decompiled with JetBrains decompiler
// Type: MemeManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
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
