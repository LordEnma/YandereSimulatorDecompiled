using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x0600137C RID: 4988 RVA: 0x000B2DF4 File Offset: 0x000B0FF4
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x000B2ECC File Offset: 0x000B10CC
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001C9E RID: 7326
	public Transform Target;

	// Token: 0x04001C9F RID: 7327
	public UITexture Tex;
}
