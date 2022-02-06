using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B42 RID: 6978 RVA: 0x00132645 File Offset: 0x00130845
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x00132668 File Offset: 0x00130868
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E96 RID: 11926
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E97 RID: 11927
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E98 RID: 11928
	[SerializeField]
	private float percent;
}
