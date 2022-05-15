using System;

// Token: 0x02000516 RID: 1302
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040049F8 RID: 18936
	public bool ActiveInHierarchy;

	// Token: 0x040049F9 RID: 18937
	public bool ActiveSelf;

	// Token: 0x040049FA RID: 18938
	public bool IsStatic;

	// Token: 0x040049FB RID: 18939
	public int Layer;

	// Token: 0x040049FC RID: 18940
	public string Tag;

	// Token: 0x040049FD RID: 18941
	public string Name;

	// Token: 0x040049FE RID: 18942
	public string ObjectID;

	// Token: 0x040049FF RID: 18943
	public SerializedComponent[] SerializedComponents;
}
