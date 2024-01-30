using System.Text;

namespace CS_Lab2
{

    public abstract class Animal
    {

        string name;
        double weight;
        int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public Animal()
        {
            name = "";
            weight = 0;
            age = 0;
        }

        public Animal(string name, double weight, int age)
        {
            this.name = name;
            this.weight = weight;
            this.age = age;
        }
        virtual public void max_speed() { }

        virtual public void bite() { }

        virtual public void eat() { }
        virtual public void move() { }
        virtual public void makeSound() { }

    }

    public abstract class Mammals : Animal
    {

        string color;
        const bool wool = true;
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public bool Wool
        {
            get { return wool; }
        }
        public Mammals(string color, string name, double weight, int age) : base(name, weight, age)
        {
            this.color = color;
        }
        virtual public void sleep()
        {
            Console.WriteLine("The mammal is sleeping...\n");
        }
    }

    public abstract class Insects : Animal
    {
        bool wings;
        int legs;

        public int Legs
        {
            get { return legs; }
            set { legs = value; }
        }
        public bool Wings
        {
            get { return wings; }
            set { wings = value; }
        }

        public Insects(bool wings, int legs)
        {
            this.wings = wings;
            this.legs = legs;
        }
        override public void eat()
        {
            Console.WriteLine("Insect " + Name + " eating plants\n");
        }

    }

    public class Spider : Animal
    {
        const int legs = 8;
        int eyes;
        bool poisonous;

        public int Legs
        {
            get { return legs; }
        }
        public int Eyes
        {
            get { return eyes; }
            set { eyes = value; }
        }
        public bool Poisonous
        {
            get { return poisonous; }
            set { poisonous = value; }
        }

        public Spider(int eyes, bool poisonous, string name, double weight, int age) : base(name, weight, age)
        {
            Console.WriteLine("Spider " + name + "\n");
            this.eyes = eyes;
            this.poisonous = poisonous;
        }

        public void feedSpider()
        {
            Console.WriteLine("You fed the spider " + Name);
        }
        override public void bite()
        {
            if (poisonous) Console.WriteLine("You are SpiderMan :)\n");
            else Console.WriteLine("Spider isn't poisonous.It's OK :)\n");
        }

        override public void move()
        {
            Console.WriteLine("Spider " + Name + " crawling\n");
        }

        override public void eat()
        {
            Console.WriteLine("Spider " + Name + " eats insects\n");
        }
    }

    public class Horse : Mammals
    {
        string hairColor;
        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; }
        }

        public Horse(string hairColor, string color, string name, int weight, int age) : base(color, name, weight, age)
        {
            Console.WriteLine("Horse " + name + "\n");
            this.hairColor = hairColor;
        }

        public void rideHorse()
        {
            Console.WriteLine("You got on horse " + Name);
        }

        override public void sleep()
        {
            Console.WriteLine("The horse is sleeping...\n");
        }
        override public void max_speed()
        {
            Console.WriteLine("Max speed: 88 km/h\n");
        }
        override public void makeSound()
        {
            Console.WriteLine("Horse neighs\n");
        }

        override public void eat()
        {
            Console.WriteLine("Horse " + Name + " eats grass\n");
        }

        override public void move()
        {
            Console.WriteLine("Horse " + Name + " running\n");
        }
    }

    public class Fish : Animal
    {
        int fins;
        string color;

        public int Fins
        {
            get { return fins; }
            set { fins = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public Fish(int fins, string color, string name, double weight, int age) : base(name, weight, age)
        {
            Console.WriteLine("Fish " + name + "\n");
            this.fins = fins;
            this.color = color;
        }

        public void catchFish()
        {
            Console.WriteLine("You caught a fish " + Name);
        }

        override public void move()
        {
            Console.WriteLine("Fish " + Name + " swimming\n");
        }
        override public void eat()
        {
            Console.WriteLine("Fish " + Name + " eats plankton\n");
        }
        override public void bite()
        {
            Console.WriteLine("You are hurt.It's piranha or shark\n");
        }


    }

    public class Dog : Mammals
    {
        string habitat;
        public string Habitat
        {
            get { return habitat; }
            set { habitat = value; }
        }

        public Dog(string habitat, string color, string name, int weight, int age) : base(color, name, weight, age)
        {
            Console.WriteLine("Dog " + name + "\n");
            this.habitat = habitat;
        }
        public void playwithDog()
        {
            Console.WriteLine("You play with dog " + Name);
        }

        override public void sleep()
        {
            Console.WriteLine("The dog is sleeping...\n");
        }
        override public void max_speed()
        {
            if (Weight < 40) Console.WriteLine("Max speed: 15.5 km/h\n");
            else if (Weight < 90) Console.WriteLine("Max speed: 18.3 km/h\n");
            else Console.WriteLine("Max speed: 16.2 km/h\n");
        }
        override public void makeSound()
        {
            Console.WriteLine("Waff-Waff\n");
        }

        override public void bite()
        {
            if (habitat == "street") Console.WriteLine("Maybe you got rabies\n");
            else Console.WriteLine("You are hurt\n");
        }
        override public void eat()
        {
            if (habitat == "street") Console.WriteLine("Dog " + Name + " eating garbage food\n");
            else Console.WriteLine("Dog " + Name + " eats dog food\n");
        }
        override public void move()
        {
            Console.WriteLine("Dog " + Name + " running around\n");
        }
    }

    public class Crocodile : Animal
    {
        double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public Crocodile(double length, string name, double weight, int age) : base(name, weight, age)
        {
            Console.WriteLine("Crocodile " + name + "\n");
            this.length = length;
        }

        public void feedCrocodile()
        {
            Console.WriteLine("You fed the crocodile " + Name);
        }
        override public void max_speed()
        {
            Console.WriteLine("Max speed: 48 km/h\n");
        }

        override public void eat()
        {
            Console.WriteLine("Crocodile " + Name + " eats fish\n");
        }

        override public void bite()
        {
            Console.WriteLine("Crocodile bit off your leg\n");
        }
        override public void move()
        {
            Console.WriteLine("Crocodile " + Name + " swimming\n");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //  Animal animal;
            //  Mammals mammals;
            //  Insects insects;
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Horse horse = new Horse("black", "white", "Phantom", 200, 12);
            Console.WriteLine("Haircolor " + horse.HairColor + " color " + horse.Color + "\n");
            horse.eat();
            horse.move();
            horse.makeSound();
            horse.bite();
            horse.max_speed();
            horse.sleep();
            horse.rideHorse();
            Console.WriteLine("\n");

            Dog dog = new Dog("street", "yellow", "Jeff", 20, 4);

            dog.eat();
            dog.move();
            dog.makeSound();
            dog.bite();
            dog.max_speed();
            dog.sleep();
            dog.playwithDog();
            Console.WriteLine("\n");

            Fish fish = new Fish(3, "orange", "Nemo", 0.2, 5);

            fish.eat();
            fish.move();
            fish.makeSound();
            fish.bite();
            fish.max_speed();
            fish.catchFish();
            Console.WriteLine("\n");

            Crocodile croco = new Crocodile(2.5, "Gena", 700, 10);

            croco.eat();
            croco.move();
            croco.makeSound();
            croco.bite();
            croco.max_speed();
            croco.feedCrocodile();
            Console.WriteLine("\n");

            Spider spider = new Spider(4, true, "Peter", 0.3, 4);

            spider.eat();
            spider.move();
            spider.makeSound();
            spider.bite();
            spider.max_speed();
            spider.feedSpider();
            Console.WriteLine("\n");

        }
    }
}
