using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x0200002E RID: 46
[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	// Token: 0x060000C6 RID: 198 RVA: 0x0001235C File Offset: 0x0001055C
	private IEnumerator Start()
	{
		UnityWebRequest www = UnityWebRequest.Get(this.url);
		yield return www.SendWebRequest();
		this.mTex = DownloadHandlerTexture.GetContent(www);
		if (this.mTex != null)
		{
			UITexture component = base.GetComponent<UITexture>();
			component.mainTexture = this.mTex;
			if (this.pixelPerfect)
			{
				component.MakePixelPerfect();
			}
		}
		www.Dispose();
		yield break;
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0001236B File Offset: 0x0001056B
	private void OnDestroy()
	{
		if (this.mTex != null)
		{
			UnityEngine.Object.Destroy(this.mTex);
		}
	}

	// Token: 0x0400028F RID: 655
	public string url = "http://www.yourwebsite.com/logo.png";

	// Token: 0x04000290 RID: 656
	public bool pixelPerfect = true;

	// Token: 0x04000291 RID: 657
	private Texture2D mTex;
}
