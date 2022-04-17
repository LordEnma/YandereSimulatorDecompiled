using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000546 RID: 1350
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002270 RID: 8816 RVA: 0x001F3421 File Offset: 0x001F1621
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001F3429 File Offset: 0x001F1629
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002272 RID: 8818 RVA: 0x001F344F File Offset: 0x001F164F
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002273 RID: 8819 RVA: 0x001F3458 File Offset: 0x001F1658
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
