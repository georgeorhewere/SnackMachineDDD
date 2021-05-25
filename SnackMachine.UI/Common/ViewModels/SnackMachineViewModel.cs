using SnackMachine.Logic;
using SnackMachine.UI.Common.Commands;
using System;

namespace SnackMachine.UI.Common.ViewModels
{
    public class SnackMachineViewModel: BaseViewModel
    {
        private readonly SnackMachine.Logic.SnackMachine snackMachine;
        public override string Caption => "Snack Machine DDD";
        private string message;
        public string Message { 
            get => message; 
            set { 
                message = value; 
                Notify("Message"); 
            } 
        }
        public string MoneyInTransaction => snackMachine.MoneyInTransaction.ToString();
        public Command InsertCentCommand { get; private set; }        
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertTwentyFiveCentCommand { get; private set; }
        public Command InsertOneDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        
        

        public SnackMachineViewModel(SnackMachine.Logic.SnackMachine _snackMachine)
        {
            snackMachine = _snackMachine;
            InsertCentCommand = new Command(o => InsertMoney(Money.OneCent));
            InsertTenCentCommand = new Command(o => InsertMoney(Money.TenCent));
            InsertTwentyFiveCentCommand = new Command(o => InsertMoney(Money.Quarter));
            InsertOneDollarCommand = new Command(o => InsertMoney(Money.OneDollar));
            InsertFiveDollarCommand = new Command(o => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(o => InsertMoney(Money.TwentyDollar));
        }

        private void InsertMoney(Money money)
        {
            snackMachine.InsertMoney(money);
            Notify("MoneyInTransaction");
            Message = $"You have inserted { money }";

        }
    }
}
