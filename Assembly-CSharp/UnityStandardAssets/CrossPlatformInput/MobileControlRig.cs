using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000538 RID: 1336
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002218 RID: 8728 RVA: 0x001EB7C5 File Offset: 0x001E99C5
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x001EB7CD File Offset: 0x001E99CD
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600221A RID: 8730 RVA: 0x001EB7F3 File Offset: 0x001E99F3
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x001EB7FC File Offset: 0x001E99FC
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
