using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A93 RID: 2707
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x02000657 RID: 1623
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004FC6 RID: 20422
		public bool[] row;
	}
}
