using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004EE RID: 1262
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020F0 RID: 8432 RVA: 0x001E6C0B File Offset: 0x001E4E0B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x001E6C18 File Offset: 0x001E4E18
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x001E6C20 File Offset: 0x001E4E20
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

	// Token: 0x060020F3 RID: 8435 RVA: 0x001E6C78 File Offset: 0x001E4E78
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

	// Token: 0x060020F4 RID: 8436 RVA: 0x001E6C90 File Offset: 0x001E4E90
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
