using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class SerializableHashSet<T> : HashSet<T>, ISerializationCallbackReceiver, IXmlSerializable
{
	// Token: 0x06001F95 RID: 8085 RVA: 0x001BDA10 File Offset: 0x001BBC10
	public SerializableHashSet()
	{
		this.elements = new List<T>();
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x001BDA24 File Offset: 0x001BBC24
	public void OnBeforeSerialize()
	{
		this.elements.Clear();
		foreach (T item in this)
		{
			this.elements.Add(item);
		}
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x001BDA84 File Offset: 0x001BBC84
	public void OnAfterDeserialize()
	{
		base.Clear();
		for (int i = 0; i < this.elements.Count; i++)
		{
			base.Add(this.elements[i]);
		}
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x001BDAC0 File Offset: 0x001BBCC0
	public XmlSchema GetSchema()
	{
		return null;
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x001BDAC4 File Offset: 0x001BBCC4
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

	// Token: 0x06001F9A RID: 8090 RVA: 0x001BDB28 File Offset: 0x001BBD28
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

	// Token: 0x04004220 RID: 16928
	[SerializeField]
	private List<T> elements;

	// Token: 0x04004221 RID: 16929
	private const string XML_Element = "Element";
}
