using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000533 RID: 1331
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021E5 RID: 8677 RVA: 0x001EA435 File Offset: 0x001E8635
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001EA455 File Offset: 0x001E8655
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

		// Token: 0x060021E7 RID: 8679 RVA: 0x001EA474 File Offset: 0x001E8674
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001EA481 File Offset: 0x001E8681
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x001EA48E File Offset: 0x001E868E
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001EA49B File Offset: 0x001E869B
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001EA4A8 File Offset: 0x001E86A8
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001EA4C3 File Offset: 0x001E86C3
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x060021ED RID: 8685 RVA: 0x001EA4D0 File Offset: 0x001E86D0
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x060021EE RID: 8686 RVA: 0x001EA4DD File Offset: 0x001E86DD
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x001EA4E6 File Offset: 0x001E86E6
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x001EA4EF File Offset: 0x001E86EF
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x001EA4FD File Offset: 0x001E86FD
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x001EA50A File Offset: 0x001E870A
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001EA517 File Offset: 0x001E8717
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x001EA524 File Offset: 0x001E8724
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x001EA531 File Offset: 0x001E8731
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x060021F6 RID: 8694 RVA: 0x001EA53E File Offset: 0x001E873E
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x060021F7 RID: 8695 RVA: 0x001EA54B File Offset: 0x001E874B
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x060021F8 RID: 8696 RVA: 0x001EA558 File Offset: 0x001E8758
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x060021F9 RID: 8697 RVA: 0x001EA565 File Offset: 0x001E8765
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021FA RID: 8698 RVA: 0x001EA573 File Offset: 0x001E8773
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001EA57F File Offset: 0x001E877F
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x060021FC RID: 8700 RVA: 0x001EA58C File Offset: 0x001E878C
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x060021FD RID: 8701 RVA: 0x001EA599 File Offset: 0x001E8799
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x040049E4 RID: 18916
		private static VirtualInput activeInput;

		// Token: 0x040049E5 RID: 18917
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x040049E6 RID: 18918
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000685 RID: 1669
		public enum ActiveInputMethod
		{
			// Token: 0x04004FC8 RID: 20424
			Hardware,
			// Token: 0x04004FC9 RID: 20425
			Touch
		}

		// Token: 0x02000686 RID: 1670
		public class VirtualAxis
		{
			// Token: 0x1700057A RID: 1402
			// (get) Token: 0x060026DC RID: 9948 RVA: 0x001FDF13 File Offset: 0x001FC113
			// (set) Token: 0x060026DD RID: 9949 RVA: 0x001FDF1B File Offset: 0x001FC11B
			public string name { get; private set; }

			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026DE RID: 9950 RVA: 0x001FDF24 File Offset: 0x001FC124
			// (set) Token: 0x060026DF RID: 9951 RVA: 0x001FDF2C File Offset: 0x001FC12C
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026E0 RID: 9952 RVA: 0x001FDF35 File Offset: 0x001FC135
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026E1 RID: 9953 RVA: 0x001FDF3F File Offset: 0x001FC13F
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026E2 RID: 9954 RVA: 0x001FDF55 File Offset: 0x001FC155
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026E3 RID: 9955 RVA: 0x001FDF62 File Offset: 0x001FC162
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026E4 RID: 9956 RVA: 0x001FDF6B File Offset: 0x001FC16B
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026E5 RID: 9957 RVA: 0x001FDF73 File Offset: 0x001FC173
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004FCB RID: 20427
			private float m_Value;
		}

		// Token: 0x02000687 RID: 1671
		public class VirtualButton
		{
			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026E6 RID: 9958 RVA: 0x001FDF7B File Offset: 0x001FC17B
			// (set) Token: 0x060026E7 RID: 9959 RVA: 0x001FDF83 File Offset: 0x001FC183
			public string name { get; private set; }

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026E8 RID: 9960 RVA: 0x001FDF8C File Offset: 0x001FC18C
			// (set) Token: 0x060026E9 RID: 9961 RVA: 0x001FDF94 File Offset: 0x001FC194
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026EA RID: 9962 RVA: 0x001FDF9D File Offset: 0x001FC19D
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026EB RID: 9963 RVA: 0x001FDFA7 File Offset: 0x001FC1A7
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026EC RID: 9964 RVA: 0x001FDFCD File Offset: 0x001FC1CD
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026ED RID: 9965 RVA: 0x001FDFEA File Offset: 0x001FC1EA
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026EE RID: 9966 RVA: 0x001FDFFE File Offset: 0x001FC1FE
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026EF RID: 9967 RVA: 0x001FE00B File Offset: 0x001FC20B
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026F0 RID: 9968 RVA: 0x001FE013 File Offset: 0x001FC213
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026F1 RID: 9969 RVA: 0x001FE024 File Offset: 0x001FC224
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004FCF RID: 20431
			private int m_LastPressedFrame = -5;

			// Token: 0x04004FD0 RID: 20432
			private int m_ReleasedFrame = -5;

			// Token: 0x04004FD1 RID: 20433
			private bool m_Pressed;
		}
	}
}
