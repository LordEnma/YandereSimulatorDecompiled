using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000548 RID: 1352
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002285 RID: 8837 RVA: 0x001F6561 File Offset: 0x001F4761
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x001F6569 File Offset: 0x001F4769
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002287 RID: 8839 RVA: 0x001F658F File Offset: 0x001F478F
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x001F6598 File Offset: 0x001F4798
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
