using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E4 RID: 1252
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020A9 RID: 8361 RVA: 0x001E081B File Offset: 0x001DEA1B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020AA RID: 8362 RVA: 0x001E0828 File Offset: 0x001DEA28
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020AB RID: 8363 RVA: 0x001E0830 File Offset: 0x001DEA30
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

	// Token: 0x060020AC RID: 8364 RVA: 0x001E0888 File Offset: 0x001DEA88
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

	// Token: 0x060020AD RID: 8365 RVA: 0x001E08A0 File Offset: 0x001DEAA0
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
