using System;
using System.Collections.Generic;

// Token: 0x02000008 RID: 8
[Serializable]
public class GameState
{
	// Token: 0x06000022 RID: 34 RVA: 0x00003360 File Offset: 0x00001560
	public GameState()
	{
		this.Health = 100f;
		this.Ratings = new Dictionary<DDRRating, int>();
		this.Ratings.Add(DDRRating.Early, 0);
		this.Ratings.Add(DDRRating.Good, 0);
		this.Ratings.Add(DDRRating.Great, 0);
		this.Ratings.Add(DDRRating.Miss, 0);
		this.Ratings.Add(DDRRating.Ok, 0);
		this.Ratings.Add(DDRRating.Perfect, 0);
	}

	// Token: 0x0400004F RID: 79
	public int Score;

	// Token: 0x04000050 RID: 80
	public float Health;

	// Token: 0x04000051 RID: 81
	public int LongestCombo;

	// Token: 0x04000052 RID: 82
	public int Combo;

	// Token: 0x04000053 RID: 83
	public Dictionary<DDRRating, int> Ratings;

	// Token: 0x04000054 RID: 84
	public DDRFinishStatus FinishStatus;
}
