using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004F2 RID: 1266
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020FE RID: 8446 RVA: 0x001E8447 File Offset: 0x001E6647
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020FF RID: 8447 RVA: 0x001E8454 File Offset: 0x001E6654
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x06002100 RID: 8448 RVA: 0x001E845C File Offset: 0x001E665C
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

	// Token: 0x06002101 RID: 8449 RVA: 0x001E84B4 File Offset: 0x001E66B4
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

	// Token: 0x06002102 RID: 8450 RVA: 0x001E84CC File Offset: 0x001E66CC
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
