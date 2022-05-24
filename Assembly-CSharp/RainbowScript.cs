using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B7F RID: 7039 RVA: 0x00136D3D File Offset: 0x00134F3D
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B80 RID: 7040 RVA: 0x00136D60 File Offset: 0x00134F60
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F44 RID: 12100
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F45 RID: 12101
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F46 RID: 12102
	[SerializeField]
	private float percent;
}
