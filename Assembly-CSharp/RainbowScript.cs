using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class RainbowScript : MonoBehaviour
{
	// Token: 0x06001B70 RID: 7024 RVA: 0x00135401 File Offset: 0x00133601
	private void Start()
	{
		this.MyRenderer.material.color = Color.red;
		this.cyclesPerSecond = 0.25f;
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x00135424 File Offset: 0x00133624
	private void Update()
	{
		this.percent = (this.percent + Time.deltaTime * this.cyclesPerSecond) % 1f;
		this.MyRenderer.material.color = Color.HSVToRGB(this.percent, 1f, 1f);
	}

	// Token: 0x04002F12 RID: 12050
	[SerializeField]
	private Renderer MyRenderer;

	// Token: 0x04002F13 RID: 12051
	[SerializeField]
	private float cyclesPerSecond;

	// Token: 0x04002F14 RID: 12052
	[SerializeField]
	private float percent;
}
