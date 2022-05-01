using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F4 RID: 1268
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x06002116 RID: 8470 RVA: 0x001EA85F File Offset: 0x001E8A5F
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002117 RID: 8471 RVA: 0x001EA86C File Offset: 0x001E8A6C
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001EA874 File Offset: 0x001E8A74
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

	// Token: 0x06002119 RID: 8473 RVA: 0x001EA8CC File Offset: 0x001E8ACC
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

	// Token: 0x0600211A RID: 8474 RVA: 0x001EA8E4 File Offset: 0x001E8AE4
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
