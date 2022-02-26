using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B52 RID: 6994 RVA: 0x001333BD File Offset: 0x001315BD
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B53 RID: 6995 RVA: 0x001333E0 File Offset: 0x001315E0
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002EAC RID: 11948
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002EAD RID: 11949
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002EAE RID: 11950
	[SerializeField]
	private float percent;
}
