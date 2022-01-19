using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B3F RID: 6975 RVA: 0x00131F65 File Offset: 0x00130165
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x00131F88 File Offset: 0x00130188
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E8C RID: 11916
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E8D RID: 11917
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E8E RID: 11918
	[SerializeField]
	private float percent;
}
