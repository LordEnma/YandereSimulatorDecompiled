using System;
using UnityEngine;

// Token: 0x020002A0 RID: 672
public class EightiesStatsScript : MonoBehaviour
{
	// Token: 0x06001417 RID: 5143 RVA: 0x000BF7B8 File Offset: 0x000BD9B8
	public void Start()
	{
		if (!GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		int i = 0;
		this.Grudges = 0;
		while (i < 100)
		{
			if (StudentGlobals.GetStudentGrudge(i))
			{
				this.Grudges++;
			}
			i++;
		}
		i = 1;
		if (i < 11)
		{
			if (GameGlobals.GetRivalEliminations(i) == 1 || GameGlobals.GetRivalEliminations(i) == 2)
			{
				this.Deaths++;
			}
			if (GameGlobals.GetRivalEliminations(i) == 11)
			{
				this.Disappearances++;
			}
			i++;
		}
		for (i = 1; i < 11; i++)
		{
			this.EliminationIDs[i] = GameGlobals.GetSpecificEliminations(i);
			this.DetailIDs[i] = GameGlobals.GetRivalEliminations(i);
			if (this.EliminationIDs[i] == 14)
			{
				this.DetailIDs[i] = 13;
			}
		}
		if (GameGlobals.RivalEliminationID > 0)
		{
			this.EliminationIDs[DateGlobals.Week] = GameGlobals.SpecificEliminationID;
			this.DetailIDs[DateGlobals.Week] = GameGlobals.RivalEliminationID;
			if (this.EliminationIDs[DateGlobals.Week] == 14)
			{
				this.DetailIDs[DateGlobals.Week] = 13;
			}
		}
		this.Label[0].text = string.Concat(new string[]
		{
			"Rival #1: ",
			this.Eliminations[this.EliminationIDs[1]],
			"\n",
			this.Details[this.DetailIDs[1]],
			"\n\nRival #2: ",
			this.Eliminations[this.EliminationIDs[2]],
			"\n",
			this.Details[this.DetailIDs[2]],
			"\n\nRival #3: ",
			this.Eliminations[this.EliminationIDs[3]],
			"\n",
			this.Details[this.DetailIDs[3]],
			"\n\nRival #4: ",
			this.Eliminations[this.EliminationIDs[4]],
			"\n",
			this.Details[this.DetailIDs[4]],
			"\n\nRival #5: ",
			this.Eliminations[this.EliminationIDs[5]],
			"\n",
			this.Details[this.DetailIDs[5]]
		});
		this.Label[1].text = string.Concat(new string[]
		{
			"Rival #6: ",
			this.Eliminations[this.EliminationIDs[6]],
			"\n",
			this.Details[this.DetailIDs[6]],
			"\n\nRival #7: ",
			this.Eliminations[this.EliminationIDs[7]],
			"\n",
			this.Details[this.DetailIDs[7]],
			"\n\nRival #8: ",
			this.Eliminations[this.EliminationIDs[8]],
			"\n",
			this.Details[this.DetailIDs[8]],
			"\n\nRival #9: ",
			this.Eliminations[this.EliminationIDs[9]],
			"\n",
			this.Details[this.DetailIDs[9]],
			"\n\nRival #10: ",
			this.Eliminations[this.EliminationIDs[10]],
			"\n",
			this.Details[this.DetailIDs[10]]
		});
		this.Label[2].text = string.Concat(new string[]
		{
			"Police have...\n...visited Akademi ",
			PlayerGlobals.PoliceVisits.ToString(),
			" times.\n...discovered ",
			PlayerGlobals.CorpsesDiscovered.ToString(),
			" corpses at Akademi.\nRyoba's reputation is ",
			Mathf.RoundToInt(PlayerGlobals.Reputation).ToString(),
			".\n",
			this.Grudges.ToString(),
			" students think Ryoba is a murderer."
		});
		this.Label[3].text = string.Concat(new string[]
		{
			"Ryoba has...\n...made ",
			PlayerGlobals.Friends.ToString(),
			" friends.\n...alarmed her classmates ",
			PlayerGlobals.Alerts.ToString(),
			" times.\n...been seen with a weapon ",
			PlayerGlobals.WeaponWitnessed.ToString(),
			" times.\n...been seen stained with blood ",
			PlayerGlobals.BloodWitnessed.ToString(),
			" times."
		});
		if (this.Courtroom != null)
		{
			this.Courtroom.UpdateFactLabels();
		}
	}

	// Token: 0x04001E25 RID: 7717
	public CourtroomScript Courtroom;

	// Token: 0x04001E26 RID: 7718
	public UILabel[] Label;

	// Token: 0x04001E27 RID: 7719
	public string[] Eliminations;

	// Token: 0x04001E28 RID: 7720
	public string[] Details;

	// Token: 0x04001E29 RID: 7721
	public int Disappearances;

	// Token: 0x04001E2A RID: 7722
	public int Grudges;

	// Token: 0x04001E2B RID: 7723
	public int Deaths;

	// Token: 0x04001E2C RID: 7724
	public int[] EliminationIDs;

	// Token: 0x04001E2D RID: 7725
	public int[] DetailIDs;
}
