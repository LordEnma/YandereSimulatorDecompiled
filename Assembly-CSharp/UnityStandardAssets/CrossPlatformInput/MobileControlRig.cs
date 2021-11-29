using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000534 RID: 1332
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x060021F9 RID: 8697 RVA: 0x001E9101 File Offset: 0x001E7301
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001E9109 File Offset: 0x001E7309
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001E912F File Offset: 0x001E732F
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001E9138 File Offset: 0x001E7338
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
