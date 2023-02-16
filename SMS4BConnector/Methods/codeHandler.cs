using System;
using System.Collections.Generic;
using System.Text;

namespace SMS4BConnector.Methods
{
    public class codeHandler
    {
        public codeHandler()
        {
            
        }
        public void checkCode(long code)
        {
            switch (code)
            {
                case -1:
                    Console.WriteLine("Пользователь или пароль (или код сессии) не распознаны сервисом\n");
                    break;
                case -2:
                    Console.WriteLine("Сессия оказалась закрытой по таймауту к моменту обработки вызова\n");
                    break;
                case -10:
                    Console.WriteLine("Cбой выполнения метода\n");
                    break;
                case -20:
                    Console.WriteLine("Сбой сеанса связи'. Обнаружение попытки работы в чужой сессии\n");
                    break;
                case -21:
                    Console.WriteLine("Сообщение не идентифицировано. Не указан корректный глобальный уникальный идентификатор GUID\n");
                    break;
                case -22:
                    Console.WriteLine("Неверный идентификатор сообщения\n");
                    break;
                case -23:
                    Console.WriteLine("Неверное смещение GMT\n");
                    break;
                case -29:
                    Console.WriteLine("Сообщение не прошло проверки (спам-фильтр)\n");
                    break;
                case 0:
                    Console.WriteLine("Код 0");
                    break;

            }
        }

    }
}
