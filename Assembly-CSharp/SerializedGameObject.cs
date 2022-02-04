using System;

// Token: 0x02000507 RID: 1287
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048DB RID: 18651
	public bool ActiveInHierarchy;

	// Token: 0x040048DC RID: 18652
	public bool ActiveSelf;

	// Token: 0x040048DD RID: 18653
	public bool IsStatic;

	// Token: 0x040048DE RID: 18654
	public int Layer;

	// Token: 0x040048DF RID: 18655
	public string Tag;

	// Token: 0x040048E0 RID: 18656
	public string Name;

	// Token: 0x040048E1 RID: 18657
	public string ObjectID;

	// Token: 0x040048E2 RID: 18658
	public SerializedComponent[] SerializedComponents;
}
