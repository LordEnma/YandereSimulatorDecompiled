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
		InvGameItem invGameItem = (show ? mItem : null);
		if (invGameItem != null)
		{
			InvBaseItem baseItem = invGameItem.baseItem;
			if (baseItem != null)
			{
				string text = "[" + NGUIText.EncodeColor(invGameItem.color) + "]" + invGameItem.name + "[-]\n";
				text = text + "[AFAFAF]Level " + invGameItem.itemLevel + " " + baseItem.slot;
				List<InvStat> list = invGameItem.CalculateStats();
				int i = 0;
				for (int count = list.Count; i < count; i++)
				{
					InvStat invStat = list[i];
					if (invStat.amount != 0)
					{
						text = ((invStat.amount >= 0) ? (text + "\n[00FF00]+" + invStat.amount) : (text + "\n[FF0000]" + invStat.amount));
						if (invStat.modifier == InvStat.Modifier.Percent)
						{
							text += "%";
						}
						text = text + " " + invStat.id;
						text += "[-]";
					}
				}
				if (!string.IsNullOrEmpty(baseItem.description))
				{
					text = text + "\n[FF9900]" + baseItem.description;
				}
				UITooltip.Show(text);
				return;
			}
		}
		UITooltip.Hide();
	}

	private void OnClick()
	{
		if (mDraggedItem != null)
		{
			OnDrop(null);
		}
		else if (mItem != null)
		{
			mDraggedItem = Replace(null);
			if (mDraggedItem != null)
			{
				NGUITools.PlaySound(grabSound);
			}
			UpdateCursor();
		}
	}

	private void OnDrag(Vector2 delta)
	{
		if (mDraggedItem == null && mItem != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			mDraggedItem = Replace(null);
			NGUITools.PlaySound(grabSound);
			UpdateCursor();
		}
	}

	private void OnDrop(GameObject go)
	{
		InvGameItem invGameItem = Replace(mDraggedItem);
		if (mDraggedItem == invGameItem)
		{
			NGUITools.PlaySound(errorSound);
		}
		else if (invGameItem != null)
		{
			NGUITools.PlaySound(grabSound);
		}
		else
		{
			NGUITools.PlaySound(placeSound);
		}
		mDraggedItem = invGameItem;
		UpdateCursor();
	}

	private void UpdateCursor()
	{
		if (mDraggedItem != null && mDraggedItem.baseItem != null)
		{
			UICursor.Set(mDraggedItem.baseItem.iconAtlas as INGUIAtlas, mDraggedItem.baseItem.iconName);
		}
		else
		{
			UICursor.Clear();
		}
	}

	private void Update()
	{
		InvGameItem invGameItem = observedItem;
		if (mItem == invGameItem)
		{
			return;
		}
		mItem = invGameItem;
		InvBaseItem invBaseItem = invGameItem?.baseItem;
		if (label != null)
		{
			string text = invGameItem?.name;
			if (string.IsNullOrEmpty(mText))
			{
				mText = label.text;
			}
			label.text = ((text != null) ? text : mText);
		}
		if (icon != null)
		{
			if (invBaseItem == null || invBaseItem.iconAtlas == null)
			{
				icon.enabled = false;
			}
			else
			{
				icon.atlas = invBaseItem.iconAtlas as INGUIAtlas;
				icon.spriteName = invBaseItem.iconName;
				icon.enabled = true;
				icon.MakePixelPerfect();
			}
		}
		if (background != null)
		{
			background.color = invGameItem?.color ?? Color.white;
		}
	}
}
