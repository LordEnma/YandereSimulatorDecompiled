using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A7 RID: 1191
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F5D RID: 8029 RVA: 0x001B7EA0 File Offset: 0x001B60A0
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x001B7EB4 File Offset: 0x001B60B4
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x001B7F14 File Offset: 0x001B6114
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x001B7F50 File Offset: 0x001B6150
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x001B7F54 File Offset: 0x001B6154
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

	// Token: 0x06001F62 RID: 8034 RVA: 0x001B7FB8 File Offset: 0x001B61B8
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

	// Token: 0x04004160 RID: 16736
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004161 RID: 16737
	private const string XML_Element = "Element";
}
