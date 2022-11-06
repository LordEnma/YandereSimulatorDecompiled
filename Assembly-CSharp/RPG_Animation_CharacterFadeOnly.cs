// Decompiled with JetBrains decompiler
// Type: RPG_Animation_CharacterFadeOnly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
  public static RPG_Animation_CharacterFadeOnly instance;

  private void Awake() => RPG_Animation_CharacterFadeOnly.instance = this;
}
