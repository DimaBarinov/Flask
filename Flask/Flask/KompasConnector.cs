using System;
using System.Runtime.InteropServices;
using Kompas6API5;

namespace Flask
{
    //TODO: XML комментарии?
    /// <summary>
    /// Класс подключения к Компасу.
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Объект компаса.
        /// </summary>
        public KompasObject Kompas { get; set; }

        /// <summary>
        /// Запуск КОМПАС-3D.
        /// </summary>
        public void OpenKompas()
        {
            if (!GetActiveKompas(out var kompas))
            {
                if (!CreateKompasInstance(out kompas))
                {
                    throw new ArgumentException(
                        "Не удалось создать новый экземпляр КОМПАС-3D."
                    );
                }
            }
            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            Kompas = kompas;
        }

        /// <summary>
        /// Подключение к открытому КОМПАС-3D.
        /// </summary>
        /// <param name="kompas">Ссылка на открытый КОМПАС-3D.</param>
        /// <returns>Результат подключения.</returns>
        private bool GetActiveKompas(out KompasObject kompas)
        {
            kompas = null;
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject(
                    "KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }

        /// <summary>
        /// Создание нового экземпляра КОМПАС-3D.
        /// </summary>
        /// <param name="kompas">Ссылка на экземпляр КОМПАС-3D.</param>
        /// <returns>Результат успешности создания.</returns>
        private bool CreateKompasInstance(out KompasObject kompas)
        {
            try
            {
                var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompas = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                kompas = null;
                return false;
            }
        }

    }
}
