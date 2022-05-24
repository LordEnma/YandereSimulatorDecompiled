using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F5 RID: 1269
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x06002122 RID: 8482 RVA: 0x001EC513 File Offset: 0x001EA713
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002123 RID: 8483 RVA: 0x001EC520 File Offset: 0x001EA720
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x06002124 RID: 8484 RVA: 0x001EC528 File Offset: 0x001EA728
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

	// Token: 0x06002125 RID: 8485 RVA: 0x001EC580 File Offset: 0x001EA780
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

	// Token: 0x06002126 RID: 8486 RVA: 0x001EC598 File Offset: 0x001EA798
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
