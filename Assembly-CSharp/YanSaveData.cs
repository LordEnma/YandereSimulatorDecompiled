using System;

// Token: 0x02000514 RID: 1300
[Serializable]
public struct YanSaveData
{
	// Token: 0x040049F3 RID: 18931
	public string LoadedLevelName;

	// Token: 0x040049F4 RID: 18932
	public SerializedGameObject[] SerializedGameObjects;

	// Token: 0x040049F5 RID: 18933
	public SerializedStaticClass[] SerializedStaticClasses;

	// Token: 0x040049F6 RID: 18934
	public ValueDict SerializedPlayerPrefs;
}
