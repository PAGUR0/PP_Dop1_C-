using System.Diagnostics;

namespace Trains
{
    class Train
    {
        public int Id;
        public string Direction;
        public string Time;

        public Train(int id, string direction,  string time)
        {
            Id = id;
            Direction = direction;
            Time = time;
        }

        public string getInfo()
        {
            return $"Номер поезда: {Id} \n Направление: {Direction} \n Время отправления: {Time}";
        }
    }

    class Program
    {
        static void Main()
        {
            Train[] trains = [
                    new Train(203, "Новокузнецк", "23:06"),
                    new Train(190, "Москва", "11:09"),
                    new Train(230, "Тюмень", "00:00"),
                    new Train(101, "Москва", "08:12"),
                    new Train(510, "Санк-Петербург", "14:09"),
                ];

            sortId(trains);

            

            while (true)
            {
                Console.WriteLine("\nВведите: \n1. для вывода информации о поезде по номеру, \n2. для сортировки поездов по пунктам назначения, \n3. для вывода списка поездов: ");
                string v = Console.ReadLine();

                if (v == "1")
                {
                    Console.WriteLine("Введите номер поезда: ");
                    int id = int.Parse(Console.ReadLine());
                    bool inputTrain = false;
                    foreach (Train train in trains)
                    {
                        if (train.Id == id)
                        {
                            Console.WriteLine(train.getInfo());
                            inputTrain = true;
                        }
                    }
                    if (!inputTrain)
                    {
                        Console.WriteLine("Нет такого номера поезда");
                    }

                }
                else if (v == "2")
                {
                    sortDirection(trains);
                    Console.WriteLine("Сортировка выполнена");
                } 
                else if (v == "3")
                {
                    foreach (Train train in trains)
                    {
                        Console.WriteLine(train.getInfo());
                    }
                }
                else
                {
                    Console.WriteLine("Некоректный ввод");
                }
            }
        }

        static void sortId(Train[] sortArr)
        {
            for (int i = 0; i < sortArr.Length; i++)
            {
                int min_id = i;
                Train min = sortArr[i];
                for (int j = i + 1; j < sortArr.Length; j++)
                {
                    if (sortArr[j].Id < min.Id)
                    {
                        min_id = j;
                        min = sortArr[j];
                    }
                }
                sortArr[min_id] = sortArr[i];
                sortArr[i] = min;
            }
        }

        static void sortDirection(Train[] sortArr)
        {
            for (int i = 0; i < sortArr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < sortArr.Length; j++)
                {
                    int destinationComparison = string.Compare(sortArr[j].Direction, sortArr[minIndex].Direction);
                    if (destinationComparison == 0)
                    {
                        if (string.Compare(sortArr[j].Time, sortArr[minIndex].Time) < 0)
                        {
                            minIndex = j;
                        }
                    }
                    else if (destinationComparison < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Train temp = sortArr[i];
                    sortArr[i] = sortArr[minIndex];
                    sortArr[minIndex] = temp;
                }
            }
        }
    }
}


