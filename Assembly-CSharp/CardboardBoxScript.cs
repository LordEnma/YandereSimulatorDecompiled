// Decompiled with JetBrains decompiler
// Type: CardboardBoxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CardboardBoxScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Start() => Physics.IgnoreCollision(this.Prompt.Yandere.GetComponent<Collider>(), this.GetComponent<Collider>());

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.MyCollider.enabled = false;
      this.Prompt.Circle[0].fillAmount = 1f;
      this.GetComponent<Rigidbody>().isKinematic = true;
      this.GetComponent<Rigidbody>().useGravity = false;
      this.Prompt.enabled = false;
      this.Prompt.Hide();
      this.transform.parent = this.Prompt.Yandere.Hips;
      this.transform.localPosition = new Vector3(0.0f, -0.3f, 0.21f);
      this.transform.localEulerAngles = new Vector3(-13.333f, 0.0f, 0.0f);
    }
    if (!((Object) this.transform.parent == (Object) this.Prompt.Yandere.Hips))
      return;
    this.transform.localEulerAngles = Vector3.zero;
    if (this.Prompt.Yandere.Stance.Current != StanceType.Crawling)
      this.transform.eulerAngles = new Vector3(0.0f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    if (!Input.GetButtonDown("RB"))
      return;
    this.Prompt.MyCollider.enabled = true;
    this.GetComponent<Rigidbody>().isKinematic = false;
    this.GetComponent<Rigidbody>().useGravity = true;
    this.transform.parent = (Transform) null;
    this.Prompt.enabled = true;
  }
}
