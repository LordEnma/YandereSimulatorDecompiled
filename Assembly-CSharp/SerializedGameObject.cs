using System;

// Token: 0x02000515 RID: 1301
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040049D1 RID: 18897
	public bool ActiveInHierarchy;

	// Token: 0x040049D2 RID: 18898
	public bool ActiveSelf;

	// Token: 0x040049D3 RID: 18899
	public bool IsStatic;

	// Token: 0x040049D4 RID: 18900
	public int Layer;

	// Token: 0x040049D5 RID: 18901
	public string Tag;

	// Token: 0x040049D6 RID: 18902
	public string Name;

	// Token: 0x040049D7 RID: 18903
	public string ObjectID;

	// Token: 0x040049D8 RID: 18904
	public SerializedComponent[] SerializedComponents;
}
