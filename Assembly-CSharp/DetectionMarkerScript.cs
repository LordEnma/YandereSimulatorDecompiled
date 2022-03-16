using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x0600138B RID: 5003 RVA: 0x000B3EB4 File Offset: 0x000B20B4
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x000B3F8C File Offset: 0x000B218C
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CE4 RID: 7396
	public Transform Target;

	// Token: 0x04001CE5 RID: 7397
	public UITexture Tex;
}
