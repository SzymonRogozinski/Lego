using System;

namespace Lego
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Playground();
            Console.WriteLine("Pora posprzątać");
            Console.WriteLine();
            TrowOutIntoBox();
            Console.Read();
        }

        private static void Playground()
        {
            Character cavewoman = new Character("Pani jaskiniowiec",
                new Brick("Bujna fryzura z kością"),
                new Brick("Żółta zdziwiona głowa"),
                new Brick("Koszulka ze skór zwierzęcych"),
                new Brick("Spodnie ze skór zwierzęcych"));

            Character wizard = new Character("Czarodziej",
                new Brick("Czapka Czarodzieja"),
                new Brick("Żółta poważna twarz"),
                new Brick("Długa broda"),
                new Brick("Szara koszulka"),
                new Brick("Szare spodnie"));

            Character panda = new Character("Kobieta w stroju pandy",
                new Brick("Długie włosy"),
                new Brick("Uśmiechnięta twarz"),
                new Brick("Kostium pandy: koszulka"),
                new Brick("Kostium pandy: spodnie"));

            Character liberty = new Character("Statua wolności",
                new Brick("Korona"),
                new Brick("Zielona twarz"),
                new Brick("Długa suknia: góra"),
                new Brick("Długa suknia: dół"));

            Console.WriteLine(cavewoman);
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine(wizard);
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine(panda);
            Console.WriteLine();
            Console.ReadKey();
            panda.top_head = new Brick("Maska pandy");
            Console.WriteLine(panda);
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine(liberty);
            Console.WriteLine();
            Console.ReadKey();
            liberty.InRightHand = new Brick("Pochodnia");
            Console.WriteLine();
            Console.ReadKey();

            cavewoman.WaveHand();
            wizard.WaveHand();
            panda.WaveHand();
            liberty.WaveHand();
            Console.WriteLine();
            Console.ReadKey();
        }

        static void TrowOutIntoBox()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    internal class Brick
    {
        private string name;

        internal Brick(string name)
        {
            this.name = name;
        }

        ~Brick()
        {
            Console.WriteLine(name + " został wrzucony do pudełka");
        }

        public override string ToString()
        {
            return name;
        }
    }

    internal class Character
    {
        public string name { get; }
        public Brick top_head { get; set; }
        public Brick head { get; set; }
        public Brick between_head_and_torso { get; set; }
        public Brick arms_and_torso { get; set; }
        public Brick legs { get; set; }

        private Brick in_right_hand;

        public Brick InRightHand
        {
            get
            {
                if (in_right_hand == null)
                    Console.WriteLine("Postać nie trzyma nic w prawej ręce!");
                return in_right_hand;
            }
            set
            {
                Console.WriteLine("Postać podniosła " + value.ToString());
                in_right_hand = value;
            }
        }

        private Brick in_left_hand;
        
        public Brick InLeftHand
        {
            get
            {
                if (in_left_hand == null)
                    Console.WriteLine("Postać nie trzyma nic w lewej ręce!");
                return in_left_hand;
            }
            set
            {
                Console.WriteLine("Postać podniosła " + value.ToString());
                in_left_hand = value;
            }
        }

        public Character(string name, Brick top_head, Brick head, Brick between_head_and_torso, Brick arms_and_torso, Brick legs)
        {
            this.name = name;
            this.top_head = top_head;
            this.head = head;
            this.between_head_and_torso = between_head_and_torso;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
        }

        public Character(string name, Brick top_head, Brick head, Brick arms_and_torso, Brick legs)
        {
            this.name = name;
            this.top_head = top_head;
            this.head = head;
            between_head_and_torso = null;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
        }

        ~Character()
        {
            Console.WriteLine(name+" została rozłożona");
        }

        public void WaveHand()
        {
            Console.WriteLine(name + " macha do Ciebie");
        }

        public override string ToString()
        {
            return name + " składa się z:\n"
                + top_head.ToString() + "\n"
                + head.ToString() + "\n"
                + (between_head_and_torso == null ? "" : between_head_and_torso.ToString() + "\n")
                + arms_and_torso.ToString() + "\n"
                + legs.ToString();
        }
    }
}
