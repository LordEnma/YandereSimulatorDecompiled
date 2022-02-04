using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E7 RID: 1255
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020BF RID: 8383 RVA: 0x001E3033 File Offset: 0x001E1233
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020C0 RID: 8384 RVA: 0x001E3040 File Offset: 0x001E1240
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x001E3048 File Offset: 0x001E1248
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

	// Token: 0x060020C2 RID: 8386 RVA: 0x001E30A0 File Offset: 0x001E12A0
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

	// Token: 0x060020C3 RID: 8387 RVA: 0x001E30B8 File Offset: 0x001E12B8
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
