using System;
using UnityEngine;

// Token: 0x0200030B RID: 779
public class GridScript : MonoBehaviour
{
	// Token: 0x0600184A RID: 6218 RVA: 0x000E6AC8 File Offset: 0x000E4CC8
	private void Start()
	{
		while (this.ID < this.Rows * this.Columns)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Tile, new Vector3((float)this.Row, 0f, (float)this.Column), Quaternion.identity).transform.parent = base.transform;
			this.Row++;
			if (this.Row > this.Rows)
			{
				this.Row = 1;
				this.Column++;
			}
			this.ID++;
		}
		base.transform.localScale = new Vector3(4f, 4f, 4f);
		base.transform.position = new Vector3(-52f, 0f, -52f);
	}

	// Token: 0x0400235A RID: 9050
	public GameObject Tile;

	// Token: 0x0400235B RID: 9051
	public int Row;

	// Token: 0x0400235C RID: 9052
	public int Column;

	// Token: 0x0400235D RID: 9053
	public int Rows = 25;

	// Token: 0x0400235E RID: 9054
	public int Columns = 25;

	// Token: 0x0400235F RID: 9055
	public int ID;
}
