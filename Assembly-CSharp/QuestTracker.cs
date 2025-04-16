using UnityEngine;

public class QuestTracker : MonoBehaviour
{
	public static int MoppedBloodCount { get; private set; }

	public static int MurderCount { get; private set; }

	public static int PantyShots { get; private set; }

	public static void IncrementBloodCount()
	{
		MoppedBloodCount++;
	}

	public static void IncrementMurderCount()
	{
		MurderCount++;
	}

	public static void IncrementPantyShots()
	{
		PantyShots++;
	}

	public static void ResetBloodCount()
	{
		MoppedBloodCount = 0;
	}

	public static void ResetMurderCount()
	{
		MurderCount = 0;
	}

	public static void ResetPantyCount()
	{
		PantyShots = 0;
	}
}
