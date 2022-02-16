using System;

// Token: 0x02000508 RID: 1288
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048E7 RID: 18663
	public bool ActiveInHierarchy;

	// Token: 0x040048E8 RID: 18664
	public bool ActiveSelf;

	// Token: 0x040048E9 RID: 18665
	public bool IsStatic;

	// Token: 0x040048EA RID: 18666
	public int Layer;

	// Token: 0x040048EB RID: 18667
	public string Tag;

	// Token: 0x040048EC RID: 18668
	public string Name;

	// Token: 0x040048ED RID: 18669
	public string ObjectID;

	// Token: 0x040048EE RID: 18670
	public SerializedComponent[] SerializedComponents;
}
