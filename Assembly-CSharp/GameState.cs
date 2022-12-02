using System;
using System.Collections.Generic;

[Serializable]
public class GameState
{
	public int Score;

	public float Health;

	public int LongestCombo;

	public int Combo;

	public Dictionary<DDRRating, int> Ratings;

	public DDRFinishStatus FinishStatus;

	public GameState()
	{
		Health = 100f;
		Ratings = new Dictionary<DDRRating, int>();
		Ratings.Add(DDRRating.Early, 0);
		Ratings.Add(DDRRating.Good, 0);
		Ratings.Add(DDRRating.Great, 0);
		Ratings.Add(DDRRating.Miss, 0);
		Ratings.Add(DDRRating.Ok, 0);
		Ratings.Add(DDRRating.Perfect, 0);
	}
}
