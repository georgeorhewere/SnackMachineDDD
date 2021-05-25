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
        public Money MoneyInside => snackMachine.MoneyInTransaction + snackMachine.MoneyInside;
        public Command InsertCentCommand { get; private set; }        
        public Command InsertTenCentCommand { get; private set; }
        public Command InsertTwentyFiveCentCommand { get; private set; }
        public Command InsertOneDollarCommand { get; private set; }
        public Command InsertFiveDollarCommand { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        public Command ReturnMoneyCommand { get; private set; }
        public Command BuySnackCommand { get; private set; }

        public SnackMachineViewModel(SnackMachine.Logic.SnackMachine _snackMachine)
        {
            snackMachine = _snackMachine;
            InsertCentCommand = new Command(() => InsertMoney(Money.OneCent));
            InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
            InsertTwentyFiveCentCommand = new Command(() => InsertMoney(Money.Quarter));
            InsertOneDollarCommand = new Command(() => InsertMoney(Money.OneDollar));
            InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command(() => BuySnack());
        }

        private void BuySnack()
        {
            snackMachine.BuySnack();
            string uiMessage = "Snack has been purchased";
            UpdateUI(uiMessage);
        }

        private void ReturnMoney()
        {
            snackMachine.ReturnMoney();
            string uiMessage = "Your money has been returned";
            UpdateUI(uiMessage);            
        }

        private void InsertMoney(Money coinOrNote)
        {
            snackMachine.InsertMoney(coinOrNote);
            string uiMessage = $"You have inserted { coinOrNote }";
            UpdateUI(uiMessage);            
        }

        private void UpdateUI(string _message)
        {
            Notify(nameof(MoneyInTransaction));
            Notify(nameof(MoneyInside));
            Message = _message;
        }
    }
}
