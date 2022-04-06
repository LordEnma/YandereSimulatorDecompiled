using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002269 RID: 8809 RVA: 0x001F29C5 File Offset: 0x001F0BC5
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600226A RID: 8810 RVA: 0x001F29CD File Offset: 0x001F0BCD
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600226B RID: 8811 RVA: 0x001F29F3 File Offset: 0x001F0BF3
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x001F29FC File Offset: 0x001F0BFC
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
