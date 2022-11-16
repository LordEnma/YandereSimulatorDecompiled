// Decompiled with JetBrains decompiler
// Type: RPG_Animation_CharacterFadeOnly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
  public static RPG_Animation_CharacterFadeOnly instance;

  private void Awake() => RPG_Animation_CharacterFadeOnly.instance = this;
}
