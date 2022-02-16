using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E8 RID: 1256
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020C9 RID: 8393 RVA: 0x001E36EB File Offset: 0x001E18EB
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x001E36F8 File Offset: 0x001E18F8
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x001E3700 File Offset: 0x001E1900
	private void StreamAPI()
	{
		try
		{
			string a = Environment.GetCommandLineArgs()[1];
			string text = Environment.GetCommandLineArgs()[2];
			if (a == "-key")
			{
				Debug.Log("I see a key: " + text.ToString());
				this.GetPosts();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x001E3758 File Offset: 0x001E1958
	private IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
	{
		UnityWebRequest request = null;
		using (request = UnityWebRequest.Get(url))
		{
			yield return request.SendWebRequest();
			callback(request);
		}
		UnityWebRequest unityWebRequest = null;
		request = null;
		yield break;
		yield break;
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x001E3770 File Offset: 0x001E1970
	public void GetPosts()
	{
		string url = Environment.GetCommandLineArgs()[2].ToString() ?? "";
		base.StartCoroutine(this.GetRequest(url, delegate(UnityWebRequest req)
		{
			Debug.Log("Test. Does this work?");
			Debug.Log(req.downloadHandler.text);
		}));
	}
}
