using System;

namespace Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

    }

    internal class Brick
    {
        private string name;

        internal Brick(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    internal abstract class Character
    {
        public string name { get; set; }

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

        public void WaveHand()
        {
            Console.WriteLine(name + " macha do Ciebie");
        }
    }

    internal class Human:Character 
    {
        public Brick top_head { get; set; }
        public Brick head { get; set; }
        public Brick between_head_and_torso { get; set; }
        public Brick arms_and_torso { get; set; }
        public Brick legs { get; set; }

        public Human(string name, Brick top_head, Brick head, Brick between_head_and_torso, Brick arms_and_torso, Brick legs)
        {
            this.name = name;
            this.top_head = top_head;
            this.head = head;
            this.between_head_and_torso = between_head_and_torso;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
        }

        public Human(string name, Brick top_head, Brick head, Brick arms_and_torso, Brick legs)
        {
            this.name = name;
            this.top_head = top_head;
            this.head = head;
            this.between_head_and_torso = null;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
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

    internal class RockMonster : Character
    {
        public Brick body { get; }

        private Brick eaten;
        public Brick Eaten
        {
            get
            {
                if (eaten is null)
                    Console.WriteLine(name + " nic nie połknął!");
                return eaten;
            }
            set
            {
                if (!(eaten is null))
                    Console.WriteLine(eaten + " zostaję zastąpionę przez " + value);
                eaten = value;
            }
        }

        public RockMonster(string name,Brick body)
        {
            this.name = name;
            this.body = body;
        }

        public override string ToString()
        {
            return name + (eaten != null ? "z " + eaten.ToString() + " w brzuchu" : "");
        }
    }
}
