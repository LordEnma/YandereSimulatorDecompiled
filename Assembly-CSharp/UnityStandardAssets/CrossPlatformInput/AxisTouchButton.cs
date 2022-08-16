// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.AxisTouchButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class AxisTouchButton : 
    MonoBehaviour,
    IPointerDownHandler,
    IEventSystemHandler,
    IPointerUpHandler
  {
    public string axisName = "Horizontal";
    public float axisValue = 1f;
    public float responseSpeed = 3f;
    public float returnToCentreSpeed = 3f;
    private AxisTouchButton m_PairedWith;
    private CrossPlatformInputManager.VirtualAxis m_Axis;

    private void OnEnable()
    {
      if (!CrossPlatformInputManager.AxisExists(this.axisName))
      {
        this.m_Axis = new CrossPlatformInputManager.VirtualAxis(this.axisName);
        CrossPlatformInputManager.RegisterVirtualAxis(this.m_Axis);
      }
      else
        this.m_Axis = CrossPlatformInputManager.VirtualAxisReference(this.axisName);
      this.FindPairedButton();
    }

    private void FindPairedButton()
    {
      if (!(Object.FindObjectsOfType(typeof (AxisTouchButton)) is AxisTouchButton[] objectsOfType))
        return;
      for (int index = 0; index < objectsOfType.Length; ++index)
      {
        if (objectsOfType[index].axisName == this.axisName && (Object) objectsOfType[index] != (Object) this)
          this.m_PairedWith = objectsOfType[index];
      }
    }

    private void OnDisable() => this.m_Axis.Remove();

    public void OnPointerDown(PointerEventData data)
    {
      if ((Object) this.m_PairedWith == (Object) null)
        this.FindPairedButton();
      this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, this.axisValue, this.responseSpeed * Time.deltaTime));
    }

    public void OnPointerUp(PointerEventData data) => this.m_Axis.Update(Mathf.MoveTowards(this.m_Axis.GetValue, 0.0f, this.responseSpeed * Time.deltaTime));
  }
}
