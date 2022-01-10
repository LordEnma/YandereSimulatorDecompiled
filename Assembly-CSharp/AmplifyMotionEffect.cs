using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Amplify Motion")]
public class AmplifyMotionEffect : AmplifyMotionEffectBase
{
	// Token: 0x170001ED RID: 493
	// (get) Token: 0x06000948 RID: 2376 RVA: 0x0004ADA8 File Offset: 0x00048FA8
	public new static AmplifyMotionEffect FirstInstance
	{
		get
		{
			return (AmplifyMotionEffect)AmplifyMotionEffectBase.FirstInstance;
		}
	}

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x06000949 RID: 2377 RVA: 0x0004ADB4 File Offset: 0x00048FB4
	public new static AmplifyMotionEffect Instance
	{
		get
		{
			return (AmplifyMotionEffect)AmplifyMotionEffectBase.Instance;
		}
	}
}
