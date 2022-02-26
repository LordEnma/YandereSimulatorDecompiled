using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053B RID: 1339
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002233 RID: 8755 RVA: 0x001EE2E5 File Offset: 0x001EC4E5
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002234 RID: 8756 RVA: 0x001EE2ED File Offset: 0x001EC4ED
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x001EE313 File Offset: 0x001EC513
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x001EE31C File Offset: 0x001EC51C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
