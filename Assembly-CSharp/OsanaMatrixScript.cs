using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A43 RID: 6723 RVA: 0x001165AC File Offset: 0x001147AC
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

	// Token: 0x04002B0F RID: 11023
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B10 RID: 11024
	public GameObject Rivals;

	// Token: 0x04002B11 RID: 11025
	public int Phase = 1;
}
