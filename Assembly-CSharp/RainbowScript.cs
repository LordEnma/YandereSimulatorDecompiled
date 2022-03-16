using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B60 RID: 7008 RVA: 0x00134775 File Offset: 0x00132975
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B61 RID: 7009 RVA: 0x00134798 File Offset: 0x00132998
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002EF6 RID: 12022
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002EF7 RID: 12023
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002EF8 RID: 12024
	[SerializeField]
	private float percent;
}
