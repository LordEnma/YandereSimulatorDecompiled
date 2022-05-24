using System;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A58 RID: 6744 RVA: 0x00117A18 File Offset: 0x00115C18
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

	// Token: 0x04002B3C RID: 11068
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B3D RID: 11069
	public GameObject Rivals;

	// Token: 0x04002B3E RID: 11070
	public int Phase = 1;
}
