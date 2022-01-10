using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B3F RID: 6975 RVA: 0x00131D95 File Offset: 0x0012FF95
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B40 RID: 6976 RVA: 0x00131DB8 File Offset: 0x0012FFB8
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E88 RID: 11912
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E89 RID: 11913
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E8A RID: 11914
	[SerializeField]
	private float percent;
}
