using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MS_4._2
{
    public class Gruppo
    {
        private static List<string> _eleragioni = new List<String>();
        private string _ragioneSociale;
        public string ragioneSociale
        {
            get
            {
                return _ragioneSociale;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Ragione sociale non valida");
                }
                _ragioneSociale = value;
            }
        }
        private string _indirizzo;
        public string indirizzo
        {
            get
            {
                return _indirizzo;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Indirizzo non valido");
                }
                _indirizzo = value;
            }
        }
        private string _presidente;
        public string presidente
        {
            get
            {
                return _presidente;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Nominativo non valido");
                }
                _presidente = value;
            }
        }
        private string _telefono;
        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Numero non valido");
                }
                _telefono = value;
            }
        }
        private string _mail;
        public string mail
        {
            get
            {
                return _mail;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Mail non valida");
                }
                _mail = value;
            }
        }
        public Gruppo(string r, string i, string p, string t, string m)
        {
            if (string.IsNullOrEmpty(r))
            {
                throw new Exception("Ragione sociale non valida.");
            }
            if (_eleragioni.Contains(r))
            {
                throw new Exception("Gruppo già esistente.");
            }
            this.ragioneSociale = r;
            this.indirizzo = i;
            this.presidente = p;
            this.telefono = t;
            this.mail = m;
            _eleragioni.Add(r);
        }
        public static void Cancella(string r)
        {
            _eleragioni.RemoveAll(p => p == r);
        }
    }
    public class Disciplina
    {
        private static List<string> _elenomi = new List<String>();
        private string _nomeDisciplina;
        public string nomeDisciplina
        {
            get
            {
                return _nomeDisciplina;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Disciplina non valida");
                }
                _nomeDisciplina = value;
            }
        }
        private int _Dilettanti;
        public int Dilettanti
        {
            get
            {
                return _Dilettanti;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Soglia non valida");
                }
                _Dilettanti = value;
            }
        }
        private int _Junior;
        public int Junior
        {
            get
            {
                return _Junior;
            }
            set
            {
                if (value < Dilettanti || value > 100)
                {
                    throw new Exception("Soglia non valida");
                }
                _Junior = value;
            }
        }
        private int _Senior;
        public int Senior
        {
            get
            {
                return _Senior;
            }
            set
            {
                if (value < _Junior || value > 100)
                {
                    throw new Exception("Soglia non valida");
                }
                _Senior = value;
            }
        }
        public Disciplina(string n, int d, int j, int s)
        {
            if (string.IsNullOrEmpty(n))
            {
                throw new Exception("Nome non valido.");
            }
            if (_elenomi.Contains(n))
            {
                throw new Exception("Disciplina già esistente.");
            }
            this.nomeDisciplina = n;
            this.Dilettanti = d;
            this.Junior = j;
            this.Senior = s;
            _elenomi.Add(n);
        }
        public static void Cancella(string n)
        {
            _elenomi.RemoveAll(p => p == n);
        }
    }
    public class Atleta
    {
        private static List<string> _elecodici = new List<String>();
        private string _codice;
        public string codice
        {
            get
            {
                return _codice;
            }
        }
        private string _medico;
        public string medico
        {
            get
            {
                return _medico;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Nome non valido");
                }
                _medico = value;
            }
        }
        private DateTime _dataCertificato;
        public DateTime dataCertificato
        {
            get
            {
                return _dataCertificato;
            }
            set
            {
                if (value > DateTime.Now || value == null)
                {
                    throw new Exception("Data non valida");
                }
                _dataCertificato = value;
            }
        }
        private string _nome;
        public string nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Nome non valido");
                }
                _nome = value;
            }
        }
        private string _cognome;
        public string cognome
        {
            get
            {
                return _cognome;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Cognome non valido");
                }
                _cognome = value;
            }
        }
        private DateTime _nascita;
        public DateTime nascita
        {
            get
            {
                return _nascita;
            }
            set
            {
                if (value > dataCertificato || value == null || value > DateTime.Now)
                {
                    throw new Exception("Data non valida");
                }
                _nascita = value;
            }
        }
        private string _città;
        public string città
        {
            get
            {
                return _città;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Città non valida");
                }
                _città = value;
            }
        }
        private Gruppo _gruppo;
        public Gruppo gruppo
        {
            get
            {
                return _gruppo;
            }
            set
            {
                if(value == null)
                {
                    throw new Exception("Gruppo sportivo non valido");
                }
                _gruppo = value;
            }
        }
        private Disciplina _disciplina;
        public Disciplina disciplina
        {
            get
            {
                return _disciplina;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Disciplina non valida");
                }
                _disciplina = value;
            }
        }
        private string _livello;
        public string livello
        {
            get
            {
                return _livello;
            }
            set
            {
                if (!(value == "Dilettanti" || value == "Junior" || value == "Senior"))
                {
                    throw new Exception("Livello non valido");
                }
                _livello = value;
            }
        }
        private int _punteggio;
        public int punteggio
        {
            get
            {
                return _punteggio;
            }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Punteggio non valido");
                }
                _punteggio = value;
            }
        }
        private bool _idoneità;
        public bool idoneità
        {
            get
            {
                return _idoneità;
            }
            set
            {
                _idoneità = value;
            }
        }
        public Atleta(string c, string m, DateTime dc, string n, string cogn, DateTime dn, string res, Gruppo g, Disciplina d, string l, int p)
        {
            if (string.IsNullOrEmpty(c))
            {
                throw new Exception("Codice non valido.");
            }
            if (_elecodici.Contains(c))
            {
                throw new Exception("Codice già esistente.");
            }           
            if(p < (int)d.GetType().GetProperty(l).GetValue(d, null))
            {
                throw new Exception("Punteggio non conforme.");
            }
            this._codice = c;
            this.medico = m;
            this.dataCertificato = dc;
            this.nome = n;
            this.cognome = cogn;
            this.nascita = dn;
            this.città = res;
            this.gruppo = g;
            this.disciplina = d;
            this.livello = l;
            this.punteggio = p;
            this.idoneità = true;

            _elecodici.Add(c);
        }
        public static void Cancella(string c)
        {
            _elecodici.RemoveAll(p => p == c);
        }
    }
    public class Funzioni
    {
        public static void Riempimento(TabControl tab, DataGridView d)
        {
            int x = 0;
            foreach (TabPage t in tab.TabPages)
            {
                if (t == tab.SelectedTab)
                {
                    foreach (Control c in t.Controls)
                    {
                        if (c is TextBox || c is ComboBox || c is NumericUpDown)
                        {
                            c.Text = d.SelectedRows[0].Cells[x].Value.ToString();
                            x++;
                        }
                    }
                }
            }
        }
        public static void Clear(TabControl tab)
        {
            foreach (TabPage t in tab.TabPages)
            {
                if (t == tab.SelectedTab)
                {
                    foreach (Control c in t.Controls)
                    {
                        if (c is TextBox || c is ComboBox || c is NumericUpDown)
                        {
                            c.ResetText();
                        }
                    }
                }
            }
        }
        public static void Select(DataGridView data, List<Atleta> l)
        {
            var ll = l.Select(p => new
            {
                Codice = p.codice,
                Medico = p.medico,
                Data_Certificato = p.dataCertificato,
                Nome = p.nome,
                Cognome = p.cognome,
                Residenza = p.città,
                Data_nascita = p.nascita,
                Gruppo_sportivo = p.gruppo.ragioneSociale,
                Disciplina = p.disciplina.nomeDisciplina,
                Livello = p.livello,
                Punteggio = p.punteggio,
                Idoneità = p.idoneità
            });
            data.DataSource = ll.ToList();
        }
    }
}
