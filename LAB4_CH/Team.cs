using System;

namespace LAB4_CH
{
    class Team : INameAndCopy
    {
        protected string name;

        protected int reg_num;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Reg_num
        {
            get
            {
                return reg_num;
            }
            set
            {
                if (reg_num <= 0) throw new Exception("Присваиваемое значение меньше или равно 0");
                else reg_num = value;
            }
        }

        public Team(string name, int reg_num)
        {
            this.name = name;
            this.reg_num = reg_num;
        }

        public Team() : this("Имя", 0) { }

        public object DeepCopy()
        {
            return new Team(name, reg_num);
        }

        public override bool Equals(object obj)
        {
            return obj is Team team &&
                   Name == team.Name &&
                   reg_num == team.reg_num;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, reg_num);
        }

        public override string ToString()
        {
            return name + " " + reg_num;
        }

        public static bool operator ==(Team ob1, Team ob2)
        {
            return ob1.name == ob2.name && ob1.reg_num == ob2.reg_num;
        }

        public static bool operator !=(Team ob1, Team ob2)
        {
            return ob1.name != ob2.name || ob1.reg_num != ob2.reg_num;
        }

    }
}
