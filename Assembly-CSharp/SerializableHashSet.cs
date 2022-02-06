using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A8 RID: 1192
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F66 RID: 8038 RVA: 0x001B95C4 File Offset: 0x001B77C4
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x001B95D8 File Offset: 0x001B77D8
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x001B9638 File Offset: 0x001B7838
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F69 RID: 8041 RVA: 0x001B9674 File Offset: 0x001B7874
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x001B9678 File Offset: 0x001B7878
	public void ReadXml(XmlReader reader)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		bool isEmptyElement = reader.IsEmptyElement;
		reader.Read();
		if (isEmptyElement)
		{
			return;
		}
		while (reader.NodeType != XmlNodeType.EndElement)
		{
			reader.ReadStartElement("Element");
			T item = (T)((object)xmlSerializer.Deserialize(reader));
			reader.ReadEndElement();
			base.Add(item);
			reader.MoveToContent();
		}
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x001B96DC File Offset: 0x001B78DC
	public void WriteXml(XmlWriter writer)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
		foreach (T t in this)
		{
			writer.WriteStartElement("Element");
			xmlSerializer.Serialize(writer, t);
			writer.WriteEndElement();
		}
	}

	// Token: 0x04004178 RID: 16760
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004179 RID: 16761
	private const string XML_Element = "Element";
}
