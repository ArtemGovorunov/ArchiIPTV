using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchiIPTV_Player
{
    public static class Chanels
    {
        /// <summary>
        /// Метод принимающий содержимое m3u файла и производит парсинг возвращая массив обьектов типа Chanel
        /// </summary>
        /// <param name="Path"> Строка содержащая содержимое m3u файла.</param>
        /// </param>
        /// <returns>
        /// Возвращает массив обьектов типа Chanel
        /// </returns>
        public static List<Chanel> GetChanelsFromFile_m3u()
        {

            string linkUrl = "tv.lan.ua";
            string result = string.Empty;

            WebClient client = new WebClient();
            try
            {
                using (Stream stream = client.OpenRead("http://" + linkUrl))
                {
                    using (StreamReader reader = new StreamReader(stream))
                        result = reader.ReadToEnd();
                }
                if (!string.IsNullOrEmpty(result))
                {
                    Properties.Settings.Default.M3UFile = result;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {
                throw new Exception();
            }

            string source = Properties.Settings.Default.M3UFile;
            //Создаем массив строк разбивая входную строку по переносам строки
            string[] lines = source.Split(new string[] { "\n", "\r", "\n\r", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //Инициализируем список в который будем записывать каналы
            List<Chanel> chanels = new List<Chanel>();
            //Если первая строка содержит #EXTM3U
            if (lines[0].Trim().ToUpper().Contains("#EXTM3U"))
            {
                //string title = string.Empty;
                for (int i = 0; i < lines.Length; i++)
                {
                    //Если строка начинаеться с #EXTINF
                    if (lines[i].StartsWith("#EXTINF", StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Сплитим данную строку
                        string[] info = lines[i].Split(new string[] { ":", "," }, StringSplitOptions.None);
                        if (info.Length > 2)
                            //title = info[2];
                            //Добавляем в лист наш новый канал по определенному разположению
                            chanels.Add(new Chanel(info[2], lines[++i]));
                    }
                }
            }
            else
            {//Если в начале файла нет директивы #EXTM3U генерируем исключение
                throw new Exception("Incorrect M3U Playlist");
            }
            //Возвращаем лист каналов преобразовав в массив Chanel
            return chanels/*.ToArray()*/;
        }
    }
    /// <summary>
    /// Класс представляющий из себя сущность канала
    /// </summary>
    /// <remarks>
    /// Содержит в себе 2 публичных свойства Названия канала и адреса на m3u поток
    /// </remarks>
    public class Chanel
    {
        /// <summary>
        /// Конструктор Chanel принимает 2 параметра.
        /// </summary>
        /// <param name="title">Имя канала</param>
        /// <param name="adress">Адрес на m3u поток</param>
        public Chanel(string title, string adress)
        {
            this.Title = title;
            this.Adress = adress;
        }
        /// <summary>
        /// Свойство имени канала
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Свойство имени канала
        /// </summary>
        public string Adress { get; set; }

    }
}
