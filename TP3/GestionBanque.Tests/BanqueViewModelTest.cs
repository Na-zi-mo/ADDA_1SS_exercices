using GestionBanque.Models;
using GestionBanque.Models.DataService;
using GestionBanque.ViewModels.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque.Tests
{
    public class BanqueViewModelTest
    {
        private readonly Mock<IInteractionUtilisateur> _interUtilMock = new Mock<IInteractionUtilisateur>();
        private readonly Mock<IDataService<Client>> _clientDataService = new Mock<IDataService<Client>>();
        private readonly Mock<IDataService<Compte>> _compteDataService = new Mock<IDataService<Compte>>();


        public BanqueViewModelTest()
        {
            _interUtilMock.Setup(iu => iu.AfficherMessageErreur(It.IsAny<string>()));
            _interUtilMock.Setup(iu => iu.PoserQuestion(It.IsAny<string>())).Returns(true);
        }


    }
}
