using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4.ViewModels.Interfaces
{
    public interface IInteractionUtilisateur
    {
        public void OpenConfigurationWindow();
        public void CloseConfigurationWindow();
        public void ShowErrorMessage(string message);
        public void ShowInformationMessage(string message);
    }
}
