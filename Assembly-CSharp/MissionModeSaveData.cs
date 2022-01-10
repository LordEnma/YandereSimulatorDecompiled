using System;
using System.Collections.Generic;

// Token: 0x020003FB RID: 1019
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BFB RID: 7163 RVA: 0x001442D0 File Offset: 0x001424D0
	public static MissionModeSaveData ReadFromGlobals()
	{
		MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
		foreach (int num in MissionModeGlobals.KeysOfMissionCondition())
		{
			missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
		}
		missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
		missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
		missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
		missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
		missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
		missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
		missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
		missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
		return missionModeSaveData;
	}

	// Token: 0x06001BFC RID: 7164 RVA: 0x00144368 File Offset: 0x00142568
	public static void WriteToGlobals(MissionModeSaveData data)
	{
		foreach (KeyValuePair<int, int> keyValuePair in data.missionCondition)
		{
			MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
		}
		MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
		MissionModeGlobals.MissionMode = data.missionMode;
		MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
		MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
		MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
		MissionModeGlobals.MissionTarget = data.missionTarget;
		MissionModeGlobals.MissionTargetName = data.missionTargetName;
		MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
	}

	// Token: 0x0400310B RID: 12555
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x0400310C RID: 12556
	public int missionDifficulty;

	// Token: 0x0400310D RID: 12557
	public bool missionMode;

	// Token: 0x0400310E RID: 12558
	public int missionRequiredClothing;

	// Token: 0x0400310F RID: 12559
	public int missionRequiredDisposal;

	// Token: 0x04003110 RID: 12560
	public int missionRequiredWeapon;

	// Token: 0x04003111 RID: 12561
	public int missionTarget;

	// Token: 0x04003112 RID: 12562
	public string missionTargetName = string.Empty;

	// Token: 0x04003113 RID: 12563
	public int nemesisDifficulty;
}
