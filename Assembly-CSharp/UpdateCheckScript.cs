using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateCheckScript : MonoBehaviour
{
	public UILabel warningLabel;

	public string CurrentVersionNumber;

	private void Start()
	{
		StartCoroutine(Check());
	}

	private IEnumerator Check()
	{
		using UnityWebRequest request = UnityWebRequest.Get("https://yanderesimulator.com/version.txt?{DateTimeOffset.Now.Ticks}");
		yield return request.SendWebRequest();
		if (request.result != UnityWebRequest.Result.Success)
		{
			yield break;
		}
		string text = request.downloadHandler.text;
		Debug.Log("version.txt says: " + text + ". The current version number is " + CurrentVersionNumber);
		if (text == CurrentVersionNumber)
		{
			yield break;
		}
		warningLabel.text = "[ff0000]ATTENTION![-] You are playing an [c][ff0000]OUTDATED[-][/c] build of Yandere Simulator! A new build is available for download at: \n \n yanderedev.wordpress.com";
	}
}
