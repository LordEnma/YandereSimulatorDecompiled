// Decompiled with JetBrains decompiler
// Type: DDRLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
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
