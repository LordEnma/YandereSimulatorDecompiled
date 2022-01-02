using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Snapshot Point")]
public class UISnapshotPoint : MonoBehaviour
{
	// Token: 0x060004FF RID: 1279 RVA: 0x00031B80 File Offset: 0x0002FD80
	private void Start()
	{
		if (base.tag != "EditorOnly")
		{
			base.tag = "EditorOnly";
		}
	}

	// Token: 0x04000566 RID: 1382
	public bool isOrthographic = true;

	// Token: 0x04000567 RID: 1383
	public float nearClip = -100f;

	// Token: 0x04000568 RID: 1384
	public float farClip = 100f;

	// Token: 0x04000569 RID: 1385
	[Range(10f, 80f)]
	public int fieldOfView = 35;

	// Token: 0x0400056A RID: 1386
	public float orthoSize = 30f;

	// Token: 0x0400056B RID: 1387
	public Texture2D thumbnail;
}
