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
            foreach(var item in list){
                 if(index<count){
                    index++;
                    yield return item; 
                 }          
            }
        }

        public static IEnumerable<double> DoSelect(this IEnumerable<double> list , Func<double , double> function){

            foreach(var item in list){
                    yield return function(item);                        
            }
        }

        public static double AddOne(double x)
        {
            return x+1;
        }

        public static double Square(double x)
        {
            return x+x;
        }
        public static double MinusTen(double x)
        {
            return x-10;
        }
}