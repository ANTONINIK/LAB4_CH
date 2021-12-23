namespace LAB4_CH
{
    public class ResearchTeamsChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }

        public Revision typeEvent { get; set; }

        public int reg_num { get; set; }

        public string PropertyName { get; set; }

        public ResearchTeamsChangedEventArgs(string CollectionName, Revision typeEvent, string PropertyName, int reg_num)
        {
            this.CollectionName = CollectionName;
            this.typeEvent = typeEvent;
            this.reg_num = reg_num;
            this.PropertyName = PropertyName;
        }

        public override string ToString()
        {
            return CollectionName.ToString() + " " + typeEvent.ToString() + " " + reg_num.ToString() + " " + PropertyName.ToString();
        }
    }
}