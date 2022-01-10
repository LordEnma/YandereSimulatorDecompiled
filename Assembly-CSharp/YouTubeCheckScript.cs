using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E6 RID: 1254
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020B7 RID: 8375 RVA: 0x001E17AB File Offset: 0x001DF9AB
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020B8 RID: 8376 RVA: 0x001E17B8 File Offset: 0x001DF9B8
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x001E17C0 File Offset: 0x001DF9C0
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

	// Token: 0x060020BA RID: 8378 RVA: 0x001E1818 File Offset: 0x001DFA18
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

	// Token: 0x060020BB RID: 8379 RVA: 0x001E1830 File Offset: 0x001DFA30
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
