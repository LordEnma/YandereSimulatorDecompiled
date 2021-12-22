using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B36 RID: 6966 RVA: 0x001315FD File Offset: 0x0012F7FD
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B37 RID: 6967 RVA: 0x00131620 File Offset: 0x0012F820
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E7B RID: 11899
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E7C RID: 11900
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E7D RID: 11901
	[SerializeField]
	private float percent;
}
