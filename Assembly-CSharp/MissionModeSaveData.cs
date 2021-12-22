using System;
using System.Collections.Generic;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BF2 RID: 7154 RVA: 0x00143B60 File Offset: 0x00141D60
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

	// Token: 0x06001BF3 RID: 7155 RVA: 0x00143BF8 File Offset: 0x00141DF8
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

	// Token: 0x040030FE RID: 12542
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040030FF RID: 12543
	public int missionDifficulty;

	// Token: 0x04003100 RID: 12544
	public bool missionMode;

	// Token: 0x04003101 RID: 12545
	public int missionRequiredClothing;

	// Token: 0x04003102 RID: 12546
	public int missionRequiredDisposal;

	// Token: 0x04003103 RID: 12547
	public int missionRequiredWeapon;

	// Token: 0x04003104 RID: 12548
	public int missionTarget;

	// Token: 0x04003105 RID: 12549
	public string missionTargetName = string.Empty;

	// Token: 0x04003106 RID: 12550
	public int nemesisDifficulty;
}
