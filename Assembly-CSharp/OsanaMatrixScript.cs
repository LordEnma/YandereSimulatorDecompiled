using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A51 RID: 6737 RVA: 0x00116F44 File Offset: 0x00115144
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

	// Token: 0x04002B23 RID: 11043
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B24 RID: 11044
	public GameObject Rivals;

	// Token: 0x04002B25 RID: 11045
	public int Phase = 1;
}
