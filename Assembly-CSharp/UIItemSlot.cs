// Decompiled with JetBrains decompiler
// Type: UIItemSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public abstract class UIItemSlot : MonoBehaviour
{
  public UISprite icon;
  public UIWidget background;
  public UILabel label;
  public AudioClip grabSound;
  public AudioClip placeSound;
  public AudioClip errorSound;
  private InvGameItem mItem;
  private string mText = "";
  private static InvGameItem mDraggedItem;

  protected abstract InvGameItem observedItem { get; }

  protected abstract InvGameItem Replace(InvGameItem item);

  private void OnTooltip(bool show)
  {
    InvGameItem invGameItem = show ? this.mItem : (InvGameItem) null;
    if (invGameItem != null)
    {
      InvBaseItem baseItem = invGameItem.baseItem;
      if (baseItem != null)
      {
        string text = "[" + NGUIText.EncodeColor(invGameItem.color) + "]" + invGameItem.name + "[-]\n" + "[AFAFAF]Level " + invGameItem.itemLevel.ToString() + " " + baseItem.slot.ToString();
        List<InvStat> stats = invGameItem.CalculateStats();
        int index = 0;
        for (int count = stats.Count; index < count; ++index)
        {
          InvStat invStat = stats[index];
          if (invStat.amount != 0)
          {
            string str = invStat.amount >= 0 ? text + "\n[00FF00]+" + invStat.amount.ToString() : text + "\n[FF0000]" + invStat.amount.ToString();
            if (invStat.modifier == InvStat.Modifier.Percent)
              str += "%";
            text = str + " " + invStat.id.ToString() + "[-]";
          }
        }
        if (!string.IsNullOrEmpty(baseItem.description))
          text = text + "\n[FF9900]" + baseItem.description;
        UITooltip.Show(text);
        return;
      }
    }
    UITooltip.Hide();
  }

  private void OnClick()
  {
    if (UIItemSlot.mDraggedItem != null)
    {
      this.OnDrop((GameObject) null);
    }
    else
    {
      if (this.mItem == null)
        return;
      UIItemSlot.mDraggedItem = this.Replace((InvGameItem) null);
      if (UIItemSlot.mDraggedItem != null)
        NGUITools.PlaySound(this.grabSound);
      this.UpdateCursor();
    }
  }

  private void OnDrag(Vector2 delta)
  {
    if (UIItemSlot.mDraggedItem != null || this.mItem == null)
      return;
    UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
    UIItemSlot.mDraggedItem = this.Replace((InvGameItem) null);
    NGUITools.PlaySound(this.grabSound);
    this.UpdateCursor();
  }

  private void OnDrop(GameObject go)
  {
    InvGameItem invGameItem = this.Replace(UIItemSlot.mDraggedItem);
    if (UIItemSlot.mDraggedItem == invGameItem)
      NGUITools.PlaySound(this.errorSound);
    else if (invGameItem != null)
      NGUITools.PlaySound(this.grabSound);
    else
      NGUITools.PlaySound(this.placeSound);
    UIItemSlot.mDraggedItem = invGameItem;
    this.UpdateCursor();
  }

  private void UpdateCursor()
  {
    if (UIItemSlot.mDraggedItem != null && UIItemSlot.mDraggedItem.baseItem != null)
      UICursor.Set(UIItemSlot.mDraggedItem.baseItem.iconAtlas as INGUIAtlas, UIItemSlot.mDraggedItem.baseItem.iconName);
    else
      UICursor.Clear();
  }

  private void Update()
  {
    InvGameItem observedItem = this.observedItem;
    if (this.mItem == observedItem)
      return;
    this.mItem = observedItem;
    InvBaseItem baseItem = observedItem?.baseItem;
    if ((Object) this.label != (Object) null)
    {
      string name = observedItem?.name;
      if (string.IsNullOrEmpty(this.mText))
        this.mText = this.label.text;
      this.label.text = name ?? this.mText;
    }
    if ((Object) this.icon != (Object) null)
    {
      if (baseItem == null || baseItem.iconAtlas == (Object) null)
      {
        this.icon.enabled = false;
      }
      else
      {
        this.icon.atlas = baseItem.iconAtlas as INGUIAtlas;
        this.icon.spriteName = baseItem.iconName;
        this.icon.enabled = true;
        this.icon.MakePixelPerfect();
      }
    }
    if (!((Object) this.background != (Object) null))
      return;
    this.background.color = observedItem != null ? observedItem.color : Color.white;
  }
}
