using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B40 RID: 6976 RVA: 0x001323A9 File Offset: 0x001305A9
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B41 RID: 6977 RVA: 0x001323CC File Offset: 0x001305CC
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E92 RID: 11922
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E93 RID: 11923
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E94 RID: 11924
	[SerializeField]
	private float percent;
}
