using UnityEngine;

public class ConvoManagerScript : MonoBehaviour
{
	public StudentManagerScript SM;

	public int Week;

	public int ID;

	public bool Eighties;

	public string[] FemaleCombatAnims;

	public string[] MaleCombatAnims;

	public bool BothCharactersInPosition;

	public float PatienceTimer;

	public float CheckTimer;

	public float KickTimer;

	public int CombatAnimID;

	public int Cycles;

	public int[] MartialArtist;

	public void Start()
	{
		if (!MissionModeGlobals.MissionMode && DateGlobals.Week == 1)
		{
			Week = 1;
		}
		Eighties = GameGlobals.Eighties;
	}

	public void CheckMe(int StudentID)
	{
		if (StudentID > 20 && StudentID < 26)
		{
			CheckGroup(StudentID, 21, 26);
		}
		else if (StudentID > 25 && StudentID < 31)
		{
			CheckGroup(StudentID, 26, 31);
		}
		else if (StudentID > 30 && StudentID < 36)
		{
			CheckGroup(StudentID, 31, 36);
		}
		else if (StudentID > 35 && StudentID < 41)
		{
			CheckGroup(StudentID, 36, 41);
		}
		else if (StudentID > 40 && StudentID < 46)
		{
			CheckGroup(StudentID, 41, 46);
		}
		else if (StudentID > 45 && StudentID < 51)
		{
			CheckGroup(StudentID, 46, 51);
		}
		else if (StudentID > 50 && StudentID < 56)
		{
			CheckGroup(StudentID, 51, 56);
		}
		else if (StudentID > 55 && StudentID < 61)
		{
			CheckGroup(StudentID, 56, 61);
		}
		else if (StudentID > 60 && StudentID < 66)
		{
			CheckGroup(StudentID, 61, 66);
		}
		else if (StudentID > 65 && StudentID < 71)
		{
			CheckGroup(StudentID, 66, 71);
		}
		else if (StudentID > 70 && StudentID < 76)
		{
			CheckGroup(StudentID, 71, 76);
		}
		else if (StudentID > 75 && StudentID < 81)
		{
			for (ID = 76; ID < 81; ID++)
			{
				if (ID != StudentID)
				{
					if (SM.Students[ID] != null)
					{
						if ((double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
						{
							SM.Students[StudentID].TrueAlone = false;
							if (SM.Students[ID].Routine)
							{
								SM.Students[StudentID].Alone = false;
								break;
							}
							SM.Students[StudentID].Alone = true;
						}
						else
						{
							SM.Students[StudentID].TrueAlone = true;
							SM.Students[StudentID].Alone = true;
						}
					}
					else
					{
						SM.Students[StudentID].TrueAlone = true;
						SM.Students[StudentID].Alone = true;
					}
				}
			}
		}
		else if (StudentID > 80 && StudentID < 86)
		{
			CheckGroup(StudentID, 81, 86);
		}
		if (!Eighties)
		{
			switch (StudentID)
			{
			case 2:
				if (SM.Students[3].Routine && (double)Vector3.Distance(SM.Students[2].transform.position, SM.Students[3].transform.position) < 1.4)
				{
					SM.Students[2].Alone = false;
				}
				else
				{
					SM.Students[2].Alone = true;
				}
				break;
			case 3:
				if (SM.Students[2].Routine && (double)Vector3.Distance(SM.Students[3].transform.position, SM.Students[2].transform.position) < 1.4)
				{
					SM.Students[3].Alone = false;
				}
				else
				{
					SM.Students[3].Alone = true;
				}
				break;
			case 10:
				if (SM.Students[11] != null)
				{
					if (SM.Students[11].Routine && Vector3.Distance(SM.Students[10].transform.position, SM.Students[11].transform.position) < 2.1f)
					{
						SM.Students[10].Alone = false;
					}
					else
					{
						SM.Students[10].Alone = true;
					}
				}
				else
				{
					SM.Students[10].Alone = true;
				}
				break;
			case 11:
				if (SM.Students[10] != null)
				{
					if (SM.Students[10].Routine && Vector3.Distance(SM.Students[11].transform.position, SM.Students[10].transform.position) < 2.1f)
					{
						SM.Students[11].Alone = false;
					}
					else
					{
						SM.Students[11].Alone = true;
					}
				}
				else
				{
					SM.Students[11].Alone = true;
				}
				break;
			}
			if (Week != 1)
			{
				return;
			}
			switch (StudentID)
			{
			case 25:
				if (SM.Students[30] != null && SM.Students[30].Routine && (double)Vector3.Distance(SM.Students[25].transform.position, SM.Students[30].transform.position) < 1.4)
				{
					SM.Students[25].Alone = false;
				}
				else
				{
					SM.Students[25].Alone = true;
				}
				break;
			case 30:
				if (SM.Students[25] != null && SM.Students[25].Routine && (double)Vector3.Distance(SM.Students[30].transform.position, SM.Students[25].transform.position) < 1.4)
				{
					SM.Students[30].Alone = false;
				}
				else
				{
					SM.Students[30].Alone = true;
				}
				break;
			}
			switch (StudentID)
			{
			case 55:
				if (SM.Students[54] != null && SM.Students[54].Routine && (double)Vector3.Distance(SM.Students[55].transform.position, SM.Students[54].transform.position) < 1.4)
				{
					SM.Students[55].Alone = false;
				}
				else
				{
					SM.Students[55].Alone = true;
				}
				break;
			case 54:
				if (SM.Students[55] != null && SM.Students[55].Routine && (double)Vector3.Distance(SM.Students[54].transform.position, SM.Students[55].transform.position) < 1.4)
				{
					SM.Students[54].Alone = false;
				}
				else
				{
					SM.Students[54].Alone = true;
				}
				break;
			}
			switch (StudentID)
			{
			case 72:
				if (SM.Students[73] != null && SM.Students[73].Routine && (double)Vector3.Distance(SM.Students[72].transform.position, SM.Students[73].transform.position) < 1.4)
				{
					SM.Students[72].Alone = false;
				}
				else
				{
					SM.Students[72].Alone = true;
				}
				break;
			case 73:
				if (SM.Students[72] != null && SM.Students[72].Routine && (double)Vector3.Distance(SM.Students[73].transform.position, SM.Students[72].transform.position) < 1.4)
				{
					SM.Students[73].Alone = false;
				}
				else
				{
					SM.Students[73].Alone = true;
				}
				break;
			}
			switch (StudentID)
			{
			case 74:
				if (SM.Students[75] != null && SM.Students[75].Routine && (double)Vector3.Distance(SM.Students[75].transform.position, SM.Students[74].transform.position) < 1.4)
				{
					SM.Students[74].Alone = false;
				}
				else
				{
					SM.Students[74].Alone = true;
				}
				break;
			case 75:
				if (SM.Students[74] != null && SM.Students[74].Routine && (double)Vector3.Distance(SM.Students[75].transform.position, SM.Students[74].transform.position) < 1.4)
				{
					SM.Students[75].Alone = false;
				}
				else
				{
					SM.Students[75].Alone = true;
				}
				break;
			}
			switch (StudentID)
			{
			case 24:
				if (SM.Students[27] != null && SM.Students[27].Routine && (double)Vector3.Distance(SM.Students[24].transform.position, SM.Students[27].transform.position) < 1.4)
				{
					SM.Students[24].Alone = false;
				}
				else
				{
					SM.Students[24].Alone = true;
				}
				break;
			case 27:
				if (SM.Students[24] != null && SM.Students[24].Routine && (double)Vector3.Distance(SM.Students[24].transform.position, SM.Students[27].transform.position) < 1.4)
				{
					SM.Students[27].Alone = false;
				}
				else
				{
					SM.Students[27].Alone = true;
				}
				break;
			}
		}
		else
		{
			if (StudentID >= 13)
			{
				return;
			}
			for (ID = 2; ID < 13; ID++)
			{
				if (ID != StudentID)
				{
					if (SM.Students[ID] != null)
					{
						if (SM.Students[ID].Routine && Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.66666f)
						{
							SM.Students[StudentID].Alone = false;
							break;
						}
						SM.Students[StudentID].Alone = true;
					}
					else
					{
						SM.Students[StudentID].Alone = true;
					}
				}
			}
		}
	}

	public void MartialArtsCheck()
	{
		CheckTimer += Time.deltaTime;
		if ((CheckTimer > 1f || BothCharactersInPosition) && SM.Students[MartialArtist[1]] != null && SM.Students[MartialArtist[2]] != null && SM.Students[MartialArtist[1]].Routine && SM.Students[MartialArtist[2]].Routine && SM.Students[MartialArtist[1]].DistanceToDestination < 0.1f && SM.Students[MartialArtist[2]].DistanceToDestination < 0.1f)
		{
			BothCharactersInPosition = true;
			PatienceTimer = 0f;
			CombatAnimID++;
			if (CombatAnimID > 2)
			{
				CombatAnimID = 1;
			}
			SM.Students[MartialArtist[1]].ClubAnim = MaleCombatAnims[CombatAnimID];
			SM.Students[MartialArtist[2]].ClubAnim = FemaleCombatAnims[CombatAnimID];
			SM.Students[MartialArtist[1]].GetNewAnimation = false;
			SM.Students[MartialArtist[2]].GetNewAnimation = false;
			Cycles++;
			if (Cycles == 10)
			{
				SM.UpdateMartialArts();
				KickTimer = 0f;
				Cycles = 0;
			}
		}
	}

	public void LateUpdate()
	{
		StudentScript studentScript = SM.Students[MartialArtist[1]];
		StudentScript studentScript2 = SM.Students[MartialArtist[2]];
		CheckTimer = Mathf.MoveTowards(CheckTimer, 0f, Time.deltaTime);
		if (BothCharactersInPosition)
		{
			if (SM.Students[MartialArtist[1]].Routine && SM.Students[MartialArtist[2]].Routine)
			{
				if (SM.Students[MartialArtist[1]].DistanceToPlayer < 1.5f || SM.Students[MartialArtist[2]].DistanceToPlayer < 1.5f || SM.Students[MartialArtist[1]].Talking || SM.Students[MartialArtist[2]].Talking || SM.Students[MartialArtist[1]].Distracted || SM.Students[MartialArtist[2]].Distracted || SM.Students[MartialArtist[1]].TurnOffRadio || SM.Students[MartialArtist[2]].TurnOffRadio)
				{
					if (SM.Students[MartialArtist[1]].DistanceToPlayer < 1.5f || SM.Students[MartialArtist[2]].DistanceToPlayer < 1.5f)
					{
						SM.Students[MartialArtist[1]].Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
					}
					SM.Students[MartialArtist[1]].ClubAnim = "idle_20";
					SM.Students[MartialArtist[2]].ClubAnim = "f02_idle_20";
					BothCharactersInPosition = false;
				}
			}
			else
			{
				SM.Students[MartialArtist[1]].ClubAnim = "idle_20";
				SM.Students[MartialArtist[2]].ClubAnim = "f02_idle_20";
				BothCharactersInPosition = false;
			}
			return;
		}
		if (studentScript != null && studentScript.ClubAttire && studentScript.Actions[studentScript.Phase] == StudentActionType.ClubAction && Vector3.Distance(studentScript.transform.position, SM.Clubs.List[MartialArtist[1]].position) < 1.5f)
		{
			if (studentScript.Talking || studentScript.Distracted || studentScript.TurnOffRadio)
			{
				studentScript.ClubAnim = "idle_20";
				if (studentScript2 != null)
				{
					studentScript2.ClubAnim = "f02_idle_20";
				}
				PatienceTimer = 0f;
			}
			else if (studentScript.DistanceToPlayer < 1.5f)
			{
				studentScript.Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
				studentScript.ClubAnim = "idle_20";
				if (studentScript2 != null)
				{
					studentScript2.ClubAnim = "f02_idle_20";
				}
				PatienceTimer = 0f;
			}
			else
			{
				PatienceTimer += Time.deltaTime;
				if (PatienceTimer < 5f)
				{
					studentScript.ClubAnim = "idle_20";
					if (studentScript2 != null)
					{
						studentScript2.ClubAnim = "f02_idle_20";
					}
				}
				else
				{
					studentScript.ClubAnim = "loopingKick";
					if (studentScript2 != null)
					{
						studentScript2.ClubAnim = "f02_loopingKick";
					}
					if (studentScript.DistanceToDestination < 1f)
					{
						KickTimer += Time.deltaTime;
						if (KickTimer >= 60f)
						{
							SM.UpdateMartialArts();
							KickTimer = 0f;
							Cycles = 0;
						}
					}
				}
			}
		}
		if (!(studentScript2 != null) || !studentScript2.ClubAttire || studentScript2.Actions[studentScript2.Phase] != StudentActionType.ClubAction || !(Vector3.Distance(studentScript2.transform.position, SM.Clubs.List[MartialArtist[2]].position) < 1.5f))
		{
			return;
		}
		if (studentScript2.Talking || studentScript2.Distracted || studentScript2.TurnOffRadio)
		{
			studentScript.ClubAnim = "f02_idle_20";
			if (studentScript != null)
			{
				studentScript.ClubAnim = "idle_20";
			}
			PatienceTimer = 0f;
			return;
		}
		if (studentScript2.DistanceToPlayer < 1.5f)
		{
			studentScript2.Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
			studentScript2.ClubAnim = "f02_idle_20";
			if (studentScript != null)
			{
				studentScript.ClubAnim = "idle_20";
			}
			PatienceTimer = 0f;
			return;
		}
		PatienceTimer += Time.deltaTime;
		if (PatienceTimer < 5f)
		{
			studentScript2.ClubAnim = "f02_idle_20";
			if (studentScript != null)
			{
				studentScript.ClubAnim = "idle_20";
			}
			return;
		}
		studentScript2.ClubAnim = "f02_loopingKick";
		if (studentScript != null)
		{
			studentScript.ClubAnim = "loopingKick";
		}
		if (studentScript2.DistanceToDestination < 1f)
		{
			KickTimer += Time.deltaTime;
			if (KickTimer >= 60f)
			{
				SM.UpdateMartialArts();
				KickTimer = 0f;
				Cycles = 0;
			}
		}
	}

	public void CheckGroup(int StudentID, int StartID, int EndID)
	{
		ID = StartID;
		while (ID < EndID)
		{
			if (ID != StudentID)
			{
				if (SM.Students[ID] != null && SM.Students[ID].Alive)
				{
					if (SM.Students[ID].Routine && (double)Vector3.Distance(SM.Students[ID].transform.position, SM.Students[StudentID].transform.position) < 2.5)
					{
						SM.Students[StudentID].Alone = false;
						break;
					}
					SM.Students[StudentID].Alone = true;
				}
				else
				{
					SM.Students[StudentID].Alone = true;
				}
			}
			ID++;
			if (ID == StudentID)
			{
				SM.Students[StudentID].Alone = true;
			}
		}
	}
}
