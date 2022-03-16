using System;
using UnityEngine;

// Token: 0x02000387 RID: 903
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A3D RID: 6717 RVA: 0x00115F54 File Offset: 0x00114154
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 1f, Time.deltaTime);
			return;
		}
		if (this.Phase == 3)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 0f, Time.deltaTime);
			return;
		}
		if (this.Phase == 4)
		{
			this.Rivals.SetActive(true);
		}
	}

	// Token: 0x04002AFC RID: 11004
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002AFD RID: 11005
	public GameObject Rivals;

	// Token: 0x04002AFE RID: 11006
	public int Phase = 1;
}
