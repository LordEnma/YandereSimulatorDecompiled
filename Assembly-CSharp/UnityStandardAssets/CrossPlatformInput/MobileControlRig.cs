using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x001ECD35 File Offset: 0x001EAF35
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001ECD3D File Offset: 0x001EAF3D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001ECD63 File Offset: 0x001EAF63
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001ECD6C File Offset: 0x001EAF6C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
