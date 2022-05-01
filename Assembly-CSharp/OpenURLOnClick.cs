using System;
using UnityEngine;

// Token: 0x02000035 RID: 53
public class OpenURLOnClick : MonoBehaviour
{
	// Token: 0x060000DE RID: 222 RVA: 0x00012A68 File Offset: 0x00010C68
	private void OnClick()
	{
		UILabel component = base.GetComponent<UILabel>();
		if (component != null)
		{
			string urlAtPosition = component.GetUrlAtPosition(UICamera.lastWorldPosition);
			if (!string.IsNullOrEmpty(urlAtPosition))
			{
				Application.OpenURL(urlAtPosition);
			}
		}
	}
}
