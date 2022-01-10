using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021F3 RID: 8691 RVA: 0x001EB3C5 File Offset: 0x001E95C5
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001EB3E5 File Offset: 0x001E95E5
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

		// Token: 0x060021F5 RID: 8693 RVA: 0x001EB404 File Offset: 0x001E9604
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001EB411 File Offset: 0x001E9611
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EB41E File Offset: 0x001E961E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001EB42B File Offset: 0x001E962B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001EB438 File Offset: 0x001E9638
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001EB453 File Offset: 0x001E9653
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EB460 File Offset: 0x001E9660
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EB46D File Offset: 0x001E966D
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001EB476 File Offset: 0x001E9676
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001EB47F File Offset: 0x001E967F
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001EB48D File Offset: 0x001E968D
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EB49A File Offset: 0x001E969A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x06002201 RID: 8705 RVA: 0x001EB4A7 File Offset: 0x001E96A7
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001EB4B4 File Offset: 0x001E96B4
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x06002203 RID: 8707 RVA: 0x001EB4C1 File Offset: 0x001E96C1
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x06002204 RID: 8708 RVA: 0x001EB4CE File Offset: 0x001E96CE
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x06002205 RID: 8709 RVA: 0x001EB4DB File Offset: 0x001E96DB
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x06002206 RID: 8710 RVA: 0x001EB4E8 File Offset: 0x001E96E8
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x06002207 RID: 8711 RVA: 0x001EB4F5 File Offset: 0x001E96F5
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06002208 RID: 8712 RVA: 0x001EB503 File Offset: 0x001E9703
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x06002209 RID: 8713 RVA: 0x001EB50F File Offset: 0x001E970F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x0600220A RID: 8714 RVA: 0x001EB51C File Offset: 0x001E971C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001EB529 File Offset: 0x001E9729
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x04004A01 RID: 18945
		private static VirtualInput activeInput;

		// Token: 0x04004A02 RID: 18946
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x04004A03 RID: 18947
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000687 RID: 1671
		public enum ActiveInputMethod
		{
			// Token: 0x04004FE5 RID: 20453
			Hardware,
			// Token: 0x04004FE6 RID: 20454
			Touch
		}

		// Token: 0x02000688 RID: 1672
		public class VirtualAxis
		{
			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026EA RID: 9962 RVA: 0x001FEEC7 File Offset: 0x001FD0C7
			// (set) Token: 0x060026EB RID: 9963 RVA: 0x001FEECF File Offset: 0x001FD0CF
			public string name { get; private set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026EC RID: 9964 RVA: 0x001FEED8 File Offset: 0x001FD0D8
			// (set) Token: 0x060026ED RID: 9965 RVA: 0x001FEEE0 File Offset: 0x001FD0E0
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EE RID: 9966 RVA: 0x001FEEE9 File Offset: 0x001FD0E9
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026EF RID: 9967 RVA: 0x001FEEF3 File Offset: 0x001FD0F3
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026F0 RID: 9968 RVA: 0x001FEF09 File Offset: 0x001FD109
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026F1 RID: 9969 RVA: 0x001FEF16 File Offset: 0x001FD116
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026F2 RID: 9970 RVA: 0x001FEF1F File Offset: 0x001FD11F
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026F3 RID: 9971 RVA: 0x001FEF27 File Offset: 0x001FD127
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FE8 RID: 20456
			private float m_Value;
		}

		// Token: 0x02000689 RID: 1673
		public class VirtualButton
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026F4 RID: 9972 RVA: 0x001FEF2F File Offset: 0x001FD12F
			// (set) Token: 0x060026F5 RID: 9973 RVA: 0x001FEF37 File Offset: 0x001FD137
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026F6 RID: 9974 RVA: 0x001FEF40 File Offset: 0x001FD140
			// (set) Token: 0x060026F7 RID: 9975 RVA: 0x001FEF48 File Offset: 0x001FD148
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026F8 RID: 9976 RVA: 0x001FEF51 File Offset: 0x001FD151
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026F9 RID: 9977 RVA: 0x001FEF5B File Offset: 0x001FD15B
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026FA RID: 9978 RVA: 0x001FEF81 File Offset: 0x001FD181
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026FB RID: 9979 RVA: 0x001FEF9E File Offset: 0x001FD19E
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026FC RID: 9980 RVA: 0x001FEFB2 File Offset: 0x001FD1B2
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026FD RID: 9981 RVA: 0x001FEFBF File Offset: 0x001FD1BF
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026FE RID: 9982 RVA: 0x001FEFC7 File Offset: 0x001FD1C7
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026FF RID: 9983 RVA: 0x001FEFD8 File Offset: 0x001FD1D8
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FEC RID: 20460
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FED RID: 20461
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FEE RID: 20462
			private bool m_Pressed;
		}
	}
}
