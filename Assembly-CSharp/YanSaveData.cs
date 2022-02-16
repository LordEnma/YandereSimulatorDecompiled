using System;

// Token: 0x02000506 RID: 1286
[Serializable]
public struct YanSaveData
{
	// Token: 0x040048D9 RID: 18649
	public string LoadedLevelName;

	// Token: 0x040048DA RID: 18650
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040048DB RID: 18651
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040048DC RID: 18652
	public ValueDict SerializedPlayerPrefs;
}
