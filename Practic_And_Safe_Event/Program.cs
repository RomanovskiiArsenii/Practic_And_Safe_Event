internal sealed class Program
{
    public class Publisher
    {
        //создание события с исключением возможности возникновения NullReferenceException
        //указатель заполнения типом определяет тип входного параметра
        //если требуется выходной параметр, Action следует заменить на Func
        public event Action<int> OnCall = delegate { };

        //метод вызова события
        public void Call(int arg)
        {
            OnCall.Invoke(arg);
        }
    }
    public class Subscriber
    {
        // метод-обработчик события
        public void OnCallHandler(int arg)
        {
            Console.WriteLine($"Handler from subscriber, input arg: {arg}");
        }
    }
    static void Main(string[] args)
    {

        Publisher publisher = new Publisher();          //создаем экземпляр издателя
        Subscriber subscriber = new Subscriber();       //создаем экземпляр подписчика, в конструкторе подписываемся на событие

        publisher.OnCall += subscriber.OnCallHandler;
        publisher.Call(42);                             //Handler from subscriber, arg: 42
        publisher.OnCall -= subscriber.OnCallHandler;
    }
}