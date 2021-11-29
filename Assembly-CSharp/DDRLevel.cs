using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class DDRLevel : ScriptableObject
{
	// Token: 0x04000001 RID: 1
	public string LevelName;

	// Token: 0x04000002 RID: 2
	public AudioClip Song;

	// Token: 0x04000003 RID: 3
	public Sprite LevelIcon;

	// Token: 0x04000004 RID: 4
	public DDRTrack[] Tracks;

	// Token: 0x04000005 RID: 5
	[Header("Points per score")]
	public int PerfectScorePoints;

	// Token: 0x04000006 RID: 6
	public int GreatScorePoints;

	// Token: 0x04000007 RID: 7
	public int GoodScorePoints;

	// Token: 0x04000008 RID: 8
	public int OkScorePoints;

	// Token: 0x04000009 RID: 9
	public int EarlyScorePoints;

	// Token: 0x0400000A RID: 10
	public int MissScorePoints;
}
