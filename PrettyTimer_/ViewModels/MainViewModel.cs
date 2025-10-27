using System.ComponentModel; // contient INotifyPropertyChanged, l’interface qui permet d’avertir l’UI quand une propriété change.

using System.Runtime.CompilerServices; // on l’utilise pour l’attribut [CallerMemberName] (pratique pour ne pas retaper le nom des propriétés à la main)

namespace PrettyTimer.ViewModels // namespace PrettyTimer.ViewModels : range la classe dans un “dossier logique” (cohérent avec ton dossier ViewModels/)
{
    public class MainViewModel : INotifyPropertyChanged //MainViewModel : c’est le ViewModel de l’écran principal. &&  INotifyPropertyChanged : le ViewModel promet d’annoncer à l’UI quand ses propriétés changent. 
    {
        public event PropertyChangedEventHandler? PropertyChanged; //PropertyChanged : événement que l’UI écoute. Quand on le déclenche, la Vue rafraîchit les bindings concernés.

        private void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); // petite méthode utilitaire. L’attribut [CallerMemberName] remplit automatiquement le nom de la propriété appelante. Ainsi, dans un setter, on peut juste faire OnPropertyChanged() sans écrire "RemainingText" en dur (évite les fautes de frappe).

        // ----- Données exposé à la view -----
        private string _remainingText = "00:05:00";

        public string RemainingText // propriété public qui nous permettre de l'appeler autre part par exemple dans Text dans le script Main.Window.axaml : Text="{Binding RemainingText}"
        {
            get => _remainingText;
            set
            {
                if (_remainingText == value) return; // évite de refresh inutile si il n'y a pas de changement
                _remainingText = value;
                OnPropertyChanged(); // Permet de notifier l'UI : "RemainingText a changé"
            }
        }

        public void Start()
        {
            RemainingText = "00:04:59"; // à automatiser selectionner dans l'application
        }

        public void Pause()
        {

        }
        
        public void Reset()
        {
            RemainingText = "00:05:00"; // A automatisé pour que la valeur d'entrer sois pareil au lieu de changer à la main la durée du Timer
            
        }

    }

}
