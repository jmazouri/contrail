using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConTrail.Game.Models
{
    public class GameStats
    {
        public DateTime StartTime { get; set; }

        public TimeSpan SessionTime
        {
            get { return DateTime.Now.Subtract(StartTime); }
        }

        public decimal MoneyEarned { get; set; }
        public decimal MoneySpent { get; set; }

        public int WantedLevel { get; set; }

        public decimal Money { get; set; }

        public string GameName { get; set; }

        public decimal Gas { get; set; }

        public void SpendMoney(decimal amount)
        {
            MoneySpent += amount;
            Money -= amount;
        }

        public void EarnMoney(decimal amount)
        {
            MoneyEarned += amount;
            Money += amount;
        }
    }
}
