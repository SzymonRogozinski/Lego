using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character c = new Character(new Brick("Czerwona czapka"),
                new Brick("Żółta głowa"),
                new Brick("Koszula w kratę"),
                new Brick("Niebieskie spodnie"));

            Console.WriteLine(c);
            Console.Beep();
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

    internal class Character
    {
        Brick top_head;
        Brick head;
        Brick between_head_and_torso;
        Brick arms_and_torso;
        Brick legs;

        public Character(Brick top_head, Brick head, Brick between_head_and_torso, Brick arms_and_torso, Brick legs)
        {
            this.top_head = top_head;
            this.head = head;
            this.between_head_and_torso = between_head_and_torso;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
        }

        public Character(Brick top_head, Brick head, Brick arms_and_torso, Brick legs)
        {
            this.top_head = top_head;
            this.head = head;
            between_head_and_torso = null;
            this.arms_and_torso = arms_and_torso;
            this.legs = legs;
        }

        public override string ToString()
        {
            return top_head.ToString()+"\n"
                +head.ToString() + "\n"
                + (between_head_and_torso==null ? "" : between_head_and_torso.ToString()+ "\n")
                + arms_and_torso.ToString() + "\n"
                + legs.ToString();
        }
    }
}
