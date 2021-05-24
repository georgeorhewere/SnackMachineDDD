using SnackMachine.Logic;
using SnackMachine.UI.Common.Commands;
using System;

namespace SnackMachine.UI.Common.ViewModels
{
    public class SnackMachineViewModel: BaseViewModel
    {
        private readonly SnackMachine.Logic.SnackMachine snackMachine;
        public override string Caption => "Snack Machine DDD";
        public string MoneyInTransaction => snackMachine.MoneyInTransaction.Amount.ToString();
        public Command InsertCentCommand { get; private set; }
        public SnackMachineViewModel(SnackMachine.Logic.SnackMachine _snackMachine)
        {
            snackMachine = _snackMachine;
            InsertCentCommand = new Command(o => InsertMoney(Money.OneCent));
        }

        private void InsertMoney(Money money)
        {
            snackMachine.InsertMoney(money);
            Notify("MoneyInTransaction");
        }
    }
}
