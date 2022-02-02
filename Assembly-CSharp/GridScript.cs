using System;
using UnityEngine;

// Token: 0x02000307 RID: 775
public class GridScript : MonoBehaviour
{
	// Token: 0x0600181F RID: 6175 RVA: 0x000E497C File Offset: 0x000E2B7C
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

	// Token: 0x04002300 RID: 8960
	public GameObject Tile;

	// Token: 0x04002301 RID: 8961
	public int Row;

	// Token: 0x04002302 RID: 8962
	public int Column;

	// Token: 0x04002303 RID: 8963
	public int Rows = 25;

	// Token: 0x04002304 RID: 8964
	public int Columns = 25;

	// Token: 0x04002305 RID: 8965
	public int ID;
}
