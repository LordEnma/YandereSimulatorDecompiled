using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E9 RID: 1257
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020D2 RID: 8402 RVA: 0x001E42CB File Offset: 0x001E24CB
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x001E42D8 File Offset: 0x001E24D8
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x001E42E0 File Offset: 0x001E24E0
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

	// Token: 0x060020D5 RID: 8405 RVA: 0x001E4338 File Offset: 0x001E2538
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

	// Token: 0x060020D6 RID: 8406 RVA: 0x001E4350 File Offset: 0x001E2550
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
