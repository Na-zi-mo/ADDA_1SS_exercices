using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using TP1.Models;
using static System.Net.Mime.MediaTypeNames;
using static TP1.ViewModels.Delegates.ViewModelDelegates;

namespace TP1.ViewModels
{
    public class ElectionViewModel : BaseViewModel
    {

        public ElectionViewModel(MessageErreur erreur, Question question) : base(erreur, question) 
        {
            this.Contributions = new ObservableCollection<Contribution>();

            List<string> lines = new List<string>(TP1.Properties.AutresRessources.contributions.Split('\n'));

            foreach (string line in lines)
            {
                //this.Contributions.Add(new Contribution(line));
            }

            for (int i = 1; i < 3; i++)
            {
                this.Contributions.Add(new Contribution(lines[i]));
            }
        }

        public ObservableCollection<Contribution> Contributions { get; set; }

    }
}
