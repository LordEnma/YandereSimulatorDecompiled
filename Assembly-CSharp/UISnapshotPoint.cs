using System;
using UnityEngine;

// Token: 0x02000083 RID: 131
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Internal/Snapshot Point")]
public class UISnapshotPoint : MonoBehaviour
{
	// Token: 0x060004FF RID: 1279 RVA: 0x00031E68 File Offset: 0x00030068
	private void Start()
	{
		if (base.tag != "EditorOnly")
		{
			base.tag = "EditorOnly";
		}
	}

	// Token: 0x04000573 RID: 1395
	public bool isOrthographic = true;

	// Token: 0x04000574 RID: 1396
	public float nearClip = -100f;

	// Token: 0x04000575 RID: 1397
	public float farClip = 100f;

	// Token: 0x04000576 RID: 1398
	[Range(10f, 80f)]
	public int fieldOfView = 35;

	// Token: 0x04000577 RID: 1399
	public float orthoSize = 30f;

	// Token: 0x04000578 RID: 1400
	public Texture2D thumbnail;
}
