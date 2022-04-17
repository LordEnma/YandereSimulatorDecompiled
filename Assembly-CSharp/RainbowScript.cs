using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B74 RID: 7028 RVA: 0x00135811 File Offset: 0x00133A11
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x00135834 File Offset: 0x00133A34
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F1D RID: 12061
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F1E RID: 12062
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F1F RID: 12063
	[SerializeField]
	private float percent;
}
