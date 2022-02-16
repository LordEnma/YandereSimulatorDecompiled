using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B49 RID: 6985 RVA: 0x00132975 File Offset: 0x00130B75
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x00132998 File Offset: 0x00130B98
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E9C RID: 11932
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E9D RID: 11933
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E9E RID: 11934
	[SerializeField]
	private float percent;
}
