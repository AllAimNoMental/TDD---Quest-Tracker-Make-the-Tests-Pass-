namespace QuestProgressTracker
{

    public class Objective
    {
        public int RequiredAmount { get; set; }
        public int CurrentAmount { get; set; }
       

        //public int CurrentAmount { get; set; }
        public string Name { get; set; }

        public Objective(string Name,int requiredAmount)
        {
           this.Name = Name;
            RequiredAmount = requiredAmount;
            CurrentAmount = 0;

        }

    }



}
