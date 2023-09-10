namespace Animal
{
    class Person
    {
        public string name;
        public int age;
        public double height;

        public void Sayhi()
        {
            Console.WriteLine("你好啊 ! 我叫做" + name);
        }

        public bool adult()
        {
            if(age > 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
