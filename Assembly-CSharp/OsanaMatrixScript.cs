using System;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A57 RID: 6743 RVA: 0x001177E8 File Offset: 0x001159E8
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

	// Token: 0x04002B35 RID: 11061
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002B36 RID: 11062
	public GameObject Rivals;

	// Token: 0x04002B37 RID: 11063
	public int Phase = 1;
}
