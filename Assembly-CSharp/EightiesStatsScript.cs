// Decompiled with JetBrains decompiler
// Type: EightiesStatsScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
      this.enabled = false;
    int studentID = 0;
    this.Grudges = 0;
    for (; studentID < 100; ++studentID)
    {
      if (StudentGlobals.GetStudentGrudge(studentID))
        ++this.Grudges;
    }
    int elimID1 = 1;
    if (elimID1 < 11)
    {
      if (GameGlobals.GetRivalEliminations(elimID1) == 1 || GameGlobals.GetRivalEliminations(elimID1) == 2)
        ++this.Deaths;
      if (GameGlobals.GetRivalEliminations(elimID1) == 11)
        ++this.Disappearances;
      int num = elimID1 + 1;
    }
    for (int elimID2 = 1; elimID2 < 11; ++elimID2)
    {
      this.EliminationIDs[elimID2] = GameGlobals.GetSpecificEliminations(elimID2);
      this.DetailIDs[elimID2] = GameGlobals.GetRivalEliminations(elimID2);
    }
    if (GameGlobals.RivalEliminationID > 0)
    {
      this.EliminationIDs[DateGlobals.Week] = GameGlobals.SpecificEliminationID;
      this.DetailIDs[DateGlobals.Week] = GameGlobals.RivalEliminationID;
    }
    this.Label[0].text = "Rival #1: " + this.Eliminations[this.EliminationIDs[1]] + "\n" + this.Details[this.DetailIDs[1]] + "\n\nRival #2: " + this.Eliminations[this.EliminationIDs[2]] + "\n" + this.Details[this.DetailIDs[2]] + "\n\nRival #3: " + this.Eliminations[this.EliminationIDs[3]] + "\n" + this.Details[this.DetailIDs[3]] + "\n\nRival #4: " + this.Eliminations[this.EliminationIDs[4]] + "\n" + this.Details[this.DetailIDs[4]] + "\n\nRival #5: " + this.Eliminations[this.EliminationIDs[5]] + "\n" + this.Details[this.DetailIDs[5]];
    this.Label[1].text = "Rival #6: " + this.Eliminations[this.EliminationIDs[6]] + "\n" + this.Details[this.DetailIDs[6]] + "\n\nRival #7: " + this.Eliminations[this.EliminationIDs[7]] + "\n" + this.Details[this.DetailIDs[7]] + "\n\nRival #8: " + this.Eliminations[this.EliminationIDs[8]] + "\n" + this.Details[this.DetailIDs[8]] + "\n\nRival #9: " + this.Eliminations[this.EliminationIDs[9]] + "\n" + this.Details[this.DetailIDs[9]] + "\n\nRival #10: " + this.Eliminations[this.EliminationIDs[10]] + "\n" + this.Details[this.DetailIDs[10]];
    this.Label[2].text = "Police have...\n...visited Akademi " + PlayerGlobals.PoliceVisits.ToString() + " times.\n...discovered " + PlayerGlobals.CorpsesDiscovered.ToString() + " corpses at Akademi.\nRyoba's reputation is " + Mathf.RoundToInt(PlayerGlobals.Reputation).ToString() + ".\n" + this.Grudges.ToString() + " students think Ryoba is a murderer.";
    this.Label[3].text = "Ryoba has...\n...made " + PlayerGlobals.Friends.ToString() + " friends.\n...alarmed her classmates " + PlayerGlobals.Alerts.ToString() + " times.\n...been seen with a weapon " + PlayerGlobals.WeaponWitnessed.ToString() + " times.\n...been seen stained with blood " + PlayerGlobals.BloodWitnessed.ToString() + " times.";
    if (!((Object) this.Courtroom != (Object) null))
      return;
    this.Courtroom.UpdateFactLabels();
  }
}
