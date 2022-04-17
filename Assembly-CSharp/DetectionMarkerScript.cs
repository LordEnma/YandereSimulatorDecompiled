using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x06001392 RID: 5010 RVA: 0x000B41D4 File Offset: 0x000B23D4
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x000B42AC File Offset: 0x000B24AC
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CEA RID: 7402
	public Transform Target;

	// Token: 0x04001CEB RID: 7403
	public UITexture Tex;
}
