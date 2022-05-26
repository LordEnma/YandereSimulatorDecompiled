// Decompiled with JetBrains decompiler
// Type: AntiCheatScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class AntiCheatScript : MonoBehaviour
{
  public AudioSource MyAudio;
  public GameObject Jukebox;
  public bool Check;

  private void Start() => this.MyAudio = this.GetComponent<AudioSource>();

  private void Update()
  {
    if (!this.Check || this.MyAudio.isPlaying)
      return;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "YandereChan"))
      return;
    this.Jukebox.SetActive(false);
    this.Check = true;
    this.MyAudio.Play();
  }
}
