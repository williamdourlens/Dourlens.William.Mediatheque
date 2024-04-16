using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {
        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;

        public MediathequeService(INotationService notationService)
        {
            _notationService = notationService;
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        public int GetNombreObjet()
        {
            return _fondDeCommerce.Count;
        }
        
        public List<string> PresentationCD()
        {
            List<string> listeCD = new List<string>();

            if (_fondDeCommerce.Count == 0)
            {
                listeCD.Add("Pas de CD");
                return listeCD;
            }

            foreach (CD objet in _fondDeCommerce)
            {
                string description = $"{objet.TitreDeLObjet} par {objet.Groupe}, noté {objet.Note}";
                listeCD.Add(description);
            }

            return listeCD;
        }
    }
}
