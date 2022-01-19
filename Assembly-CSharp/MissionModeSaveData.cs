using System;
using System.Collections.Generic;

// Token: 0x020003FC RID: 1020
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BFD RID: 7165 RVA: 0x001459D8 File Offset: 0x00143BD8
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

	// Token: 0x06001BFE RID: 7166 RVA: 0x00145A70 File Offset: 0x00143C70
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

	// Token: 0x04003110 RID: 12560
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003111 RID: 12561
	public int missionDifficulty;

	// Token: 0x04003112 RID: 12562
	public bool missionMode;

	// Token: 0x04003113 RID: 12563
	public int missionRequiredClothing;

	// Token: 0x04003114 RID: 12564
	public int missionRequiredDisposal;

	// Token: 0x04003115 RID: 12565
	public int missionRequiredWeapon;

	// Token: 0x04003116 RID: 12566
	public int missionTarget;

	// Token: 0x04003117 RID: 12567
	public string missionTargetName = string.Empty;

	// Token: 0x04003118 RID: 12568
	public int nemesisDifficulty;
}
