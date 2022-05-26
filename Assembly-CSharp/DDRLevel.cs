// Decompiled with JetBrains decompiler
// Type: DDRLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
