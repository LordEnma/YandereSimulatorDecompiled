using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x001ED251 File Offset: 0x001EB451
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001ED259 File Offset: 0x001EB459
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x001ED27F File Offset: 0x001EB47F
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x001ED288 File Offset: 0x001EB488
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
