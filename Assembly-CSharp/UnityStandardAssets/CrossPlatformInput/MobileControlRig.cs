using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600221A RID: 8730 RVA: 0x001EC495 File Offset: 0x001EA695
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001EC49D File Offset: 0x001EA69D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x001EC4C3 File Offset: 0x001EA6C3
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x001EC4CC File Offset: 0x001EA6CC
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
