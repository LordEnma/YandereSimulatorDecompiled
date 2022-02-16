using System;

// Token: 0x020000D5 RID: 213
[Serializable]
public class ArrayLayout
{
	// Token: 0x04000A87 RID: 2695
	public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

	// Token: 0x02000649 RID: 1609
	[Serializable]
	public struct rowData
	{
		// Token: 0x04004EA4 RID: 20132
		public bool[] row;
	}
}
