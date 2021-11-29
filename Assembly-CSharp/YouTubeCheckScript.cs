using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E2 RID: 1250
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x06002098 RID: 8344 RVA: 0x001DF0E7 File Offset: 0x001DD2E7
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x001DF0F4 File Offset: 0x001DD2F4
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x001DF0FC File Offset: 0x001DD2FC
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

	// Token: 0x0600209B RID: 8347 RVA: 0x001DF154 File Offset: 0x001DD354
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

	// Token: 0x0600209C RID: 8348 RVA: 0x001DF16C File Offset: 0x001DD36C
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
