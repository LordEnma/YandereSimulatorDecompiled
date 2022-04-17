using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F3 RID: 1267
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x0600210D RID: 8461 RVA: 0x001E93D3 File Offset: 0x001E75D3
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x0600210E RID: 8462 RVA: 0x001E93E0 File Offset: 0x001E75E0
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x0600210F RID: 8463 RVA: 0x001E93E8 File Offset: 0x001E75E8
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

	// Token: 0x06002110 RID: 8464 RVA: 0x001E9440 File Offset: 0x001E7640
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

	// Token: 0x06002111 RID: 8465 RVA: 0x001E9458 File Offset: 0x001E7658
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
