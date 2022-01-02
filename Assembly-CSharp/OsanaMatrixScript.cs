using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A1B RID: 6683 RVA: 0x00113878 File Offset: 0x00111A78
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

	// Token: 0x04002A94 RID: 10900
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002A95 RID: 10901
	public GameObject Rivals;

	// Token: 0x04002A96 RID: 10902
	public int Phase = 1;
}
