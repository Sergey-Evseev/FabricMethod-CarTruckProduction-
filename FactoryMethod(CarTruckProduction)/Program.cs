/*Фабричный метод (Factory Method) - это паттерн, который определяет интерфейс для создания объектов некоторого класса, 
 * но непосредственное решение о том, объект какого класса создавать происходит в подклассах. То есть паттерн предполагает, 
 * что базовый класс делегирует создание объектов классам-наследникам. 
 Недостаток паттерна в необходимости создавать наследника для каждого нового типа*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_CarTruckProduction_
{
    //абстрактное представление процесса выпуска нового автомобиля
    interface IProduction
    {
        void Release();
    }
    //класс конкретного автомобиля
    class Car : IProduction
    {    //переопределение метода интерфейса    
         public void Release() => Console.WriteLine("Выпущен легковой автомобиль");         
    }

    //конкретный класс грузового автомобиля
    class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен грузовой автомобиль");
    }

    //интерфейс цеха, метод возвращает абстрактный автомобиль
    interface IWorkshop
    {
        IProduction Create(); //создает экземпляр типа IProduction
    }

    //класс конкретного цеха по производству легковый автомобилей 
    class CarWorkShop : IWorkshop
    {
        public IProduction Create() => new Car(); //переопред. метод интерфейса возвращает легковой автомобиль типа IP roduction      
    }
    //конкретный цех по производству грузовых автомобилей 
    class TruckWorkShop : IWorkshop
    {
        public IProduction Create() => new Truck(); //переопред. метод возвращает экземпляр грузового автомобиля
    }

    class Program
    {
        static void Main(string[] args)
        {
            //создаем экземляр цеха по производству легковых автомобилей
            IWorkshop creator = new CarWorkShop();

            //создание легкового автомобиля
            IProduction car = creator.Create();

            //передача производства цеху грузовых авомобилей
            creator = new TruckWorkShop();

            //создание грузового автомобиля
            IProduction truck = creator.Create();

            //выпуск легкового автомобиля
            car.Release();

            //выпуск грузового автомобиля
            truck.Release();            
        }
    }
}
