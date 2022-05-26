// Decompiled with JetBrains decompiler
// Type: DetectClickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DetectClickScript : MonoBehaviour
{
  public Vector3 OriginalPosition;
  public Color OriginalColor;
  public Collider MyCollider;
  public Camera GUICamera;
  public UISprite Sprite;
  public UILabel Label;
  public bool Clicked;

  private void Start()
  {
    this.OriginalPosition = this.transform.localPosition;
    this.OriginalColor = this.Sprite.color;
  }

  private void Update()
  {
    RaycastHit hitInfo;
    if (!Input.GetMouseButtonDown(0) || !Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f) || !((Object) hitInfo.collider == (Object) this.MyCollider) || (double) this.Label.color.a != 1.0)
      return;
    this.Sprite.color = new Color(1f, 1f, 1f, 1f);
    this.Clicked = true;
  }

  private void OnTriggerEnter()
  {
    if ((double) this.Label.color.a != 1.0)
      return;
    this.Sprite.color = Color.white;
  }

  private void OnTriggerExit() => this.Sprite.color = this.OriginalColor;
}
