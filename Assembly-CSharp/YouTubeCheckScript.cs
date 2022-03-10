using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004EA RID: 1258
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020D8 RID: 8408 RVA: 0x001E4CA3 File Offset: 0x001E2EA3
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x001E4CB0 File Offset: 0x001E2EB0
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x001E4CB8 File Offset: 0x001E2EB8
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

	// Token: 0x060020DB RID: 8411 RVA: 0x001E4D10 File Offset: 0x001E2F10
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

	// Token: 0x060020DC RID: 8412 RVA: 0x001E4D28 File Offset: 0x001E2F28
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
