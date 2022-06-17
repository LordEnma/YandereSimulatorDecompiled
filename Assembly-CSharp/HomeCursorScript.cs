// Decompiled with JetBrains decompiler
// Type: HomeCursorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeCursorScript : MonoBehaviour
{
  public PhotoGalleryScript PhotoGallery;
  public GameObject Photograph;
  public Transform Highlight;
  public GameObject Tack;
  public Transform CircleHighlight;

  private void OnTriggerExit(Collider other)
  {
    if ((Object) other.gameObject == (Object) this.Photograph)
      this.PhotographNull();
    if (!((Object) other.gameObject == (Object) this.Tack))
      return;
    this.CircleHighlight.position = new Vector3(this.CircleHighlight.position.x, 100f, this.Highlight.position.z);
    this.Tack = (GameObject) null;
    this.PhotoGallery.UpdateButtonPrompts();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer == 16)
    {
      if (!((Object) this.Tack == (Object) null))
        return;
      this.Photograph = other.gameObject;
      this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
      this.Highlight.localPosition = this.Photograph.transform.localPosition;
      this.Highlight.localScale = new Vector3(this.Photograph.transform.localScale.x * 1.12f, this.Photograph.transform.localScale.y * 1.2f, 1f);
      this.PhotoGallery.UpdateButtonPrompts();
    }
    else
    {
      if (!(other.gameObject.name != "SouthWall"))
        return;
      this.Tack = other.gameObject;
      this.CircleHighlight.position = this.Tack.transform.position;
      this.PhotoGallery.UpdateButtonPrompts();
      this.PhotographNull();
    }
  }

  private void PhotographNull()
  {
    this.Highlight.position = new Vector3(this.Highlight.position.x, 100f, this.Highlight.position.z);
    this.Photograph = (GameObject) null;
    this.PhotoGallery.UpdateButtonPrompts();
  }
}
