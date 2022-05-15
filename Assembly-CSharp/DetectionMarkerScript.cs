using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
	// Token: 0x06001398 RID: 5016 RVA: 0x000B48B4 File Offset: 0x000B2AB4
	private void Start()
	{
		base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		this.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0f);
	}

	// Token: 0x06001399 RID: 5017 RVA: 0x000B498C File Offset: 0x000B2B8C
	private void Update()
	{
		if (this.Tex.color.a > 0f && base.transform != null && this.Target != null)
		{
			base.transform.LookAt(new Vector3(this.Target.position.x, base.transform.position.y, this.Target.position.z));
		}
	}

	// Token: 0x04001CF9 RID: 7417
	public Transform Target;

	// Token: 0x04001CFA RID: 7418
	public UITexture Tex;
}
