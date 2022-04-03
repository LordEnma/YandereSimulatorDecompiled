using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000545 RID: 1349
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002261 RID: 8801 RVA: 0x001F2495 File Offset: 0x001F0695
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002262 RID: 8802 RVA: 0x001F249D File Offset: 0x001F069D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001F24C3 File Offset: 0x001F06C3
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x001F24CC File Offset: 0x001F06CC
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
