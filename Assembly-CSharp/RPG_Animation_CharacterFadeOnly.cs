// Decompiled with JetBrains decompiler
// Type: RPG_Animation_CharacterFadeOnly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
  public static RPG_Animation_CharacterFadeOnly instance;

  private void Awake() => RPG_Animation_CharacterFadeOnly.instance = this;
}
