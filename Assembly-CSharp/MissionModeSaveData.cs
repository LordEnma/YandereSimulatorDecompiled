using System;
using System.Collections.Generic;

// Token: 0x02000402 RID: 1026
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C29 RID: 7209 RVA: 0x00148CCC File Offset: 0x00146ECC
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

	// Token: 0x06001C2A RID: 7210 RVA: 0x00148D64 File Offset: 0x00146F64
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

	// Token: 0x04003193 RID: 12691
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003194 RID: 12692
	public int missionDifficulty;

	// Token: 0x04003195 RID: 12693
	public bool missionMode;

	// Token: 0x04003196 RID: 12694
	public int missionRequiredClothing;

	// Token: 0x04003197 RID: 12695
	public int missionRequiredDisposal;

	// Token: 0x04003198 RID: 12696
	public int missionRequiredWeapon;

	// Token: 0x04003199 RID: 12697
	public int missionTarget;

	// Token: 0x0400319A RID: 12698
	public string missionTargetName = string.Empty;

	// Token: 0x0400319B RID: 12699
	public int nemesisDifficulty;
}
