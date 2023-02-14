internal static class Program
{
        public static List<double> Numbers = new List<double> {2,1,3,6,9,10,11,13,18};
    private static void Main(string[] args)
    {

        Numbers.DoSelect(AddOne).DoSelect(Square).DoSelect(MinusTen).DoWhere(x=> x>5).DoTake(2).ToList().ForEach(x=> Console.WriteLine(x));
        Console.ReadLine();
    }

        public static IEnumerable<double> DoWhere(this IEnumerable<double> list, Func<double , bool> condition){
            foreach(var item in list){
                if(condition(item)){
                    yield return item;
                }
            }
        }

        public static IEnumerable<double> DoTake(this IEnumerable<double> list , int count){
            int index = 0;
            IEnumerator<double> Cursor = list.GetEnumerator();
            do{
                if(index!=count){
                    Cursor.MoveNext();
                }
                var v = Cursor.Current;
                if(index<count){
                    yield return v;
                    index++;
                }else{
                    yield break;
                }
            } while(true);       
        }

        public static IEnumerable<double> DoSelect(this IEnumerable<double> list , Func<double , double> function){

            foreach(var item in list){
                    yield return function(item);                        
            }
        }

        public static double AddOne(double x)
        {
            Console.WriteLine("I am adding one");
            return x+1;
        }

        public static double Square(double x)
        {
             Console.WriteLine("I am doing Square");
            return x+x;
        }
        public static double MinusTen(double x)
        {
             Console.WriteLine("I am sudtracting ten ----------------------");
            return x-10;
        }
}