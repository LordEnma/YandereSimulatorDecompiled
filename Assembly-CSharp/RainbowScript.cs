using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B38 RID: 6968 RVA: 0x001319F9 File Offset: 0x0012FBF9
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B39 RID: 6969 RVA: 0x00131A1C File Offset: 0x0012FC1C
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002E82 RID: 11906
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002E83 RID: 11907
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002E84 RID: 11908
	[SerializeField]
	private float percent;
}
