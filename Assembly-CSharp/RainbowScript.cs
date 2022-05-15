using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B7E RID: 7038 RVA: 0x00136AA1 File Offset: 0x00134CA1
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B7F RID: 7039 RVA: 0x00136AC4 File Offset: 0x00134CC4
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F3C RID: 12092
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F3D RID: 12093
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F3E RID: 12094
	[SerializeField]
	private float percent;
}
