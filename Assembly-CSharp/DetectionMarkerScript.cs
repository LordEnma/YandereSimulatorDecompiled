using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x06001388 RID: 5000 RVA: 0x000B3970 File Offset: 0x000B1B70
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x06001389 RID: 5001 RVA: 0x000B3A48 File Offset: 0x000B1C48
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CCD RID: 7373
	public Transform Target;

	// Token: 0x04001CCE RID: 7374
	public UITexture Tex;
}
