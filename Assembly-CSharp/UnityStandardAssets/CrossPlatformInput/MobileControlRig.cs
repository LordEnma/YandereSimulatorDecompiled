using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x0600227A RID: 8826 RVA: 0x001F49A9 File Offset: 0x001F2BA9
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001F49B1 File Offset: 0x001F2BB1
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001F49D7 File Offset: 0x001F2BD7
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600227D RID: 8829 RVA: 0x001F49E0 File Offset: 0x001F2BE0
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
