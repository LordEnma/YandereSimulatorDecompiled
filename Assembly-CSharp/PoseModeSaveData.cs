using System;
using UnityEngine;

// Token: 0x02000406 RID: 1030
[Serializable]
public class PoseModeSaveData
{
	// Token: 0x06001C38 RID: 7224 RVA: 0x0014976C File Offset: 0x0014796C
	public static PoseModeSaveData ReadFromGlobals()
	{
		return new PoseModeSaveData
		{
			posePosition = PoseModeGlobals.PosePosition,
			poseRotation = PoseModeGlobals.PoseRotation,
			poseScale = PoseModeGlobals.PoseScale
		};
	}

	// Token: 0x06001C39 RID: 7225 RVA: 0x00149794 File Offset: 0x00147994
	public static void WriteToGlobals(PoseModeSaveData data)
	{
		PoseModeGlobals.PosePosition = data.posePosition;
		PoseModeGlobals.PoseRotation = data.poseRotation;
		PoseModeGlobals.PoseScale = data.poseScale;
	}

	// Token: 0x040031C2 RID: 12738
	public Vector3 posePosition;

	// Token: 0x040031C3 RID: 12739
	public Vector3 poseRotation;

	// Token: 0x040031C4 RID: 12740
	public Vector3 poseScale;
}
