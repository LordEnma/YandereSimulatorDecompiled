using System;
using UnityEngine;

// Token: 0x020003CC RID: 972
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B6A RID: 7018 RVA: 0x001351E9 File Offset: 0x001333E9
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B6B RID: 7019 RVA: 0x0013520C File Offset: 0x0013340C
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F0F RID: 12047
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F10 RID: 12048
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F11 RID: 12049
	[SerializeField]
	private float percent;
}
