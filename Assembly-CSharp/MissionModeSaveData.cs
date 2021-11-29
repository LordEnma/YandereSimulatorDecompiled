using System;
using System.Collections.Generic;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001BEA RID: 7146 RVA: 0x001432A0 File Offset: 0x001414A0
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

	// Token: 0x06001BEB RID: 7147 RVA: 0x00143338 File Offset: 0x00141538
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

	// Token: 0x040030D4 RID: 12500
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040030D5 RID: 12501
	public int missionDifficulty;

	// Token: 0x040030D6 RID: 12502
	public bool missionMode;

	// Token: 0x040030D7 RID: 12503
	public int missionRequiredClothing;

	// Token: 0x040030D8 RID: 12504
	public int missionRequiredDisposal;

	// Token: 0x040030D9 RID: 12505
	public int missionRequiredWeapon;

	// Token: 0x040030DA RID: 12506
	public int missionTarget;

	// Token: 0x040030DB RID: 12507
	public string missionTargetName = string.Empty;

	// Token: 0x040030DC RID: 12508
	public int nemesisDifficulty;
}
