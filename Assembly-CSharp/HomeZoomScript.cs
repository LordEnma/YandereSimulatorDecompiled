// Decompiled with JetBrains decompiler
// Type: HomeZoomScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeZoomScript : MonoBehaviour
{
  public Transform YandereDestination;
  public bool Zoom;

  private void Update()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    if (Input.GetKeyDown(KeyCode.Z))
    {
      if (!this.Zoom)
      {
        this.Zoom = true;
        component.Play();
      }
      else
        this.Zoom = false;
    }
    if (this.Zoom)
    {
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.MoveTowards(this.transform.localPosition.y, 1.5f, Time.deltaTime * 0.0333333351f), this.transform.localPosition.z);
      this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-1.5f, 1.5f, 1f), Time.deltaTime * 0.0333333351f);
      component.volume += Time.deltaTime * 0.01f;
    }
    else
    {
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, Mathf.MoveTowards(this.transform.localPosition.y, 1f, Time.deltaTime * 10f), this.transform.localPosition.z);
      this.YandereDestination.localPosition = Vector3.MoveTowards(this.YandereDestination.localPosition, new Vector3(-2.271312f, 2f, 3.5f), Time.deltaTime * 10f);
      component.volume = 0.0f;
    }
  }
}
