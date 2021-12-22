using System;

// Token: 0x02000504 RID: 1284
[Serializable]
public struct SerializedGameObject
{
	// Token: 0x040048A6 RID: 18598
	public bool ActiveInHierarchy;

	// Token: 0x040048A7 RID: 18599
	public bool ActiveSelf;

	// Token: 0x040048A8 RID: 18600
	public bool IsStatic;

	// Token: 0x040048A9 RID: 18601
	public int Layer;

	// Token: 0x040048AA RID: 18602
	public string Tag;

	// Token: 0x040048AB RID: 18603
	public string Name;

	// Token: 0x040048AC RID: 18604
	public string ObjectID;

	// Token: 0x040048AD RID: 18605
	public SerializedComponent[] SerializedComponents;
}
