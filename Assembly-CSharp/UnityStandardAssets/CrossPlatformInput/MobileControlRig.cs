using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600220D RID: 8717 RVA: 0x001EAE25 File Offset: 0x001E9025
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600220E RID: 8718 RVA: 0x001EAE2D File Offset: 0x001E902D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001EAE53 File Offset: 0x001E9053
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001EAE5C File Offset: 0x001E905C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
