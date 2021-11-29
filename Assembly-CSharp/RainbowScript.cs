using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B2E RID: 6958 RVA: 0x00130D3D File Offset: 0x0012EF3D
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x00130D60 File Offset: 0x0012EF60
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E51 RID: 11857
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E52 RID: 11858
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E53 RID: 11859
	[SerializeField]
	private float percent;
}
