using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000531 RID: 1329
	public static class CrossPlatformInputManager
	{
		// Token: 0x060021D4 RID: 8660 RVA: 0x001E8D01 File Offset: 0x001E6F01
		static CrossPlatformInputManager()
		{
			CrossPlatformInputManager.activeInput = CrossPlatformInputManager.s_HardwareInput;
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x001E8D21 File Offset: 0x001E6F21
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

		// Token: 0x060021D6 RID: 8662 RVA: 0x001E8D40 File Offset: 0x001E6F40
		public static bool AxisExists(string name)
		{
			return CrossPlatformInputManager.activeInput.AxisExists(name);
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x001E8D4D File Offset: 0x001E6F4D
		public static bool ButtonExists(string name)
		{
			return CrossPlatformInputManager.activeInput.ButtonExists(name);
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x001E8D5A File Offset: 0x001E6F5A
		public static void RegisterVirtualAxis(CrossPlatformInputManager.VirtualAxis axis)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualAxis(axis);
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x001E8D67 File Offset: 0x001E6F67
		public static void RegisterVirtualButton(CrossPlatformInputManager.VirtualButton button)
		{
			CrossPlatformInputManager.activeInput.RegisterVirtualButton(button);
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x001E8D74 File Offset: 0x001E6F74
		public static void UnRegisterVirtualAxis(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			CrossPlatformInputManager.activeInput.UnRegisterVirtualAxis(name);
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x001E8D8F File Offset: 0x001E6F8F
		public static void UnRegisterVirtualButton(string name)
		{
			CrossPlatformInputManager.activeInput.UnRegisterVirtualButton(name);
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x001E8D9C File Offset: 0x001E6F9C
		public static CrossPlatformInputManager.VirtualAxis VirtualAxisReference(string name)
		{
			return CrossPlatformInputManager.activeInput.VirtualAxisReference(name);
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x001E8DA9 File Offset: 0x001E6FA9
		public static float GetAxis(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, false);
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x001E8DB2 File Offset: 0x001E6FB2
		public static float GetAxisRaw(string name)
		{
			return CrossPlatformInputManager.GetAxis(name, true);
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x001E8DBB File Offset: 0x001E6FBB
		private static float GetAxis(string name, bool raw)
		{
			return CrossPlatformInputManager.activeInput.GetAxis(name, raw);
		}

		// Token: 0x060021E0 RID: 8672 RVA: 0x001E8DC9 File Offset: 0x001E6FC9
		public static bool GetButton(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButton(name);
		}

		// Token: 0x060021E1 RID: 8673 RVA: 0x001E8DD6 File Offset: 0x001E6FD6
		public static bool GetButtonDown(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonDown(name);
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x001E8DE3 File Offset: 0x001E6FE3
		public static bool GetButtonUp(string name)
		{
			return CrossPlatformInputManager.activeInput.GetButtonUp(name);
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001E8DF0 File Offset: 0x001E6FF0
		public static void SetButtonDown(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonDown(name);
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x001E8DFD File Offset: 0x001E6FFD
		public static void SetButtonUp(string name)
		{
			CrossPlatformInputManager.activeInput.SetButtonUp(name);
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x001E8E0A File Offset: 0x001E700A
		public static void SetAxisPositive(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisPositive(name);
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x001E8E17 File Offset: 0x001E7017
		public static void SetAxisNegative(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisNegative(name);
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001E8E24 File Offset: 0x001E7024
		public static void SetAxisZero(string name)
		{
			CrossPlatformInputManager.activeInput.SetAxisZero(name);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001E8E31 File Offset: 0x001E7031
		public static void SetAxis(string name, float value)
		{
			CrossPlatformInputManager.activeInput.SetAxis(name, value);
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060021E9 RID: 8681 RVA: 0x001E8E3F File Offset: 0x001E703F
		public static Vector3 mousePosition
		{
			get
			{
				return CrossPlatformInputManager.activeInput.MousePosition();
			}
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x001E8E4B File Offset: 0x001E704B
		public static void SetVirtualMousePositionX(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionX(f);
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x001E8E58 File Offset: 0x001E7058
		public static void SetVirtualMousePositionY(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionY(f);
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x001E8E65 File Offset: 0x001E7065
		public static void SetVirtualMousePositionZ(float f)
		{
			CrossPlatformInputManager.activeInput.SetVirtualMousePositionZ(f);
		}

		// Token: 0x040049A5 RID: 18853
		private static VirtualInput activeInput;

		// Token: 0x040049A6 RID: 18854
		private static VirtualInput s_TouchInput = new MobileInput();

		// Token: 0x040049A7 RID: 18855
		private static VirtualInput s_HardwareInput = new StandaloneInput();

		// Token: 0x02000682 RID: 1666
		public enum ActiveInputMethod
		{
			// Token: 0x04004F7D RID: 20349
			Hardware,
			// Token: 0x04004F7E RID: 20350
			Touch
		}

		// Token: 0x02000683 RID: 1667
		public class VirtualAxis
		{
			// Token: 0x1700057A RID: 1402
			// (get) Token: 0x060026CB RID: 9931 RVA: 0x001FC7DF File Offset: 0x001FA9DF
			// (set) Token: 0x060026CC RID: 9932 RVA: 0x001FC7E7 File Offset: 0x001FA9E7
			public string name { get; private set; }

			// Token: 0x1700057B RID: 1403
			// (get) Token: 0x060026CD RID: 9933 RVA: 0x001FC7F0 File Offset: 0x001FA9F0
			// (set) Token: 0x060026CE RID: 9934 RVA: 0x001FC7F8 File Offset: 0x001FA9F8
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026CF RID: 9935 RVA: 0x001FC801 File Offset: 0x001FAA01
			public VirtualAxis(string name) : this(name, true)
			{
			}

			// Token: 0x060026D0 RID: 9936 RVA: 0x001FC80B File Offset: 0x001FAA0B
			public VirtualAxis(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026D1 RID: 9937 RVA: 0x001FC821 File Offset: 0x001FAA21
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualAxis(this.name);
			}

			// Token: 0x060026D2 RID: 9938 RVA: 0x001FC82E File Offset: 0x001FAA2E
			public void Update(float value)
			{
				this.m_Value = value;
			}

			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x060026D3 RID: 9939 RVA: 0x001FC837 File Offset: 0x001FAA37
			public float GetValue
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x1700057D RID: 1405
			// (get) Token: 0x060026D4 RID: 9940 RVA: 0x001FC83F File Offset: 0x001FAA3F
			public float GetValueRaw
			{
				get
				{
					return this.m_Value;
				}
			}

			// Token: 0x04004F80 RID: 20352
			private float m_Value;
		}

		// Token: 0x02000684 RID: 1668
		public class VirtualButton
		{
			// Token: 0x1700057E RID: 1406
			// (get) Token: 0x060026D5 RID: 9941 RVA: 0x001FC847 File Offset: 0x001FAA47
			// (set) Token: 0x060026D6 RID: 9942 RVA: 0x001FC84F File Offset: 0x001FAA4F
			public string name { get; private set; }

			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x060026D7 RID: 9943 RVA: 0x001FC858 File Offset: 0x001FAA58
			// (set) Token: 0x060026D8 RID: 9944 RVA: 0x001FC860 File Offset: 0x001FAA60
			public bool matchWithInputManager { get; private set; }

			// Token: 0x060026D9 RID: 9945 RVA: 0x001FC869 File Offset: 0x001FAA69
			public VirtualButton(string name) : this(name, true)
			{
			}

			// Token: 0x060026DA RID: 9946 RVA: 0x001FC873 File Offset: 0x001FAA73
			public VirtualButton(string name, bool matchToInputSettings)
			{
				this.name = name;
				this.matchWithInputManager = matchToInputSettings;
			}

			// Token: 0x060026DB RID: 9947 RVA: 0x001FC899 File Offset: 0x001FAA99
			public void Pressed()
			{
				if (this.m_Pressed)
				{
					return;
				}
				this.m_Pressed = true;
				this.m_LastPressedFrame = Time.frameCount;
			}

			// Token: 0x060026DC RID: 9948 RVA: 0x001FC8B6 File Offset: 0x001FAAB6
			public void Released()
			{
				this.m_Pressed = false;
				this.m_ReleasedFrame = Time.frameCount;
			}

			// Token: 0x060026DD RID: 9949 RVA: 0x001FC8CA File Offset: 0x001FAACA
			public void Remove()
			{
				CrossPlatformInputManager.UnRegisterVirtualButton(this.name);
			}

			// Token: 0x17000580 RID: 1408
			// (get) Token: 0x060026DE RID: 9950 RVA: 0x001FC8D7 File Offset: 0x001FAAD7
			public bool GetButton
			{
				get
				{
					return this.m_Pressed;
				}
			}

			// Token: 0x17000581 RID: 1409
			// (get) Token: 0x060026DF RID: 9951 RVA: 0x001FC8DF File Offset: 0x001FAADF
			public bool GetButtonDown
			{
				get
				{
					return this.m_LastPressedFrame - Time.frameCount == -1;
				}
			}

			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x060026E0 RID: 9952 RVA: 0x001FC8F0 File Offset: 0x001FAAF0
			public bool GetButtonUp
			{
				get
				{
					return this.m_ReleasedFrame == Time.frameCount - 1;
				}
			}

			// Token: 0x04004F84 RID: 20356
			private int m_LastPressedFrame = -5;

			// Token: 0x04004F85 RID: 20357
			private int m_ReleasedFrame = -5;

			// Token: 0x04004F86 RID: 20358
			private bool m_Pressed;
		}
	}
}
