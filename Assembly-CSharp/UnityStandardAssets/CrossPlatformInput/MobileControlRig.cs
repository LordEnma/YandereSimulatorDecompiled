using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000547 RID: 1351
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002279 RID: 8825 RVA: 0x001F48AD File Offset: 0x001F2AAD
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x0600227A RID: 8826 RVA: 0x001F48B5 File Offset: 0x001F2AB5
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x0600227B RID: 8827 RVA: 0x001F48DB File Offset: 0x001F2ADB
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x0600227C RID: 8828 RVA: 0x001F48E4 File Offset: 0x001F2AE4
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
