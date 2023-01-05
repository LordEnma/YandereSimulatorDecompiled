using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class YouTubeCheckScript : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		StreamAPI();
	}

	private void StreamAPI()
	{
		try
		{
			string obj = Environment.GetCommandLineArgs()[1];
			string text = Environment.GetCommandLineArgs()[2];
			if (obj == "-key")
			{
				Debug.Log("I see a key: " + text.ToString());
				GetPosts();
			}
		}
		catch (Exception)
		{
		}
	}

	private IEnumerator GetRequest(string url, Action<UnityWebRequest> callback)
	{
		UnityWebRequest unityWebRequest;
		UnityWebRequest request = (unityWebRequest = UnityWebRequest.Get(url));
		using (unityWebRequest)
		{
			yield return request.SendWebRequest();
			callback(request);
		}
	}

	public void GetPosts()
	{
		string url = Environment.GetCommandLineArgs()[2].ToString() ?? "";
		StartCoroutine(GetRequest(url, delegate(UnityWebRequest req)
		{
			Debug.Log("Test. Does this work?");
			Debug.Log(req.downloadHandler.text);
		}));
	}
}
