// Decompiled with JetBrains decompiler
// Type: FlySwarmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FlySwarmScript : MonoBehaviour
{
  public GameObject[] FlyParent;
  public Transform AllParents;

  private void Start()
  {
    for (int index = 1; index < this.FlyParent.Length; ++index)
      this.FlyParent[index].transform.localEulerAngles = new Vector3(Random.Range(0.0f, 360f), Random.Range(0.0f, 360f), Random.Range(0.0f, 360f));
    this.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
  }

  private void Update()
  {
    this.AllParents.Rotate(Time.deltaTime * 360f, Time.deltaTime * 360f, Time.deltaTime * 360f, Space.Self);
    for (int index = 1; index < this.FlyParent.Length; ++index)
    {
      if (index < 6)
        this.FlyParent[index].transform.Rotate(0.0f, Time.deltaTime * 360f, 0.0f, Space.Self);
      else
        this.FlyParent[index].transform.Rotate(0.0f, Time.deltaTime * 360f, 0.0f, Space.Self);
    }
  }
}
