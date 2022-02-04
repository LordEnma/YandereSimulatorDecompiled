using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000539 RID: 1337
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002220 RID: 8736 RVA: 0x001ED04D File Offset: 0x001EB24D
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x001ED055 File Offset: 0x001EB255
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x001ED07B File Offset: 0x001EB27B
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x001ED084 File Offset: 0x001EB284
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
