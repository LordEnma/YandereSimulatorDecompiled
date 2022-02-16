using System;
using System.Collections.Generic;

// Token: 0x020003FD RID: 1021
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C07 RID: 7175 RVA: 0x001463B8 File Offset: 0x001445B8
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

	// Token: 0x06001C08 RID: 7176 RVA: 0x00146450 File Offset: 0x00144650
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

	// Token: 0x04003120 RID: 12576
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003121 RID: 12577
	public int missionDifficulty;

	// Token: 0x04003122 RID: 12578
	public bool missionMode;

	// Token: 0x04003123 RID: 12579
	public int missionRequiredClothing;

	// Token: 0x04003124 RID: 12580
	public int missionRequiredDisposal;

	// Token: 0x04003125 RID: 12581
	public int missionRequiredWeapon;

	// Token: 0x04003126 RID: 12582
	public int missionTarget;

	// Token: 0x04003127 RID: 12583
	public string missionTargetName = string.Empty;

	// Token: 0x04003128 RID: 12584
	public int nemesisDifficulty;
}
