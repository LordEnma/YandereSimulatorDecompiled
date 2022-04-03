using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x0600138C RID: 5004 RVA: 0x000B3F64 File Offset: 0x000B2164
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x000B403C File Offset: 0x000B223C
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CE7 RID: 7399
	public Transform Target;

	// Token: 0x04001CE8 RID: 7400
	public UITexture Tex;
}
