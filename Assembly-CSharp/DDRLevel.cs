// Decompiled with JetBrains decompiler
// Type: DDRLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DDRLevel : ScriptableObject
{
  public string LevelName;
  public AudioClip Song;
  public UnityEngine.Sprite LevelIcon;
  public DDRTrack[] Tracks;
  [Header("Points per score")]
  public int PerfectScorePoints;
  public int GreatScorePoints;
  public int GoodScorePoints;
  public int OkScorePoints;
  public int EarlyScorePoints;
  public int MissScorePoints;
}
