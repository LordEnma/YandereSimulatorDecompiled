using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B53 RID: 6995 RVA: 0x001338D5 File Offset: 0x00131AD5
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x001338F8 File Offset: 0x00131AF8
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002EC2 RID: 11970
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002EC3 RID: 11971
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002EC4 RID: 11972
	[SerializeField]
	private float percent;
}
