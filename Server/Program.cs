using ClassLib;
using Server.BLL;
using Server.BLL.Mappers;
using Server.DAL.Sqlite_services;
using System.Text.Json;


bool error = false;
Config config = new Config() { 
	ServerPort = 8888, 
	AdminsPath = Directory.GetCurrentDirectory() + "\\Data\\Admins",
	ClientsPath = Directory.GetCurrentDirectory() + "\\Data\\Clients",
	DishesPath = Directory.GetCurrentDirectory() + "\\Data\\Dishes" };

string configPath = Directory.GetCurrentDirectory() + "\\serverConfig.json";

////Конфиг задается при запуске конкретного сервера при отладке директория Data создается в директории приложения
//if (File.Exists(configPath))
//{
//	using FileStream utf8Json = new FileStream(configPath, FileMode.Open);
//	config = JsonSerializer.Deserialize<Config>(utf8Json);
//	if (config.DishesPath == config.AdminsPath || config.DishesPath == config.ClientsPath || config.ClientsPath == config.AdminsPath)
//	{
//		Console.WriteLine("Название целевых директорий должны отличаться");
//		error = true;
//	}
//	if (!error)
//	{
//		ServerCore server = new ServerCore(config);
//		server.StartServer();
//	}
//}
//else
{
	//Console.WriteLine("Файл конфигурации отсутствует загружены настройки по умолчанию");
    Console.WriteLine("Configuration file missing, default settings loaded");
    if (!Directory.Exists(Directory.GetCurrentDirectory()+"\\Data"))
	{
		Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Data");
	}
	DirectoryCheck();
	if (config.DishesPath == config.AdminsPath || config.DishesPath == config.ClientsPath || config.ClientsPath == config.AdminsPath)
	{
        //Console.WriteLine("Название целевых директорий должны отличаться");
        Console.WriteLine("The names of the target directories must be different");
        error = true;
	}
	if (!error)
	{
		ServerCore server = new ServerCore(config);
		server.StartServer();
	}

}

void DirectoryCheck()
{
	if (!Directory.Exists(config.AdminsPath))
	{
		Directory.CreateDirectory(config.AdminsPath);
	}
	if (!Directory.Exists(config.ClientsPath))
	{
		Directory.CreateDirectory(config.ClientsPath);
	}
	if (!Directory.Exists(config.DishesPath))
	{
		Directory.CreateDirectory(config.DishesPath);
	}
}
