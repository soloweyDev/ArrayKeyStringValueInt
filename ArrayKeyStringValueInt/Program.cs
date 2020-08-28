using System;

namespace ArrayKeyStringValueInt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Тест класса. Дата условного окончания интервалов жизни. Данные условнные.
            ArrayKeyStringValueInt keyValue = new ArrayKeyStringValueInt(5);

            try
            {
                keyValue["садик"] = 1985;
                keyValue["школа"] = 1990;
                keyValue["вуз"]   = 2000;
                keyValue["служба"]= 2005;
                keyValue["работа"]= 2007;

                // Ищем окончание школы
                Console.WriteLine($"Окончание школы в {keyValue["школа"]} году");

                // Ищем окончание службы
                Console.WriteLine($"Служить закончил в {keyValue["служба"]} году");

                // Общие количество записей
                Console.WriteLine($"Всего записей: {keyValue.Count}");

                // Получим ошибку для прикола
                int future = keyValue["пенсия"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class ArrayKeyStringValueInt
    {
        // Следующая строка обеспечивает "ключ" к массиву - это строка, которая идентифицирует элемент
        private string[] _keys;
        // int представляет собой фактические данные, связанные с ключом
        private int[] _arrayElements;
        // количество элементов в массиве
        public int Count { get; set; }

        // ArrayKeyStringValueInt создание массива фиксированного размера
        public ArrayKeyStringValueInt(int nSize)
        {
            _keys = new string[nSize];
            _arrayElements = new int[nSize];
            Count = nSize;
        }

        // Find - поиск индекса записи, соответствующей строке targetKey (если запись не найдена, возвращает -1)
        private int Find(string targetKey)
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (String.Compare(_keys[i], targetKey) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        // FindEmpty - поиск свободного места в массиве для новой записи
        private int FindEmpty()
        {
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i] == null)
                {
                    return i;
                }
            }

            throw new Exception("Maccив заполнен");
        }

        // Ищем содержимое по указанной строке
        public int this[string key]
        {
            set
            {
                // Проверяем, нет ли уже такой строки
                int index = Find(key);
                if (index < 0)
                {
                    // Если нет, ищем новое место
                    index = FindEmpty();
                    _keys[index] = key;
                }
                // Сохраняем объект в соответствующей позиции
                _arrayElements[index] = value;
            }
            get
            {
                int index = Find(key);
                if (index < 0)
                {
                    throw new Exception("Значение не найдено");
                }
                return _arrayElements[index];
            }
        }
    }
}
