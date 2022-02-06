using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

// Token: 0x020004E7 RID: 1255
public class YouTubeCheckScript : MonoBehaviour
{
	// Token: 0x060020C2 RID: 8386 RVA: 0x001E3237 File Offset: 0x001E1437
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x060020C3 RID: 8387 RVA: 0x001E3244 File Offset: 0x001E1444
	private void Start()
	{
		this.StreamAPI();
	}

	// Token: 0x060020C4 RID: 8388 RVA: 0x001E324C File Offset: 0x001E144C
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

	// Token: 0x060020C5 RID: 8389 RVA: 0x001E32A4 File Offset: 0x001E14A4
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

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E32BC File Offset: 0x001E14BC
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
