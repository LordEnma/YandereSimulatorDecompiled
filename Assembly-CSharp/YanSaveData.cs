using System;

// Token: 0x02000505 RID: 1285
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048C7 RID: 18631
	public string LoadedLevelName;

	// Token: 0x040048C8 RID: 18632
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048C9 RID: 18633
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048CA RID: 18634
	public ValueDict SerializedPlayerPrefs;
}
