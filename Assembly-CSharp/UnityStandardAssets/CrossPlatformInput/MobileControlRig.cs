using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600220A RID: 8714 RVA: 0x001EA835 File Offset: 0x001E8A35
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001EA83D File Offset: 0x001E8A3D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001EA863 File Offset: 0x001E8A63
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001EA86C File Offset: 0x001E8A6C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
