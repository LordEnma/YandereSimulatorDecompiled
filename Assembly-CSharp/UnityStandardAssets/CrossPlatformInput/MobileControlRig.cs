using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600222A RID: 8746 RVA: 0x001ED705 File Offset: 0x001EB905
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600222B RID: 8747 RVA: 0x001ED70D File Offset: 0x001EB90D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x001ED733 File Offset: 0x001EB933
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x001ED73C File Offset: 0x001EB93C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
