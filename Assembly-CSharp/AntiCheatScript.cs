// Decompiled with JetBrains decompiler
// Type: AntiCheatScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
