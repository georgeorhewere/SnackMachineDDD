using SnackMachine.Logic;

namespace SnackMachine.UI.Common.ViewModels
{
    public class SnackMachineViewModel: BaseViewModel
    {
        private readonly SnackMachine.Logic.SnackMachine snackMachine;
        public override string Caption => "Snack Machine DDD";
        public string MoneyInTransaction => snackMachine.MoneyInTransaction.Amount.ToString();
       // public Command InsertCentCommand;
        public SnackMachineViewModel(SnackMachine.Logic.SnackMachine _snackMachine)
        {
            snackMachine = _snackMachine;
        }



    }
}
