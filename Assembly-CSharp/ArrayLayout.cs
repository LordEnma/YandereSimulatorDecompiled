using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A91 RID: 2705
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x02000655 RID: 1621
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004F66 RID: 20326
		public bool[] row;
	}
}
