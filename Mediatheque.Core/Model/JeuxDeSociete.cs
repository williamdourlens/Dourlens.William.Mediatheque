namespace Mediatheque.Core.Model
{
    public class JeuxDeSociete: ObjetDePret
    {
        public JeuxDeSociete(string titreDeLObjet, int ageMini, int ageMaxi, string editeur, TypeJeuxDeSociete type) : base(titreDeLObjet)
        {
            this.AgeMinimum = ageMini;
            this.AgeMaximum = ageMaxi;
            this.Editeur = editeur;
            this.TypeJeux = type;
        }

        public int AgeMinimum { get; set; }
        public int AgeMaximum { get; set; }
        public string Editeur { get; set; }
        public TypeJeuxDeSociete TypeJeux { get; set; }
    }
}
