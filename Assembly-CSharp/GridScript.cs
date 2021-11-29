using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public class GridScript : MonoBehaviour
{
	// Token: 0x06001811 RID: 6161 RVA: 0x000E36BC File Offset: 0x000E18BC
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

	// Token: 0x040022D0 RID: 8912
	public GameObject Tile;

	// Token: 0x040022D1 RID: 8913
	public int Row;

	// Token: 0x040022D2 RID: 8914
	public int Column;

	// Token: 0x040022D3 RID: 8915
	public int Rows = 25;

	// Token: 0x040022D4 RID: 8916
	public int Columns = 25;

	// Token: 0x040022D5 RID: 8917
	public int ID;
}
