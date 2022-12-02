using UnityEngine;

public class DDRLevel : ScriptableObject
{
	public string LevelName;

	public AudioClip Song;

	public Sprite LevelIcon;

	public DDRTrack[] Tracks;

	[Header("Points per score")]
	public int PerfectScorePoints;

	public int GreatScorePoints;

	public int GoodScorePoints;

	public int OkScorePoints;

	public int EarlyScorePoints;

	public int MissScorePoints;
}
