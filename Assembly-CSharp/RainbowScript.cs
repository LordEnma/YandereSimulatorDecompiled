using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B78 RID: 7032 RVA: 0x00135E55 File Offset: 0x00134055
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B79 RID: 7033 RVA: 0x00135E78 File Offset: 0x00134078
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F27 RID: 12071
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F28 RID: 12072
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F29 RID: 12073
	[SerializeField]
	private float percent;
}
