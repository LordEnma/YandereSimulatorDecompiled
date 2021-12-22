using System;
using UnityEngine;

// Token: 0x02000281 RID: 641
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x06001383 RID: 4995 RVA: 0x000B336C File Offset: 0x000B156C
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x000B3444 File Offset: 0x000B1644
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CBE RID: 7358
	public Transform Target;

	// Token: 0x04001CBF RID: 7359
	public UITexture Tex;
}
