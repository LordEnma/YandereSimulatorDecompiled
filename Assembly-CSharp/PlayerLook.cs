// Decompiled with JetBrains decompiler
// Type: PlayerLook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PlayerLook : MonoBehaviour
{
  [SerializeField]
  private string mouseXInputName;
  [SerializeField]
  private string mouseYInputName;
  [SerializeField]
  private float mouseSensitivity;
  [SerializeField]
  private Transform playerBody;
  private float xAxisClamp;

  private void Awake()
  {
    this.LockCursor();
    this.xAxisClamp = 0.0f;
  }

  private void LockCursor() => Cursor.lockState = CursorLockMode.Locked;

  private void Update() => this.CameraRotation();

  private void CameraRotation()
  {
    float num1 = Input.GetAxis(this.mouseXInputName) * this.mouseSensitivity * Time.deltaTime;
    float num2 = Input.GetAxis(this.mouseYInputName) * this.mouseSensitivity * Time.deltaTime;
    this.xAxisClamp += num2;
    if ((double) this.xAxisClamp > 90.0)
    {
      this.xAxisClamp = 90f;
      num2 = 0.0f;
      this.ClampXAxisRotationToValue(270f);
    }
    else if ((double) this.xAxisClamp < -90.0)
    {
      this.xAxisClamp = -90f;
      num2 = 0.0f;
      this.ClampXAxisRotationToValue(90f);
    }
    this.transform.Rotate(Vector3.left * num2);
    this.playerBody.Rotate(Vector3.up * num1);
  }

  private void ClampXAxisRotationToValue(float value) => this.transform.eulerAngles = this.transform.eulerAngles with
  {
    x = value
  };
}
