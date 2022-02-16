using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Snapshot Point")]
public class UISnapshotPoint : MonoBehaviour
{
	// Token: 0x060004FF RID: 1279 RVA: 0x00031B78 File Offset: 0x0002FD78
	private void Start()
	{
		if (base.tag != "EditorOnly")
		{
			base.tag = "EditorOnly";
		}
	}

	// Token: 0x04000568 RID: 1384
	public bool isOrthographic = true;

	// Token: 0x04000569 RID: 1385
	public float nearClip = -100f;

	// Token: 0x0400056A RID: 1386
	public float farClip = 100f;

	// Token: 0x0400056B RID: 1387
	[Range(10f, 80f)]
	public int fieldOfView = 35;

	// Token: 0x0400056C RID: 1388
	public float orthoSize = 30f;

	// Token: 0x0400056D RID: 1389
	public Texture2D thumbnail;
}
