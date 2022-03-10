using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053C RID: 1340
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002239 RID: 8761 RVA: 0x001EECBD File Offset: 0x001ECEBD
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x001EECC5 File Offset: 0x001ECEC5
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600223B RID: 8763 RVA: 0x001EECEB File Offset: 0x001ECEEB
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x001EECF4 File Offset: 0x001ECEF4
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
