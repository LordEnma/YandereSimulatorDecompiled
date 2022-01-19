using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E7 RID: 1255
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020B9 RID: 8377 RVA: 0x001E247B File Offset: 0x001E067B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020BA RID: 8378 RVA: 0x001E2488 File Offset: 0x001E0688
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020BB RID: 8379 RVA: 0x001E2490 File Offset: 0x001E0690
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

	// Token: 0x060020BC RID: 8380 RVA: 0x001E24E8 File Offset: 0x001E06E8
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

	// Token: 0x060020BD RID: 8381 RVA: 0x001E2500 File Offset: 0x001E0700
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
