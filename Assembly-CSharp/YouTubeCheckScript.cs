// Decompiled with JetBrains decompiler
// Type: YouTubeCheckScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class YouTubeCheckScript : MonoBehaviour
{
  private void Awake() => UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);

  private void Start() => this.StreamAPI();

  private void StreamAPI()
  {
    try
    {
      string commandLineArg1 = Environment.GetCommandLineArgs()[1];
      string commandLineArg2 = Environment.GetCommandLineArgs()[2];
      if (!(commandLineArg1 == "-key"))
        return;
      Debug.Log((object) ("I see a key: " + commandLineArg2.ToString()));
      this.GetPosts();
    }
    catch (Exception ex)
    {
    }
  }

  private IEnumerator GetRequest(string url, System.Action<UnityWebRequest> callback)
  {
    UnityWebRequest request = (UnityWebRequest) null;
    using (request = UnityWebRequest.Get(url))
    {
      yield return (object) request.SendWebRequest();
      callback(request);
    }
    request = (UnityWebRequest) null;
  }

  public void GetPosts() => this.StartCoroutine(this.GetRequest(Environment.GetCommandLineArgs()[2].ToString() ?? "", (System.Action<UnityWebRequest>) (req =>
  {
    Debug.Log((object) "Test. Does this work?");
    Debug.Log((object) req.downloadHandler.text);
  })));
}
