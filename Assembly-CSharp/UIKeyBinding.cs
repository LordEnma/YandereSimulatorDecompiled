using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000059 RID: 89
[AddComponentMenu("NGUI/Interaction/Key Binding")]
public class UIKeyBinding : MonoBehaviour
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060001DC RID: 476 RVA: 0x00017EF8 File Offset: 0x000160F8
	public string captionText
	{
		get
		{
			string text = NGUITools.KeyToCaption(this.keyCode);
			if (this.modifier == UIKeyBinding.Modifier.None || this.modifier == UIKeyBinding.Modifier.Any)
			{
				return text;
			}
			return this.modifier.ToString() + "+" + text;
		}
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00017F40 File Offset: 0x00016140
	public static bool IsBound(KeyCode key)
	{
		int i = 0;
		int count = UIKeyBinding.list.Count;
		while (i < count)
		{
			UIKeyBinding uikeyBinding = UIKeyBinding.list[i];
			if (uikeyBinding != null && uikeyBinding.keyCode == key)
			{
				return true;
			}
			i++;
		}
		return false;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00017F88 File Offset: 0x00016188
	public static UIKeyBinding Find(string name)
	{
		int i = 0;
		int count = UIKeyBinding.list.Count;
		while (i < count)
		{
			if (UIKeyBinding.list[i].name == name)
			{
				return UIKeyBinding.list[i];
			}
			i++;
		}
		return null;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00017FD1 File Offset: 0x000161D1
	protected virtual void OnEnable()
	{
		UIKeyBinding.list.Add(this);
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00017FDE File Offset: 0x000161DE
	protected virtual void OnDisable()
	{
		UIKeyBinding.list.Remove(this);
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00017FEC File Offset: 0x000161EC
	protected virtual void Start()
	{
		UIInput component = base.GetComponent<UIInput>();
		this.mIsInput = (component != null);
		if (component != null)
		{
			EventDelegate.Add(component.onSubmit, new EventDelegate.Callback(this.OnSubmit));
		}
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0001802F File Offset: 0x0001622F
	protected virtual void OnSubmit()
	{
		if (UICamera.currentKey == this.keyCode && this.IsModifierActive())
		{
			this.mIgnoreUp = true;
		}
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0001804D File Offset: 0x0001624D
	protected virtual bool IsModifierActive()
	{
		return UIKeyBinding.IsModifierActive(this.modifier);
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0001805C File Offset: 0x0001625C
	public static bool IsModifierActive(UIKeyBinding.Modifier modifier)
	{
		if (modifier == UIKeyBinding.Modifier.Any)
		{
			return true;
		}
		if (modifier == UIKeyBinding.Modifier.Alt)
		{
			if (UICamera.GetKey(KeyCode.LeftAlt) || UICamera.GetKey(KeyCode.RightAlt))
			{
				return true;
			}
		}
		else if (modifier == UIKeyBinding.Modifier.Ctrl)
		{
			if (UICamera.GetKey(KeyCode.LeftControl) || UICamera.GetKey(KeyCode.RightControl))
			{
				return true;
			}
		}
		else if (modifier == UIKeyBinding.Modifier.Shift)
		{
			if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
			{
				return true;
			}
		}
		else if (modifier == UIKeyBinding.Modifier.None)
		{
			return !UICamera.GetKey(KeyCode.LeftAlt) && !UICamera.GetKey(KeyCode.RightAlt) && !UICamera.GetKey(KeyCode.LeftControl) && !UICamera.GetKey(KeyCode.RightControl) && !UICamera.GetKey(KeyCode.LeftShift) && !UICamera.GetKey(KeyCode.RightShift);
		}
		return false;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0001815C File Offset: 0x0001635C
	protected virtual void Update()
	{
		if (this.keyCode != KeyCode.Numlock && UICamera.inputHasFocus)
		{
			return;
		}
		if (this.keyCode == KeyCode.None || !this.IsModifierActive())
		{
			return;
		}
		bool flag = UICamera.GetKeyDown(this.keyCode);
		bool flag2 = UICamera.GetKeyUp(this.keyCode);
		if (flag)
		{
			this.mPress = true;
		}
		if (this.action == UIKeyBinding.Action.PressAndClick || this.action == UIKeyBinding.Action.All)
		{
			if (flag)
			{
				UICamera.currentTouchID = -1;
				UICamera.currentKey = this.keyCode;
				this.OnBindingPress(true);
			}
			if (this.mPress && flag2)
			{
				UICamera.currentTouchID = -1;
				UICamera.currentKey = this.keyCode;
				this.OnBindingPress(false);
				this.OnBindingClick();
			}
		}
		if ((this.action == UIKeyBinding.Action.Select || this.action == UIKeyBinding.Action.All) && flag2)
		{
			if (this.mIsInput)
			{
				if (!this.mIgnoreUp && (this.keyCode == KeyCode.Numlock || !UICamera.inputHasFocus) && this.mPress)
				{
					UICamera.selectedObject = base.gameObject;
				}
				this.mIgnoreUp = false;
			}
			else if (this.mPress)
			{
				UICamera.hoveredObject = base.gameObject;
			}
		}
		if (flag2)
		{
			this.mPress = false;
		}
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00018281 File Offset: 0x00016481
	protected virtual void OnBindingPress(bool pressed)
	{
		UICamera.Notify(base.gameObject, "OnPress", pressed);
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00018299 File Offset: 0x00016499
	protected virtual void OnBindingClick()
	{
		UICamera.Notify(base.gameObject, "OnClick", null);
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x000182AC File Offset: 0x000164AC
	public override string ToString()
	{
		return UIKeyBinding.GetString(this.keyCode, this.modifier);
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x000182BF File Offset: 0x000164BF
	public static string GetString(KeyCode keyCode, UIKeyBinding.Modifier modifier)
	{
		if (modifier == UIKeyBinding.Modifier.None)
		{
			return NGUITools.KeyToCaption(keyCode);
		}
		return modifier.ToString() + "+" + NGUITools.KeyToCaption(keyCode);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000182EC File Offset: 0x000164EC
	public static bool GetKeyCode(string text, out KeyCode key, out UIKeyBinding.Modifier modifier)
	{
		key = KeyCode.None;
		modifier = UIKeyBinding.Modifier.None;
		if (string.IsNullOrEmpty(text))
		{
			return true;
		}
		if (text.Length > 2 && text.Contains("+") && text[text.Length - 1] != '+')
		{
			string[] array = text.Split(new char[]
			{
				'+'
			}, 2);
			key = NGUITools.CaptionToKey(array[1]);
			try
			{
				modifier = (UIKeyBinding.Modifier)Enum.Parse(typeof(UIKeyBinding.Modifier), array[0]);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		modifier = UIKeyBinding.Modifier.None;
		key = NGUITools.CaptionToKey(text);
		return true;
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0001838C File Offset: 0x0001658C
	public static UIKeyBinding.Modifier GetActiveModifier()
	{
		UIKeyBinding.Modifier result = UIKeyBinding.Modifier.None;
		if (UICamera.GetKey(KeyCode.LeftAlt) || UICamera.GetKey(KeyCode.RightAlt))
		{
			result = UIKeyBinding.Modifier.Alt;
		}
		else if (UICamera.GetKey(KeyCode.LeftShift) || UICamera.GetKey(KeyCode.RightShift))
		{
			result = UIKeyBinding.Modifier.Shift;
		}
		else if (UICamera.GetKey(KeyCode.LeftControl) || UICamera.GetKey(KeyCode.RightControl))
		{
			result = UIKeyBinding.Modifier.Ctrl;
		}
		return result;
	}

	// Token: 0x0400039C RID: 924
	public static List<UIKeyBinding> list = new List<UIKeyBinding>();

	// Token: 0x0400039D RID: 925
	public KeyCode keyCode;

	// Token: 0x0400039E RID: 926
	public UIKeyBinding.Modifier modifier;

	// Token: 0x0400039F RID: 927
	public UIKeyBinding.Action action;

	// Token: 0x040003A0 RID: 928
	[NonSerialized]
	private bool mIgnoreUp;

	// Token: 0x040003A1 RID: 929
	[NonSerialized]
	private bool mIsInput;

	// Token: 0x040003A2 RID: 930
	[NonSerialized]
	private bool mPress;

	// Token: 0x020005CD RID: 1485
	[DoNotObfuscateNGUI]
	public enum Action
	{
		// Token: 0x04004D59 RID: 19801
		PressAndClick,
		// Token: 0x04004D5A RID: 19802
		Select,
		// Token: 0x04004D5B RID: 19803
		All
	}

	// Token: 0x020005CE RID: 1486
	[DoNotObfuscateNGUI]
	public enum Modifier
	{
		// Token: 0x04004D5D RID: 19805
		Any,
		// Token: 0x04004D5E RID: 19806
		Shift,
		// Token: 0x04004D5F RID: 19807
		Ctrl,
		// Token: 0x04004D60 RID: 19808
		Alt,
		// Token: 0x04004D61 RID: 19809
		None
	}
}
