using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E4 RID: 1252
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020AC RID: 8364 RVA: 0x001E0E0B File Offset: 0x001DF00B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020AD RID: 8365 RVA: 0x001E0E18 File Offset: 0x001DF018
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020AE RID: 8366 RVA: 0x001E0E20 File Offset: 0x001DF020
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

	// Token: 0x060020AF RID: 8367 RVA: 0x001E0E78 File Offset: 0x001DF078
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

	// Token: 0x060020B0 RID: 8368 RVA: 0x001E0E90 File Offset: 0x001DF090
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
