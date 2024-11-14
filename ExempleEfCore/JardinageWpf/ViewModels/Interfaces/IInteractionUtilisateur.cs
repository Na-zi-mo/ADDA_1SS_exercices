namespace JardinageWpf.ViewModels.Interfaces
{
    public interface IInteractionUtilisateur
    {
        public void AfficherMessageErreur(string msg);
        public void AfficherMessageInfo(string msg);
        public bool PoserQuestion(string question);
    }
}
