using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public sealed class AmplifyMotionPostProcess : MonoBehaviour
{
	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x0600095F RID: 2399 RVA: 0x0004B589 File Offset: 0x00049789
	// (set) Token: 0x06000960 RID: 2400 RVA: 0x0004B591 File Offset: 0x00049791
	public AmplifyMotionEffectBase Instance
	{
		get
		{
			return this.m_instance;
		}
		set
		{
			this.m_instance = value;
		}
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x0004B59A File Offset: 0x0004979A
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_instance != null)
		{
			this.m_instance.PostProcess(source, destination);
		}
	}

	// Token: 0x0400080B RID: 2059
	private AmplifyMotionEffectBase m_instance;
}
