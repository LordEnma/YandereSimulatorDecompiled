using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000540 RID: 1344
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06002251 RID: 8785 RVA: 0x001F0C25 File Offset: 0x001EEE25
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06002252 RID: 8786 RVA: 0x001F0C2D File Offset: 0x001EEE2D
		private void Start()
		{
			if (UnityEngine.Object.FindObjectOfType<EventSystem>() == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06002253 RID: 8787 RVA: 0x001F0C53 File Offset: 0x001EEE53
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(false);
		}

		// Token: 0x06002254 RID: 8788 RVA: 0x001F0C5C File Offset: 0x001EEE5C
		private void EnableControlRig(bool enabled)
		{
			foreach (object obj in base.transform)
			{
				((Transform)obj).gameObject.SetActive(enabled);
			}
		}
	}
}
