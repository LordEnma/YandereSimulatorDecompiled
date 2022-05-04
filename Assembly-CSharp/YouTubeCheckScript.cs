using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F4 RID: 1268
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x06002117 RID: 8471 RVA: 0x001EA95B File Offset: 0x001E8B5B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002118 RID: 8472 RVA: 0x001EA968 File Offset: 0x001E8B68
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x06002119 RID: 8473 RVA: 0x001EA970 File Offset: 0x001E8B70
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

	// Token: 0x0600211A RID: 8474 RVA: 0x001EA9C8 File Offset: 0x001E8BC8
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

	// Token: 0x0600211B RID: 8475 RVA: 0x001EA9E0 File Offset: 0x001E8BE0
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
