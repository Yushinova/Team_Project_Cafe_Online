using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLib
{
	static public class TransportServices
	{
		//Упаковщик класса Courier. Принимает класс Courier, возвращает byte[]
		static public byte[] Packer(Courier courier)
		{
			try
			{
				return JsonSerializer.SerializeToUtf8Bytes(courier);
			}
			catch (Exception)
			{
				throw;
			}
		}

		//Упаковщик команды string  Принимает класс string, возвращает byte[] Команда упаковывается в Courier
		static public byte[] Packer(string _command)
		{
			Courier courier = new Courier();
			courier.Header = _command;
			return JsonSerializer.SerializeToUtf8Bytes(courier);
		}

		//Упаковщик Generic
		static public byte[] Packer(object obj)
		{
			try
			{
				return JsonSerializer.SerializeToUtf8Bytes(obj);
			}
			catch (Exception)
			{
				throw;
			}
		}

		//Отправитель Byte[]->Stream
		static public void WriteData(NetworkStream _stream, byte[] _data)
		{
			BinaryWriter writer = new BinaryWriter(_stream);

			//Сначала отправляю длину массива
			writer.Write(_data.Length);
			//Отправляю массив
			writer.Write(_data);
		}

		//Приемник Stream->Byte[]
		static public byte[] ReadData(NetworkStream _stream)
		{
			BinaryReader reader = new BinaryReader(_stream, Encoding.UTF8, true);
			//Принимаю длину массива
			int size = reader.ReadInt32();
			//читаю массив и возвращаю
			byte[] bytes = reader.ReadBytes(size);
			return bytes;
		}

		//Упаковщик класса Courier. Принимает класс Courier, пишет в stream
		static public void PackerAndSender(NetworkStream _stream, Courier _courier)
		{
			try
			{
				byte[] data = JsonSerializer.SerializeToUtf8Bytes(_courier);
				WriteData(_stream, data);
			}
			catch (Exception)
			{
				throw;
			}
		}

		//Распаковщик класса Courier принимает stream, возвращает класс Courier
		public static Courier ReciverAndUnpacker(NetworkStream _stream)
		{
			try
			{
				byte[] temp = ReadData(_stream);
				return JsonSerializer.Deserialize<Courier>(temp);
			}
			catch (Exception ex)
			{
				//Console.WriteLine($"{ex.Message} Ошибка чтения потока на входе");
				return new Courier() { Header = "NoCommand" };
			}
		}

		//Распаковщик принимает byte[], возвращает Generic класс
		public static T Unpacker<T>(byte[] _bytes)
		{
			try
			{
				return JsonSerializer.Deserialize<T>(_bytes);
			}
			catch (Exception ex)
			{
				//Console.WriteLine($"{ex.Message} Ошибка чтения потока на входе");
				throw;
			}
		}
	}


	// https://learn.microsoft.com/ru-ru/dotnet/standard/serialization/binaryformatter-security-guide
	//		//Упаковщик класса Courier. Принимает класс Courier, возвращает byte[]
	//#pragma warning disable SYSLIB0011 // Type or member is obsolete
	//		static public byte[] Packer(Courier courier)
	//		{
	//			try
	//			{

	//				BinaryFormatter formatter = new BinaryFormatter();
	//				using (MemoryStream stream = new MemoryStream())//переводим объект в байты
	//				{
	//					formatter = new BinaryFormatter();
	//					formatter.Serialize(stream, courier);
	//					byte[] data = stream.ToArray();
	//					return data;
	//				}
	//			}
	//			catch (Exception)
	//			{
	//				throw;
	//			}
	//		}

	//		//Упаковщик команды string  Принимает класс string, возвращает byte[] Команда упаковывается в Courier
	//		static public byte[] Packer(string _command)
	//		{
	//			BinaryFormatter formatter = new BinaryFormatter();
	//			using (MemoryStream stream = new MemoryStream())//переводим объект в байты
	//			{
	//				Courier courier = new Courier();
	//				courier.Header = _command;
	//				formatter = new BinaryFormatter();
	//				formatter.Serialize(stream, courier);
	//				byte[] data = stream.ToArray();
	//				return data;
	//			}
	//		}

	//		//Упаковщик Generic
	//		static public byte[] Packer<T>(T obj)
	//		{
	//			try
	//			{
	//				BinaryFormatter formatter = new BinaryFormatter();
	//				using (MemoryStream stream = new MemoryStream())//переводим объект в байты
	//				{
	//					formatter = new BinaryFormatter();
	//					formatter.Serialize(stream, obj);
	//					byte[] data = stream.ToArray();
	//					return data;
	//				}
	//			}
	//			catch (Exception)
	//			{
	//				throw;
	//			}
	//		}

	//		//Отправитель Byte[]->Stream
	//		static public void WriteData(Stream _stream, byte[] _data)
	//		{
	//			using BinaryWriter writer = new BinaryWriter(_stream);
	//			//Сначала отправляю длину массива
	//			writer.Write(_data.Length);
	//			//Отправляю массив
	//			writer.Write(_data);
	//		}

	//		//Приемник Stream->Byte[]
	//		static public byte[] ReadData(Stream _stream)
	//		{
	//			using BinaryReader reader = new BinaryReader(_stream, Encoding.UTF8, true);
	//			//Принимаю длину массива
	//			int size = reader.ReadInt32();
	//			//читаю массив и возвращаю
	//			return reader.ReadBytes(size);
	//		}


	//		//Упаковщик класса Courier. Принимает класс Courier, пишет в stream
	//		static public void PackerAndSender(Stream _stream, Courier _courier)
	//		{
	//			try
	//			{
	//				BinaryFormatter formatter = new BinaryFormatter();
	//				using (MemoryStream memStream = new MemoryStream())//переводим объект в байты
	//				{
	//					formatter = new BinaryFormatter();
	//					formatter.Serialize(memStream, _courier);
	//					byte[] data = memStream.ToArray();
	//					WriteData(_stream, data);
	//				}
	//			}
	//			catch (Exception)
	//			{
	//				throw;
	//			}
	//		}

	//		//Распаковщик класса Courier принимает stream, возвращает класс Courier
	//		public static Courier ReciverAndUnpacker(Stream _stream)
	//		{
	//			try
	//			{
	//				byte[] bytes = ReadData(_stream);
	//				using MemoryStream bms = new MemoryStream(bytes);
	//				BinaryFormatter bformatter = new BinaryFormatter();
	//				return (Courier)bformatter.Deserialize(bms);
	//			}
	//			catch (Exception ex)
	//			{
	//				//Console.WriteLine($"{ex.Message} Ошибка чтения потока на входе");
	//				return new Courier() { Header = "NoCommand" };
	//			}
	//		}

	//		//Распаковщик принимает byte[], возвращает Generic класс
	//		public static T Unpacker<T>(byte[] _bytes)
	//		{
	//			try
	//			{
	//				using MemoryStream bms = new MemoryStream(_bytes);
	//				BinaryFormatter bformatter = new BinaryFormatter();
	//				return (T)bformatter.Deserialize(bms);
	//			}
	//			catch (Exception ex)
	//			{
	//				//Console.WriteLine($"{ex.Message} Ошибка чтения потока на входе");
	//				throw;
	//			}
	//		}
	//#pragma warning restore SYSLIB0011 // Type or member is obsolete
}

