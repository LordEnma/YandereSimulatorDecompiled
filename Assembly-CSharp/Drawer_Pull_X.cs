// Decompiled with JetBrains decompiler
// Type: Drawer_Pull_X
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Drawer_Pull_X : MonoBehaviour
{
  public Animator pull_01;
  public bool open;
  public Transform Player;

  private void Start() => this.open = false;

  private void OnMouseOver()
  {
    if (!(bool) (Object) this.Player || (double) Vector3.Distance(this.Player.position, this.transform.position) >= 10.0)
      return;
    MonoBehaviour.print((object) "object name");
    if (!this.open)
    {
      if (!Input.GetMouseButtonDown(0))
        return;
      this.StartCoroutine(this.opening());
    }
    else
    {
      if (!this.open || !Input.GetMouseButtonDown(0))
        return;
      this.StartCoroutine(this.closing());
    }
  }

  private IEnumerator opening()
  {
    MonoBehaviour.print((object) "you are opening the door");
    this.pull_01.Play("openpull_01");
    this.open = true;
    yield return (object) new WaitForSeconds(0.5f);
  }

  private IEnumerator closing()
  {
    MonoBehaviour.print((object) "you are closing the door");
    this.pull_01.Play("closepush_01");
    this.open = false;
    yield return (object) new WaitForSeconds(0.5f);
  }
}
