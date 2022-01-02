using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000533 RID: 1331
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021E8 RID: 8680 RVA: 0x001EAA25 File Offset: 0x001E8C25
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EAA45 File Offset: 0x001E8C45
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

		// Token: 0x060021EA RID: 8682 RVA: 0x001EAA64 File Offset: 0x001E8C64
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001EAA71 File Offset: 0x001E8C71
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001EAA7E File Offset: 0x001E8C7E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001EAA8B File Offset: 0x001E8C8B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001EAA98 File Offset: 0x001E8C98
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001EAAB3 File Offset: 0x001E8CB3
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001EAAC0 File Offset: 0x001E8CC0
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001EAACD File Offset: 0x001E8CCD
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001EAAD6 File Offset: 0x001E8CD6
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001EAADF File Offset: 0x001E8CDF
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001EAAED File Offset: 0x001E8CED
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001EAAFA File Offset: 0x001E8CFA
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001EAB07 File Offset: 0x001E8D07
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EAB14 File Offset: 0x001E8D14
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001EAB21 File Offset: 0x001E8D21
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001EAB2E File Offset: 0x001E8D2E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x060021FA RID: 8698 RVA: 0x001EAB3B File Offset: 0x001E8D3B
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EAB48 File Offset: 0x001E8D48
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EAB55 File Offset: 0x001E8D55
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060021FD RID: 8701 RVA: 0x001EAB63 File Offset: 0x001E8D63
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x060021FE RID: 8702 RVA: 0x001EAB6F File Offset: 0x001E8D6F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001EAB7C File Offset: 0x001E8D7C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001EAB89 File Offset: 0x001E8D89
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x040049ED RID: 18925
		private static VirtualInput activeInput;

		// Token: 0x040049EE RID: 18926
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x040049EF RID: 18927
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000685 RID: 1669
		public enum ActiveInputMethod
		{
			// Token: 0x04004FD1 RID: 20433
			Hardware,
			// Token: 0x04004FD2 RID: 20434
			Touch
		}

		// Token: 0x02000686 RID: 1670
		public class VirtualAxis
		{
			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026DF RID: 9951 RVA: 0x001FE527 File Offset: 0x001FC727
			// (set) Token: 0x060026E0 RID: 9952 RVA: 0x001FE52F File Offset: 0x001FC72F
			public string name { get; private set; }

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026E1 RID: 9953 RVA: 0x001FE538 File Offset: 0x001FC738
			// (set) Token: 0x060026E2 RID: 9954 RVA: 0x001FE540 File Offset: 0x001FC740
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026E3 RID: 9955 RVA: 0x001FE549 File Offset: 0x001FC749
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026E4 RID: 9956 RVA: 0x001FE553 File Offset: 0x001FC753
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026E5 RID: 9957 RVA: 0x001FE569 File Offset: 0x001FC769
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026E6 RID: 9958 RVA: 0x001FE576 File Offset: 0x001FC776
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E7 RID: 9959 RVA: 0x001FE57F File Offset: 0x001FC77F
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026E8 RID: 9960 RVA: 0x001FE587 File Offset: 0x001FC787
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FD4 RID: 20436
			private float m_Value;
		}

		// Token: 0x02000687 RID: 1671
		public class VirtualButton
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026E9 RID: 9961 RVA: 0x001FE58F File Offset: 0x001FC78F
			// (set) Token: 0x060026EA RID: 9962 RVA: 0x001FE597 File Offset: 0x001FC797
			public string name { get; private set; }

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026EB RID: 9963 RVA: 0x001FE5A0 File Offset: 0x001FC7A0
			// (set) Token: 0x060026EC RID: 9964 RVA: 0x001FE5A8 File Offset: 0x001FC7A8
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026ED RID: 9965 RVA: 0x001FE5B1 File Offset: 0x001FC7B1
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026EE RID: 9966 RVA: 0x001FE5BB File Offset: 0x001FC7BB
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026EF RID: 9967 RVA: 0x001FE5E1 File Offset: 0x001FC7E1
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026F0 RID: 9968 RVA: 0x001FE5FE File Offset: 0x001FC7FE
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026F1 RID: 9969 RVA: 0x001FE612 File Offset: 0x001FC812
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026F2 RID: 9970 RVA: 0x001FE61F File Offset: 0x001FC81F
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F3 RID: 9971 RVA: 0x001FE627 File Offset: 0x001FC827
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000583 RID: 1411
			// (get) Token: 0x060026F4 RID: 9972 RVA: 0x001FE638 File Offset: 0x001FC838
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FD8 RID: 20440
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FD9 RID: 20441
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FDA RID: 20442
			private bool m_Pressed;
		}
	}
}
