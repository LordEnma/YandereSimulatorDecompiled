using UnityEngine;

public class EightiesStatsScript : MonoBehaviour
{
	public CourtroomScript Courtroom;

	public UILabel[] Label;

	public string[] Eliminations;

	public string[] Details;

	public int Disappearances;

	public int Grudges;

	public int Deaths;

	public int[] EliminationIDs;

	public int[] DetailIDs;

	public void Start()
	{
		if (!GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		int i = 0;
		Grudges = 0;
		for (; i < 100; i++)
		{
			if (StudentGlobals.GetStudentGrudge(i))
			{
				Grudges++;
			}
		}
		i = 1;
		if (i < 11)
		{
			if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 2)
			{
				Deaths++;
			}
			if (GameGlobals.GetRivalEliminations(i) == 11)
			{
				Disappearances++;
			}
			i++;
		}
		for (i = 1; i < 11; i++)
		{
			EliminationIDs[i] = GameGlobals.GetSpecificEliminations(i);
			DetailIDs[i] = GameGlobals.GetRivalEliminations(i);
		}
		if (GameGlobals.RivalEliminationID > 0)
		{
			EliminationIDs[DateGlobals.Week] = GameGlobals.SpecificEliminationID;
			DetailIDs[DateGlobals.Week] = GameGlobals.RivalEliminationID;
		}
		Label[0].text = "Rival #1: " + Eliminations[EliminationIDs[1]] + "\n" + Details[DetailIDs[1]] + "\n\nRival #2: " + Eliminations[EliminationIDs[2]] + "\n" + Details[DetailIDs[2]] + "\n\nRival #3: " + Eliminations[EliminationIDs[3]] + "\n" + Details[DetailIDs[3]] + "\n\nRival #4: " + Eliminations[EliminationIDs[4]] + "\n" + Details[DetailIDs[4]] + "\n\nRival #5: " + Eliminations[EliminationIDs[5]] + "\n" + Details[DetailIDs[5]];
		Label[1].text = "Rival #6: " + Eliminations[EliminationIDs[6]] + "\n" + Details[DetailIDs[6]] + "\n\nRival #7: " + Eliminations[EliminationIDs[7]] + "\n" + Details[DetailIDs[7]] + "\n\nRival #8: " + Eliminations[EliminationIDs[8]] + "\n" + Details[DetailIDs[8]] + "\n\nRival #9: " + Eliminations[EliminationIDs[9]] + "\n" + Details[DetailIDs[9]] + "\n\nRival #10: " + Eliminations[EliminationIDs[10]] + "\n" + Details[DetailIDs[10]];
		Label[2].text = "Police have...\n...visited Akademi " + PlayerGlobals.PoliceVisits + " times.\n...discovered " + PlayerGlobals.CorpsesDiscovered + " corpses at Akademi.\nRyoba's reputation is " + Mathf.RoundToInt(PlayerGlobals.Reputation) + ".\n" + Grudges + " students think Ryoba is a murderer.";
		Label[3].text = "Ryoba has...\n...made " + PlayerGlobals.Friends + " friends.\n...alarmed her classmates " + PlayerGlobals.Alerts + " times.\n...been seen with a weapon " + PlayerGlobals.WeaponWitnessed + " times.\n...been seen stained with blood " + PlayerGlobals.BloodWitnessed + " times.";
		if (Courtroom != null)
		{
			Courtroom.UpdateFactLabels();
		}
	}
}
