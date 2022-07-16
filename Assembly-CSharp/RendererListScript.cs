// Decompiled with JetBrains decompiler
// Type: RendererListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RendererListScript : MonoBehaviour
{
  public Renderer[] Renderers;

  private void Start()
  {
    Transform[] componentsInChildren = this.gameObject.GetComponentsInChildren<Transform>();
    int index = 0;
    foreach (Transform transform in componentsInChildren)
    {
      if ((Object) transform.gameObject.GetComponent<Renderer>() != (Object) null)
      {
        this.Renderers[index] = transform.gameObject.GetComponent<Renderer>();
        ++index;
      }
    }
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.LeftControl))
      return;
    foreach (Renderer renderer in this.Renderers)
      renderer.enabled = !renderer.enabled;
  }
}
