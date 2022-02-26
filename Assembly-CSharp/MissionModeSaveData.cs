using System;
using System.Collections.Generic;

// Token: 0x020003FE RID: 1022
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x00146E30 File Offset: 0x00145030
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

	// Token: 0x06001C11 RID: 7185 RVA: 0x00146EC8 File Offset: 0x001450C8
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

	// Token: 0x04003130 RID: 12592
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x04003131 RID: 12593
	public int missionDifficulty;

	// Token: 0x04003132 RID: 12594
	public bool missionMode;

	// Token: 0x04003133 RID: 12595
	public int missionRequiredClothing;

	// Token: 0x04003134 RID: 12596
	public int missionRequiredDisposal;

	// Token: 0x04003135 RID: 12597
	public int missionRequiredWeapon;

	// Token: 0x04003136 RID: 12598
	public int missionTarget;

	// Token: 0x04003137 RID: 12599
	public string missionTargetName = string.Empty;

	// Token: 0x04003138 RID: 12600
	public int nemesisDifficulty;
}
