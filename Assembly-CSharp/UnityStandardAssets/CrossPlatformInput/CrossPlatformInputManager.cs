using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000536 RID: 1334
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021F9 RID: 8697 RVA: 0x001EC935 File Offset: 0x001EAB35
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001EC955 File Offset: 0x001EAB55
		public static void SwitchActiveInputMethod(CrossPlatformInputManager.ActiveInputMethod activeInputMethod)
		{
			if (activeInputMethod == CrossPlatformInputManager.ActiveInputMethod.Hardware)
			{
				CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
				return;
			}
			if (activeInputMethod != CrossPlatformInputManager.ActiveInputMethod.Touch)
			{
				return;
			}
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_TouchInput;
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EC974 File Offset: 0x001EAB74
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EC981 File Offset: 0x001EAB81
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001EC98E File Offset: 0x001EAB8E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001EC99B File Offset: 0x001EAB9B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001EC9A8 File Offset: 0x001EABA8
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EC9C3 File Offset: 0x001EABC3
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001EC9D0 File Offset: 0x001EABD0
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EC9DD File Offset: 0x001EABDD
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EC9E6 File Offset: 0x001EABE6
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EC9EF File Offset: 0x001EABEF
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EC9FD File Offset: 0x001EABFD
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001ECA0A File Offset: 0x001EAC0A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001ECA17 File Offset: 0x001EAC17
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002208 RID: 8712 RVA: 0x001ECA24 File Offset: 0x001EAC24
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001ECA31 File Offset: 0x001EAC31
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001ECA3E File Offset: 0x001EAC3E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001ECA4B File Offset: 0x001EAC4B
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x0600220C RID: 8716 RVA: 0x001ECA58 File Offset: 0x001EAC58
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x0600220D RID: 8717 RVA: 0x001ECA65 File Offset: 0x001EAC65
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x0600220E RID: 8718 RVA: 0x001ECA73 File Offset: 0x001EAC73
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x0600220F RID: 8719 RVA: 0x001ECA7F File Offset: 0x001EAC7F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001ECA8C File Offset: 0x001EAC8C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001ECA99 File Offset: 0x001EAC99
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A13 RID: 18963
		private static VirtualInput activeInput;

		// Token: 0x04004A14 RID: 18964
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A15 RID: 18965
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000682 RID: 1666
		public enum ActiveInputMethod
		{
			// Token: 0x04004FC9 RID: 20425
			Hardware,
			// Token: 0x04004FCA RID: 20426
			Touch
		}

		// Token: 0x02000683 RID: 1667
		public class VirtualAxis
		{
			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026DC RID: 9948 RVA: 0x001FFD53 File Offset: 0x001FDF53
			// (set) Token: 0x060026DD RID: 9949 RVA: 0x001FFD5B File Offset: 0x001FDF5B
			public string name { get; private set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026DE RID: 9950 RVA: 0x001FFD64 File Offset: 0x001FDF64
			// (set) Token: 0x060026DF RID: 9951 RVA: 0x001FFD6C File Offset: 0x001FDF6C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026E0 RID: 9952 RVA: 0x001FFD75 File Offset: 0x001FDF75
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026E1 RID: 9953 RVA: 0x001FFD7F File Offset: 0x001FDF7F
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026E2 RID: 9954 RVA: 0x001FFD95 File Offset: 0x001FDF95
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026E3 RID: 9955 RVA: 0x001FFDA2 File Offset: 0x001FDFA2
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E4 RID: 9956 RVA: 0x001FFDAB File Offset: 0x001FDFAB
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026E5 RID: 9957 RVA: 0x001FFDB3 File Offset: 0x001FDFB3
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FCC RID: 20428
			private float m_Value;
		}

		// Token: 0x02000684 RID: 1668
		public class VirtualButton
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026E6 RID: 9958 RVA: 0x001FFDBB File Offset: 0x001FDFBB
			// (set) Token: 0x060026E7 RID: 9959 RVA: 0x001FFDC3 File Offset: 0x001FDFC3
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026E8 RID: 9960 RVA: 0x001FFDCC File Offset: 0x001FDFCC
			// (set) Token: 0x060026E9 RID: 9961 RVA: 0x001FFDD4 File Offset: 0x001FDFD4
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EA RID: 9962 RVA: 0x001FFDDD File Offset: 0x001FDFDD
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026EB RID: 9963 RVA: 0x001FFDE7 File Offset: 0x001FDFE7
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026EC RID: 9964 RVA: 0x001FFE0D File Offset: 0x001FE00D
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026ED RID: 9965 RVA: 0x001FFE2A File Offset: 0x001FE02A
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026EE RID: 9966 RVA: 0x001FFE3E File Offset: 0x001FE03E
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026EF RID: 9967 RVA: 0x001FFE4B File Offset: 0x001FE04B
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F0 RID: 9968 RVA: 0x001FFE53 File Offset: 0x001FE053
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026F1 RID: 9969 RVA: 0x001FFE64 File Offset: 0x001FE064
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FD0 RID: 20432
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FD1 RID: 20433
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FD2 RID: 20434
			private bool m_Pressed;
		}
	}
}
