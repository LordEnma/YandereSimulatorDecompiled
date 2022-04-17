using System;
using System.Collections.Generic;

// Token: 0x02000403 RID: 1027
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C33 RID: 7219 RVA: 0x001493C0 File Offset: 0x001475C0
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

	// Token: 0x06001C34 RID: 7220 RVA: 0x00149458 File Offset: 0x00147658
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

	// Token: 0x040031A1 RID: 12705
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040031A2 RID: 12706
	public int missionDifficulty;

	// Token: 0x040031A3 RID: 12707
	public bool missionMode;

	// Token: 0x040031A4 RID: 12708
	public int missionRequiredClothing;

	// Token: 0x040031A5 RID: 12709
	public int missionRequiredDisposal;

	// Token: 0x040031A6 RID: 12710
	public int missionRequiredWeapon;

	// Token: 0x040031A7 RID: 12711
	public int missionTarget;

	// Token: 0x040031A8 RID: 12712
	public string missionTargetName = string.Empty;

	// Token: 0x040031A9 RID: 12713
	public int nemesisDifficulty;
}
