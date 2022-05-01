using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x0200002E RID: 46
[RequireComponent(typeof(UITexture))]
public class DownloadTexture : MonoBehaviour
{
	// Token: 0x060000C6 RID: 198 RVA: 0x0001264C File Offset: 0x0001084C
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

	// Token: 0x060000C7 RID: 199 RVA: 0x0001265B File Offset: 0x0001085B
	private void OnDestroy()
	{
		if (this.mTex != null)
		{
			UnityEngine.Object.Destroy(this.mTex);
		}
	}

	// Token: 0x0400029B RID: 667
	public string url = "http://www.yourwebsite.com/logo.png";

	// Token: 0x0400029C RID: 668
	public bool pixelPerfect = true;

	// Token: 0x0400029D RID: 669
	private Texture2D mTex;
}
