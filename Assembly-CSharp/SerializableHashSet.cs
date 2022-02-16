using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004A9 RID: 1193
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001B9A18 File Offset: 0x001B7C18
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x001B9A2C File Offset: 0x001B7C2C
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x001B9A8C File Offset: 0x001B7C8C
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001B9AC8 File Offset: 0x001B7CC8
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x001B9ACC File Offset: 0x001B7CCC
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

	// Token: 0x06001F72 RID: 8050 RVA: 0x001B9B30 File Offset: 0x001B7D30
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

	// Token: 0x04004181 RID: 16769
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004182 RID: 16770
	private const string XML_Element = "Element";
}
