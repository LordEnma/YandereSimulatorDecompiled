// Decompiled with JetBrains decompiler
// Type: MemeManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
