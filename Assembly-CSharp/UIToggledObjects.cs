// Decompiled with JetBrains decompiler
// Type: UIToggledObjects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Toggled Objects")]
public class UIToggledObjects : MonoBehaviour
{
  public List<GameObject> activate;
  public List<GameObject> deactivate;
  [HideInInspector]
  [SerializeField]
  private GameObject target;
  [HideInInspector]
  [SerializeField]
  private bool inverse;

  private void Awake()
  {
    if ((Object) this.target != (Object) null)
    {
      if (this.activate.Count == 0 && this.deactivate.Count == 0)
      {
        if (this.inverse)
          this.deactivate.Add(this.target);
        else
          this.activate.Add(this.target);
      }
      else
        this.target = (GameObject) null;
    }
    EventDelegate.Add(this.GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
  }

  public void Toggle()
  {
    bool state = UIToggle.current.value;
    if (!this.enabled)
      return;
    for (int index = 0; index < this.activate.Count; ++index)
      this.Set(this.activate[index], state);
    for (int index = 0; index < this.deactivate.Count; ++index)
      this.Set(this.deactivate[index], !state);
  }

  private void Set(GameObject go, bool state)
  {
    if (!((Object) go != (Object) null))
      return;
    NGUITools.SetActive(go, state);
  }
}
