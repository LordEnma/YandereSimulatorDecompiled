using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E7 RID: 1255
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020BD RID: 8381 RVA: 0x001E2D1B File Offset: 0x001E0F1B
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020BE RID: 8382 RVA: 0x001E2D28 File Offset: 0x001E0F28
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020BF RID: 8383 RVA: 0x001E2D30 File Offset: 0x001E0F30
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

	// Token: 0x060020C0 RID: 8384 RVA: 0x001E2D88 File Offset: 0x001E0F88
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

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E2DA0 File Offset: 0x001E0FA0
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
