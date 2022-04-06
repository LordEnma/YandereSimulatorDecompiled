using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F3 RID: 1267
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x06002106 RID: 8454 RVA: 0x001E8977 File Offset: 0x001E6B77
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002107 RID: 8455 RVA: 0x001E8984 File Offset: 0x001E6B84
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x06002108 RID: 8456 RVA: 0x001E898C File Offset: 0x001E6B8C
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

	// Token: 0x06002109 RID: 8457 RVA: 0x001E89E4 File Offset: 0x001E6BE4
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

	// Token: 0x0600210A RID: 8458 RVA: 0x001E89FC File Offset: 0x001E6BFC
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
