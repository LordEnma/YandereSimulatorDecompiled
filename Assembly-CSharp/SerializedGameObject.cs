using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048DE RID: 18654
	public bool ActiveInHierarchy;

	// Token: 0x040048DF RID: 18655
	public bool ActiveSelf;

	// Token: 0x040048E0 RID: 18656
	public bool IsStatic;

	// Token: 0x040048E1 RID: 18657
	public int Layer;

	// Token: 0x040048E2 RID: 18658
	public string Tag;

	// Token: 0x040048E3 RID: 18659
	public string Name;

	// Token: 0x040048E4 RID: 18660
	public string ObjectID;

	// Token: 0x040048E5 RID: 18661
	public SerializedComponent[] SerializedComponents;
}
