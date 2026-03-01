using QuestProgressTracker;
using System.Diagnostics.Metrics;


namespace QuestProgressTracker


{
    public class Quest
    {
        private string QuestName;
        public List<Objective> Objectives = new List<Objective>();
        public Objective TurnedIn;

        public Quest(string QuestName)
        {
            this.QuestName = QuestName;
        }

        public bool IsCompleted { get; set; }


        //public void AddObjective(List<Objective> Objectives, string v1, int v2)
        //{
        //    Objective objective = new Objective(v1, v2);
        //    Objectives.Add(objective);
        //}
        public void AddObjective( string v1, int v2)
        {
            Objective objective = new Objective(v1, v2);
            Objectives.Add(objective);
        }


        public Objective GetObjective(string objectiveName)
        {
            List<Objective> gettingObjective = Objectives.Where(o => o.Name == objectiveName).ToList();
            if (gettingObjective.Count() > 0)
            {
                //gettingObjective.Name
                Console.WriteLine(objectiveName);
                return gettingObjective[0];
            }

            else
            {
                Console.WriteLine("There is no objectives with that name");
                return null;
            }


        }

        public void ProgressObjective(string nameObjective, int currentAmount)
        {
            var objective = GetObjective(nameObjective);
            objective.CurrentAmount = currentAmount;

            if (currentAmount > objective.RequiredAmount)
            {
                objective.CurrentAmount = objective.RequiredAmount;
            }
            else
            {
                objective.CurrentAmount = currentAmount;
            }
          
        }
        public void TurnIn(string ObjectiveName)
        {
            var ObjectiveTurnedIn = GetObjective(ObjectiveName);
            
            if (ObjectiveTurnedIn == null)
            {
                return;
            }

            if (ObjectiveTurnedIn.CurrentAmount < ObjectiveTurnedIn.RequiredAmount || ObjectiveTurnedIn.CurrentAmount > ObjectiveTurnedIn.RequiredAmount)
            {
                
                IsCompleted = false;    
                return;
            }

            TurnedIn = ObjectiveTurnedIn;
            IsCompleted = true; 

        }

    }
}
